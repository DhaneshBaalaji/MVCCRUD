using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANTCRUDAUTH.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nothing big here";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dhanesh Baalaji";

            return View();
        }
    }

}