using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;

namespace PPC_Rental.Controllers
{
    public class ViewDetailProjectController : Controller
    {
        K21T1_Team4Entities db = new K21T1_Team4Entities();
        // GET: ViewDetailProject
        public ActionResult ViewDetailProject(int id)
        {
            var project = db.PROPERTies.FirstOrDefault(t => t.ID == id);
            return View(project);
        }
    }
}