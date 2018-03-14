using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Generator.Function
{
    public class PicGenerator
    {
        public MemoryStream GetImage(string path, string nick, string message, Image avatar = null)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            int panel_left = 40;
            int width, height = 70, font_size = 10;
            Bitmap bmp = new Bitmap(100, height);
            Graphics g = Graphics.FromImage(bmp);
            width = (int)g.MeasureString(message, new Font("微软雅黑", font_size)).Width;
            int width_tmp = (int)g.MeasureString(nick, new Font("微软雅黑", font_size - 1.2f)).Width + 10;
            float offset_width = (141 - width) * 0.055f;
            g.Dispose();
            bmp.Dispose();

            bmp = new Bitmap((width > width_tmp ? width + 30 : width_tmp) + panel_left, height);
            g = Graphics.FromImage(bmp);
            Debug.WriteLine(Environment.CurrentDirectory);
            Image img_left = Image.FromFile(Path.Combine(path, "left.png"));
            Image img_right = Image.FromFile(Path.Combine(path, "right.png"));
            Image cover = Image.FromFile(Path.Combine(path, "cover.png"));
            Rectangle rec_panel = new Rectangle(panel_left, 0, height, width);

            g.Clear(Color.White);
            g.CompositingQuality = CompositingQuality.HighQuality;

            if (avatar != null)
            {
                g.DrawImage(avatar, 7, 7, 30, 30); // ava
                g.DrawImage(cover, 7, 7, 30, 30); // ava
            }
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(new Rectangle(7, 7, 30, 30));

            g.DrawString(nick, new Font("微软雅黑", font_size - 1.2f), new SolidBrush(Color.FromArgb(128, 128, 128)),
                new PointF(rec_panel.X + 5f, rec_panel.Y + 5f));  // nick

            g.DrawImage(img_left, rec_panel.X + 2f, rec_panel.Y + 25f);  // left
            g.FillRectangle(new SolidBrush(Color.FromArgb(229, 229, 229)), rec_panel.X + img_left.Width, rec_panel.Y + 25f,
                width + 1 + offset_width + 1, img_left.Height);  // rectangle fill
            g.DrawImage(img_right, rec_panel.X + img_left.Width + width + 1 + offset_width, rec_panel.Y + 25f);  // right

            g.DrawString(message, new Font("微软雅黑", font_size), Brushes.Black,
                new PointF(rec_panel.X + 17f, rec_panel.Y + 36f));  // message

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            g.Dispose();
            bmp.Dispose();
            return ms;
        }
    }
}
