using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urunTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace urunTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DBMvcStokYonetimEntities db = new DBMvcStokYonetimEntities();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            var mstr = db.tblMusteri.ToList().ToPagedList(sayfa, 5);
            return View(mstr);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(tblMusteri p)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.tblMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var mstr = db.tblMusteri.Find(id);
            db.tblMusteri.Remove(mstr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.tblMusteri.Find(id);
            return View("MusteriGetir", mstr);
        }
        public ActionResult MusteriGuncelle(tblMusteri p)
        {
            var mstr = db.tblMusteri.Find(p.id);
            mstr.ad = p.ad;
            mstr.soyad = p.soyad;
            mstr.sehir = p.sehir;
            mstr.bakiye = p.bakiye;

            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}