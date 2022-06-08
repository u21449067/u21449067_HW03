using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace _272HW3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(HttpPostedFileBase Files)
        {
            if(Files != null && Files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(Files.FileName);

                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                Files.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]

        
        public ActionResult Files()
        {
            return View();
        }

        public ActionResult Images()
        {
            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}