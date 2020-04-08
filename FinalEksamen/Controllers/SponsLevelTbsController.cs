using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalEksamen;

namespace FinalEksamen.Controllers
{
    public class SponsLevelTbsController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();

        // GET: SponsLevelTbs
        public ActionResult Index()
        {
            return View(db.SponsLevelTbs.ToList());
        }

        // GET: SponsLevelTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsLevelTb sponsLevelTb = db.SponsLevelTbs.Find(id);
            if (sponsLevelTb == null)
            {
                return HttpNotFound();
            }
            return View(sponsLevelTb);
        }

        // GET: SponsLevelTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SponsLevelTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SponsLevel")] SponsLevelTb sponsLevelTb)
        {
            if (ModelState.IsValid)
            {
                db.SponsLevelTbs.Add(sponsLevelTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sponsLevelTb);
        }

        // GET: SponsLevelTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsLevelTb sponsLevelTb = db.SponsLevelTbs.Find(id);
            if (sponsLevelTb == null)
            {
                return HttpNotFound();
            }
            return View(sponsLevelTb);
        }

        // POST: SponsLevelTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SponsLevel")] SponsLevelTb sponsLevelTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sponsLevelTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sponsLevelTb);
        }

        // GET: SponsLevelTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SponsLevelTb sponsLevelTb = db.SponsLevelTbs.Find(id);
            if (sponsLevelTb == null)
            {
                return HttpNotFound();
            }
            return View(sponsLevelTb);
        }

        // POST: SponsLevelTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SponsLevelTb sponsLevelTb = db.SponsLevelTbs.Find(id);
            db.SponsLevelTbs.Remove(sponsLevelTb);
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
