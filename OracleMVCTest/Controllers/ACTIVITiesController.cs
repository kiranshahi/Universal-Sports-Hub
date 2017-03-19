using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OracleMVCTest.Models;

namespace OracleMVCTest.Controllers
{
    public class ActivitiesController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: ACTIVITies
        public ActionResult Index()
        {
            return View(db.ACTIVITIES.ToList());
        }

        // GET: ACTIVITies/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITy aCTIVITy = db.ACTIVITIES.Find(id);
            if (aCTIVITy == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITy);
        }

        // GET: ACTIVITies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ACTIVITies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ACTIVITY_ID,NAME,PERIOD")] ACTIVITy aCTIVITy)
        {
            if (ModelState.IsValid)
            {
                db.ACTIVITIES.Add(aCTIVITy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTIVITy);
        }

        // GET: ACTIVITies/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITy aCTIVITy = db.ACTIVITIES.Find(id);
            if (aCTIVITy == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITy);
        }

        // POST: ACTIVITies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ACTIVITY_ID,NAME,PERIOD")] ACTIVITy aCTIVITy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTIVITy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTIVITy);
        }

        // GET: ACTIVITies/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTIVITy aCTIVITy = db.ACTIVITIES.Find(id);
            if (aCTIVITy == null)
            {
                return HttpNotFound();
            }
            return View(aCTIVITy);
        }

        // POST: ACTIVITies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ACTIVITy aCTIVITy = db.ACTIVITIES.Find(id);
            db.ACTIVITIES.Remove(aCTIVITy);
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
