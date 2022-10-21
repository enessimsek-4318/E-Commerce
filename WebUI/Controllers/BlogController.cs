using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult BlogList()
        {
            return View();
        }
        public ActionResult BlogSingle()
        {
            return View();
        }
    }
}