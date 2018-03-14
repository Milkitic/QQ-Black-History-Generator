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
            try
            {
                if (nick == null || message == null)
                {
                    nick = "【Easy】gust@北京";
                    message = "想摸女孩子";
                }
                PicGenerator gn = new PicGenerator();
                Image ava_img = null;

                string path = Server.MapPath("upload");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                string fullName = "";
                if (ava == null)
                    ava_img = Image.FromFile(Path.Combine(path, "ava.jpg"));
                else
                {
                    var fileName = Session.SessionID + "-" + ava.FileName;
                    var filePath = path;
                    fullName = Path.Combine(filePath, fileName);
                    ava.SaveAs(fullName);
                    ava_img = Image.FromFile(fullName);
                }
                byte[] stream = gn.GetImage(Server.MapPath("content"), nick, message, ava_img).ToArray();
                //if (fullName != "")
                //{
                //    System.IO.File.Delete(fullName);
                //}

                return File(stream, "image/png");
            }

            catch (Exception ex)
            {
                ViewData["ex"] = ex.ToString();
                return View("error");
            }
        }
    }
}
