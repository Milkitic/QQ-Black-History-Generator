using Generator.Function;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Generator2.Controllers
{
    public class ApiController : Controller
    {
        [HttpPost]
        public ActionResult GetImage(string nick, string message, HttpPostedFileBase ava)
        {
            if (nick == null || message == null)
            {
                nick = "【Easy】gust@北京";
                message = "想摸女孩子";
            }
            PicGenerator gn = new PicGenerator();
            Image ava_img = null;

            string path = Server.MapPath("content");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            if (ava == null)
                ava_img = Image.FromFile(Path.Combine(path, "ava.jpg"));
            else
            {
                var fileName = Session.SessionID + "-" + ava.FileName;
                var filePath = path;
                var fullName = Path.Combine(filePath, fileName);
                ava.SaveAs(fullName);
                ava_img = Image.FromFile(fullName);
            }
            return File(gn.GetImage(Server.MapPath("content"), nick, message, ava_img).ToArray(), "image/png");

        }
    }
}
