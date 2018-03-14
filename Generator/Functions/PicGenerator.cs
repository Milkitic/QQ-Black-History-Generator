using System;
using System.Collections.Generic;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Generator.Function
{
    public class PicGenerator
    {
        public MemoryStream GetImage(string id, string message, Image avatar = null)
        {
            Bitmap bmp = new Bitmap(100, 35);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.FillRectangle(Brushes.Red, 2, 2, 125, 31);
            g.DrawString("test", new Font("黑体", 15f), Brushes.Yellow, new PointF(5f, 5f));
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.DrawingCore.Imaging.ImageFormat.Png);
            g.Dispose();
            bmp.Dispose();
            return ms;
        }
    }
}
