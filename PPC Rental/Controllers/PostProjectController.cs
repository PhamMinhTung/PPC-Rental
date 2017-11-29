using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

namespace PPC_Rental.Controllers
{
    public class PostProjectController : Controller
    {
        K21T1_Team4Entities db = new K21T1_Team4Entities();
        // GET: PostProject
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PROPERTY property, HttpPostedFileBase Image)
        {
            string image = "";
            if (Image.ContentLength > 0)
            {
                var filename = Path.GetFileName(Image.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), filename);
                Image.SaveAs(path);
                image = filename;
            }
            var post = new PROPERTY();
            post.PropertyName = property.PropertyName;
            post.Area = property.Area;
            post.Avatar = property.Avatar;
            post.BathRoom = property.BathRoom;
            post.BedRoom = property.BedRoom;
            post.Content = property.Content;
            post.Created_at = property.Created_at;
            post.Create_post = property.Create_post;
            post.DISTRICT = property.DISTRICT;
            post.Images = property.Images;
            post.PackingPlace = property.PackingPlace;
            post.Price = property.Price;
            post.PROJECT_STATUS = property.PROJECT_STATUS;
            post.PROPERTY_FEATURE = property.PROPERTY_FEATURE;
            post.UnitPrice = property.UnitPrice;

            db.PROPERTies.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}