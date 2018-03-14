using Generator.Function;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generator2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult GetImage()
        {
            PicGenerator gn = new PicGenerator();

            return File(gn.GetImage(Server.MapPath("content"), "【Easy】gust@北京", "我是弱智").ToArray(), "image/png");

        }
    }
}