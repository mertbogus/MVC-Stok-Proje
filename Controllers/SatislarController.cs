using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProje.Models.Entity;

namespace MVCProje.Controllers
{
    public class SatislarController : Controller
    {
        MvcDBStokEntities db = new MvcDBStokEntities();
        // GET: Satislar
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniSatis(TBL_SATISLAR p)
        {
            db.TBL_SATISLAR.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}