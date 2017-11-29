using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Controllers
{
    public class HomeController : Controller
    {
        K21T1_Team4Entities db = new K21T1_Team4Entities();
        public ActionResult Index()
        {
            var model = db.PROPERTies.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}