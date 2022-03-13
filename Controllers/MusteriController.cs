using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;

namespace MVCProje.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDBStokEntities db=new MvcDBStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_MUSTERILER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBL_MUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            db.TBL_MUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var musteri=db.TBL_MUSTERILER.Find(id);
            db.TBL_MUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBL_MUSTERILER.Find(id);
            return View("MusteriGetir",musteri);    
        }
        public ActionResult Guncelle(TBL_MUSTERILER p1)
        {
            var musteri = db.TBL_MUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERISOYAD= p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}