using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using urunTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace urunTakip.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DBMvcStokYonetimEntities db=new DBMvcStokYonetimEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var satislar = db.tblSatislar.ToList().ToPagedList(sayfa, 5);
            return View(satislar);
        }

        public ActionResult YeniSatis()
        {
            List<SelectListItem> urun = (from x in db.tblUrunler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop1 = urun;

            List<SelectListItem> per = (from x in db.tblPersonel.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.ad +" "+ x.soyad,
                                             Value = x.id.ToString()
                                         }).ToList();
            ViewBag.drop2 = per;


            List<SelectListItem> mstr = (from x in db.tblMusteri.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.ad +" "+ x.soyad,
                                            Value = x.id.ToString()
                                        }).ToList();
            ViewBag.drop3 = mstr;


            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(tblSatislar p)
        {
            var urun =db.tblUrunler.Where(x => x.id == p.tblUrunler.id).FirstOrDefault();
            var musteri = db.tblMusteri.Where(x => x.id == p.tblMusteri.id).FirstOrDefault();
            var personel = db.tblPersonel.Where(x => x.id == p.tblPersonel.id).FirstOrDefault();
            p.tblUrunler = urun;
            p.tblMusteri = musteri; 
            p.tblPersonel = personel;
            p.tarih =DateTime.Parse (DateTime.Now.ToShortDateString());

            db.tblSatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}