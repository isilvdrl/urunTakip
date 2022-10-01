using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urunTakip.Models.Entity;

namespace urunTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DBMvcStokYonetimEntities db= new DBMvcStokYonetimEntities();
        public ActionResult Index(string p)
        {
            var urunler =from x in db.tblUrunler select x;
            if(!string.IsNullOrEmpty(p))
            {
                urunler=urunler.Where(x=>x.ad.Contains(p));
            }
            return View(urunler.ToList());
        }


        [HttpGet]
        public ActionResult YeniUrun()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(tblUrunler p)
        {
            db.tblUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = db.tblUrunler.Find(id);
              db.tblUrunler.Remove(urun);
              db.SaveChanges();
              return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urun = db.tblUrunler.Find(id);
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(tblUrunler p)
        {
            var urun = db.tblUrunler.Find(p.id);
            urun.ad = p.ad;
            urun.marka = p.marka;
            urun.stok = p.stok;
            urun.alisfiyat = p.alisfiyat;
            urun.satisfiyat = p.satisfiyat;
            urun.kategori = p.kategori;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

