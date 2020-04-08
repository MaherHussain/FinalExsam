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
    public class RoleTbsController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();

        // GET: RoleTbs
        public ActionResult Index()
        {
            return View(db.RoleTbs.ToList());
        }

        // GET: RoleTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleTb roleTb = db.RoleTbs.Find(id);
            if (roleTb == null)
            {
                return HttpNotFound();
            }
            return View(roleTb);
        }

        // GET: RoleTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Role")] RoleTb roleTb)
        {
            if (ModelState.IsValid)
            {
                db.RoleTbs.Add(roleTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleTb);
        }

        // GET: RoleTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleTb roleTb = db.RoleTbs.Find(id);
            if (roleTb == null)
            {
                return HttpNotFound();
            }
            return View(roleTb);
        }

        // POST: RoleTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Role")] RoleTb roleTb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleTb);
        }

        // GET: RoleTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleTb roleTb = db.RoleTbs.Find(id);
            if (roleTb == null)
            {
                return HttpNotFound();
            }
            return View(roleTb);
        }

        // POST: RoleTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleTb roleTb = db.RoleTbs.Find(id);
            db.RoleTbs.Remove(roleTb);
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
