using Generator.Function;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Generator2.Models;

namespace Generator2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("api")).Parent;
            string root;
            if (di.Name.ToLower() == "home")
                root = Path.Combine(di.Parent.FullName, "api", "content", "handled");
            else
                root = Path.Combine(Server.MapPath("api"), "content", "handled");

            List<string> items = new List<string>();
            string[] items_query = { "", "", "", "", "" };
            Random rnd = new Random();
            if (Directory.Exists(root))
            {
                DirectoryInfo dir = new DirectoryInfo(root);
                if (dir.GetFiles().Length > 5)
                {
                    foreach (var item in dir.GetFiles())
                    {
                        items.Add(item.Name);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        int rnd_result = rnd.Next(0, items.Count);
                        items_query[i] = items[rnd_result];
                        items.RemoveAt(rnd_result);
                    }
                }
                else
                {
                    FileInfo[] files = dir.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        items_query[i] = files[i].Name;
                    }
                }
            }
            ViewData["roots"] = items_query;
            return View();
        }
    }
}
