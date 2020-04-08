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
    public class SponsorerTbsController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();

        // GET: SponsorerTbs
        public ActionResult Index()
        {
            var sponsorerTbs = db.SponsorerTbs.Include(s => s.SponsLevelTb);
            return View(sponsorerTbs.ToList());
        }

        // GET: SponsorerTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorerTb sponsorerTb = db.SponsorerTbs.Find(id);
            if (sponsorerTb == null)
            {
                return HttpNotFound();
            }
            return View(sponsorerTb);
        }

        // GET: SponsorerTbs/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Level = new SelectList(db.SponsLevelTbs, "Id", "SponsLevel");
            return View();
        }

        // POST: SponsorerTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SponsorerTb sponsorerTb, HttpPostedFileBase sponsImg)
        {
            if (ModelState.IsValid)
            {
                if (sponsImg != null)
                {
                   
                    Guid FileId = Guid.NewGuid();
                    string[] Ex = { ".jpg", ".png", ".gif" };
                    IOTools.FileUplader("~/Content/SponsImg", FileId.ToString(), sponsImg, Ex);
                    sponsorerTb.sponLogo = FileId.ToString() + "-" + sponsImg.FileName;
                }

                db.SponsorerTbs.Add(sponsorerTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Level = new SelectList(db.SponsLevelTbs, "Id", "SponsLevel", sponsorerTb.Fk_Level);
            return View(sponsorerTb);
        }

        // GET: SponsorerTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorerTb sponsorerTb = db.SponsorerTbs.Find(id);
            if (sponsorerTb == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Level = new SelectList(db.SponsLevelTbs, "Id", "SponsLevel", sponsorerTb.Fk_Level);
            return View(sponsorerTb);
        }

        // POST: SponsorerTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SponsorerTb sponsorerTb, HttpPostedFileBase sponsImg,int?Id)
        {
            if (ModelState.IsValid)
            {
                if (sponsImg != null)
                {
                    IOTools.DelFile("~/Content/SponsImg" + sponsorerTb.sponLogo);
                    Guid FileId = Guid.NewGuid();
                    string[] Ex = { ".jpg", ".png", ".gif" };
                    IOTools.FileUplader("~/Content/SponsImg", FileId.ToString(), sponsImg, Ex);
                    sponsorerTb.sponLogo = FileId.ToString() + "-" + sponsImg.FileName;
                }
                else
                {
                  SponsorerTb GammleBillede = db.SponsorerTbs.Find(Id);
                    sponsorerTb.sponLogo = GammleBillede.sponLogo;
                }
                db.SponsorerTbs.AddOrUpdate(sponsorerTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Level = new SelectList(db.SponsLevelTbs, "Id", "SponsLevel", sponsorerTb.Fk_Level);
            return View(sponsorerTb);
        }

        // GET: SponsorerTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsorerTb sponsorerTb = db.SponsorerTbs.Find(id);
            if (sponsorerTb == null)
            {
                return HttpNotFound();
            }
            return View(sponsorerTb);
        }

        // POST: SponsorerTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsorerTb sponsorerTb = db.SponsorerTbs.Find(id);
            IOTools.DelFile("~/Content/SponsImg" + sponsorerTb.sponLogo);
            db.SponsorerTbs.Remove(sponsorerTb);
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
