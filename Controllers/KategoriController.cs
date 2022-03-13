using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCProje.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDBStokEntities db = new MvcDBStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBL_KATEGORILER.ToList();
            var degerler = db.TBL_KATEGORILER.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBL_KATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBL_KATEGORILER.Add(p1);
            db.SaveChanges();
            return View(p1);
        }
        public ActionResult Sil(int  id)
        {
            var ktgori = db.TBL_KATEGORILER.Find(id);
            db.TBL_KATEGORILER.Remove(ktgori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgrgetir = db.TBL_KATEGORILER.Find(id);
            return View("KategoriGetir",ktgrgetir);
        }
        public ActionResult Guncelle(TBL_KATEGORILER p2)
        {
            var ktgrguncelle = db.TBL_KATEGORILER.Find(p2.KATEGORIID);
            ktgrguncelle.KATEGORIAD = p2.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}