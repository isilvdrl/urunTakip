using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urunTakip.Models.Entity;

namespace urunTakip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DBMvcStokYonetimEntities db = new DBMvcStokYonetimEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(tblAdmin p)
        {
            db.tblAdmin.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}