using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalEksamen;

namespace FinalEksamen.Controllers
{
    public class Bestyrelse_TbController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();

        // GET: Bestyrelse_Tb
        public ActionResult Index()
        {
            var bestyrelse_Tbs = db.Bestyrelse_Tbs.Include(b => b.BestyrelseRole);
            return View(bestyrelse_Tbs.ToList());
        }

        // GET: Bestyrelse_Tb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestyrelse_Tb bestyrelse_Tb = db.Bestyrelse_Tbs.Find(id);
            if (bestyrelse_Tb == null)
            {
                return HttpNotFound();
            }
            return View(bestyrelse_Tb);
        }

        // GET: Bestyrelse_Tb/Create
        public ActionResult Create()
        {
            ViewBag.Fk_MedlemRole = new SelectList(db.BestyrelseRoles, "Id", "MedlemRole");
            return View();
        }

        // POST: Bestyrelse_Tb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Bestyrelse_Tb bestyrelse_Tb, HttpPostedFileBase MedlemImg)
        {
            if (ModelState.IsValid)
            {
                if (MedlemImg != null)
                {
                    Guid FileId = Guid.NewGuid();
                    string[] Ex = { ".jpg", ".png", ".gif" };
                    IOTools.FileUplader("~/Content/MedlemerImg", FileId.ToString(), MedlemImg, Ex);
                    bestyrelse_Tb.MedlemImg = FileId.ToString() + "-" + MedlemImg.FileName;

                }
                db.Bestyrelse_Tbs.Add(bestyrelse_Tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_MedlemRole = new SelectList(db.BestyrelseRoles, "Id", "MedlemRole", bestyrelse_Tb.Fk_MedlemRole);
            return View(bestyrelse_Tb);
        }

        // GET: Bestyrelse_Tb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestyrelse_Tb bestyrelse_Tb = db.Bestyrelse_Tbs.Find(id);
            if (bestyrelse_Tb == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_MedlemRole = new SelectList(db.BestyrelseRoles, "Id", "MedlemRole", bestyrelse_Tb.Fk_MedlemRole);
            return View(bestyrelse_Tb);
        }

        // POST: Bestyrelse_Tb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Bestyrelse_Tb bestyrelse_Tb, HttpPostedFileBase MedlemImg,int?Id)
        {
            if (ModelState.IsValid)
            {
                if (MedlemImg != null)
                {
                    IOTools.DelFile("~/Content/MedlemerImg/" + bestyrelse_Tb.MedlemImg);
                    Guid FileId = Guid.NewGuid();
                    string[] Ex = { ".jpg", ".png", ".gif" };
                    IOTools.FileUplader("~/Content/MedlemerImg", FileId.ToString(), MedlemImg, Ex);
                    bestyrelse_Tb.MedlemImg = FileId.ToString() + "-" + MedlemImg.FileName;

                }
                else
                {
                    Bestyrelse_Tb gemmelbellede = db.Bestyrelse_Tbs.Find(Id);
                    bestyrelse_Tb.MedlemImg = gemmelbellede.MedlemImg;
                }
                db.Bestyrelse_Tbs.AddOrUpdate(bestyrelse_Tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_MedlemRole = new SelectList(db.BestyrelseRoles, "Id", "MedlemRole", bestyrelse_Tb.Fk_MedlemRole);
            return View(bestyrelse_Tb);
        }

        // GET: Bestyrelse_Tb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bestyrelse_Tb bestyrelse_Tb = db.Bestyrelse_Tbs.Find(id);
            if (bestyrelse_Tb == null)
            {
                return HttpNotFound();
            }
            return View(bestyrelse_Tb);
        }

        // POST: Bestyrelse_Tb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Bestyrelse_Tb bestyrelse_Tb = db.Bestyrelse_Tbs.Find(id);
            IOTools.DelFile("~/Content/MedlemerImg/" + bestyrelse_Tb.MedlemImg);
            db.Bestyrelse_Tbs.Remove(bestyrelse_Tb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
