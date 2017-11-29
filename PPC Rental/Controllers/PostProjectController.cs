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
        public ActionResult Create(PROPERTY property, HttpPostedFileBase Avatar, HttpPostedFileBase Image)
        {
            string avatar = "";
            if (Avatar.ContentLength > 0)
            {

                var filenameav = Path.GetFileName(Avatar.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), filenameav);
                Avatar.SaveAs(path);
                avatar = filenameav;
            }
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
            post.Create_post = DateTime.Now;
            post.Images = property.Images;
            post.PackingPlace = property.PackingPlace;
            post.Price = property.Price;
            post.PROJECT_STATUS = property.PROJECT_STATUS;
            post.PROPERTY_FEATURE = property.PROPERTY_FEATURE;
            post.UnitPrice = property.UnitPrice;
            post.Ward_ID = property.Ward_ID;
            post.District_ID = property.District_ID;
            post.PropertyType_ID = property.PropertyType_ID;
            db.PROPERTies.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}