using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urunTakip.Models.Entity;


namespace urunTakip.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        DBMvcStokYonetimEntities db=new DBMvcStokYonetimEntities();

        public ActionResult Index()
        {
            var kategoriler =db.tblKategory.ToList();   
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(tblKategory p)
        {
            db.tblKategory.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
           var ktg=db.tblKategory.Find(id);
            db.tblKategory.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.tblKategory.Find(id);
            return View("KategoriGetir",ktg);
        }
        public ActionResult KategoriGuncelle(tblKategory p)
        {
            var ktg = db.tblKategory.Find(p.id);
            ktg.ad = p.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}