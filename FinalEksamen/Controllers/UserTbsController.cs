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
    public class UserTbsController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();

        // GET: UserTbs
        public ActionResult Index()
        {
            var userTbs = db.UserTbs.Include(u => u.RoleTb);
            return View(userTbs.ToList());
        }

        // GET: UserTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTb userTb = db.UserTbs.Find(id);
            if (userTb == null)
            {
                return HttpNotFound();
            }
            return View(userTb);
        }

        // GET: UserTbs/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Role = new SelectList(db.RoleTbs, "Id", "Role");
            return View();
        }

        // POST: UserTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,Salt,Fk_Role")] UserTb userTb)
        {
            if (ModelState.IsValid)
            {
                string MySalt = Mycrypt.GetRandomSalt();

                userTb.Salt = MySalt;
                userTb.Password = Mycrypt.HashPassword(userTb.Password, MySalt);

                db.UserTbs.Add(userTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Role = new SelectList(db.RoleTbs, "Id", "Role", userTb.Fk_Role);
            return View(userTb);
        }

        // GET: UserTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTb userTb = db.UserTbs.Find(id);
            if (userTb == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Role = new SelectList(db.RoleTbs, "Id", "Role", userTb.Fk_Role);
            return View(userTb);
        }

        // POST: UserTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,Salt,Fk_Role")] UserTb userTb)
        {
            if (ModelState.IsValid)
            {
                string MySalt = Mycrypt.GetRandomSalt();

                userTb.Salt = MySalt;
                userTb.Password = Mycrypt.HashPassword(userTb.Password, MySalt);
                db.Entry(userTb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Role = new SelectList(db.RoleTbs, "Id", "Role", userTb.Fk_Role);
            return View(userTb);
        }

        // GET: UserTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTb userTb = db.UserTbs.Find(id);
            if (userTb == null)
            {
                return HttpNotFound();
            }
            return View(userTb);
        }

        // POST: UserTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTb userTb = db.UserTbs.Find(id);
            db.UserTbs.Remove(userTb);
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
