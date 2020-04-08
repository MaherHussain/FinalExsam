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
    public class EventsTbsController : Controller
    {
        private FinalEksamenDbEntities db = new FinalEksamenDbEntities();

        // GET: EventsTbs
        public ActionResult Index()
        {
            List<EventsTb> EventSListe = new List<EventsTb>();
            EventSListe = db.EventsTbs.ToList();
            
            
            return View(EventSListe);
            
        }

        // GET: EventsTbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsTb eventsTb = db.EventsTbs.Find(id);
            if (eventsTb == null)
            {
                return HttpNotFound();
            }
            return View(eventsTb);
        }

        // GET: EventsTbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsTbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( EventsTb eventsTb, HttpPostedFileBase EventImg)
        {
            if (ModelState.IsValid)
            {
                if (EventImg != null)
                {
                    //KortKursesTb Kursimg = new KortKursesTb();
                    Guid FileId = Guid.NewGuid();
                    string[] Ex = { ".jpg", ".png", ".gif" };
                    IOTools.FileUplader("~/Content/EventImg", FileId.ToString(), EventImg, Ex);
                    eventsTb.EventImg = FileId.ToString() + "-" + EventImg.FileName;
                }
                
                db.EventsTbs.Add(eventsTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventsTb);
        }

        // GET: EventsTbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsTb eventsTb = db.EventsTbs.Find(id);
            if (eventsTb == null)
            {
                return HttpNotFound();
            }
            return View(eventsTb);
        }

        // POST: EventsTbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( EventsTb eventsTb, HttpPostedFileBase EventImg, int? Id)
        {
            if (ModelState.IsValid)
            {
                if (EventImg != null)
                {
                    IOTools.DelFile("~/Content/EventImg/" + eventsTb.EventImg);
                    //KortKursesTb Kursimg = new KortKursesTb();
                    Guid FileId = Guid.NewGuid();
                    string[] Ex = { ".jpg", ".png", ".gif" };
                    IOTools.FileUplader("~/Content/EventImg", FileId.ToString(), EventImg, Ex);
                    eventsTb.EventImg = FileId.ToString() + "-" + EventImg.FileName;
                }
                else
                {
                    EventsTb OldImg = db.EventsTbs.Find(Id);
                    eventsTb.EventImg = OldImg.EventImg; 
                }
                db.EventsTbs.AddOrUpdate(eventsTb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventsTb);
        }

        // GET: EventsTbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventsTb eventsTb = db.EventsTbs.Find(id);
            if (eventsTb == null)
            {
                return HttpNotFound();
            }
            return View(eventsTb);
        }

        // POST: EventsTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventsTb eventsTb = db.EventsTbs.Find(id);
            db.EventsTbs.Remove(eventsTb);
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
