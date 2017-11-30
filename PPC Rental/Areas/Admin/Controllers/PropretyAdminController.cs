using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPC_Rental.Models;
using System.IO;

namespace PPC_Rental.Areas.Admin.Controllers
{
    public class PropretyAdminController : Controller
    {
        K21T1_Team4Entities read = new K21T1_Team4Entities();
        // GET: Admin/PropretyAdmin
        public ActionResult Index()
        {
            var proprety = read.PROPERTies.OrderByDescending(x => x.ID).ToList();
            return View(proprety);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = read.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.proprety_type = read.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.street = read.STREETs.OrderByDescending(x => x.ID).ToList();
            ViewBag.ward = read.WARDs.OrderByDescending(x => x.ID).ToList();
            ViewBag.dictrict = read.DISTRICTs.OrderByDescending(x => x.ID).ToList();
            ViewBag.user = read.USERs.OrderByDescending(x => x.ID).ToList();
            ViewBag.project_status = read.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();



            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id, PROPERTY p, PROPERTY proprety, HttpPostedFileBase Avatar, HttpPostedFileBase Image)
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
            var property = read.PROPERTies.FirstOrDefault(x => x.ID == id);
            property.PropertyName = p.PropertyName;
            property.Avatar = p.Avatar;
            property.Images = p.Images;
            property.PropertyType_ID = p.PropertyType_ID;
            property.Content = p.Content;
            property.Street_ID = p.Street_ID;
            property.Ward_ID = p.Ward_ID;
            property.District_ID = p.District_ID;
            property.Price = p.Price;
            property.UnitPrice = p.UnitPrice;
            property.Area = p.Area;
            property.BedRoom = p.BedRoom;
            property.BathRoom = p.BathRoom;
            property.PackingPlace = p.PackingPlace;
            property.UserID = p.UserID;
            property.Created_at = p.Created_at;
            property.Create_post = p.Create_post;
            property.Status_ID = p.Status_ID;
            property.Note = p.Note;
            property.Updated_at = DateTime.Now;
            read.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var property = read.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(property);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var property = read.PROPERTies.FirstOrDefault(x => x.ID == id);
            read.PROPERTies.Remove(property);
            read.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var property = read.PROPERTies.FirstOrDefault(x => x.ID == id);
            return View(property);


        }
    }
}