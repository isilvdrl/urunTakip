using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using urunTakip.Models.Entity;

namespace urunTakip.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBMvcStokYonetimEntities db = new DBMvcStokYonetimEntities();
        [HttpGet]
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(tblAdmin t)
        { var bilgiler = db.tblAdmin.FirstOrDefault(x => x.kullanici == t.kullanici && x.sifre == t.sifre);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            else 
            {
                return View();
            }
                
        }
    }
}