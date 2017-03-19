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
    public class SessionsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Sessions
        public ActionResult Index()
        {
            var sESSIONS = db.SESSIONS.Include(s => s.ACTIVITy).Include(s => s.CUSTOMER).Include(s => s.ROOM);
            return View(sESSIONS.ToList());
        }

        // GET: Sessions/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESSION sESSION = db.SESSIONS.Find(id);
            if (sESSION == null)
            {
                return HttpNotFound();
            }
            return View(sESSION);
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            ViewBag.ACTIVITY_ID = new SelectList(db.ACTIVITIES, "ACTIVITY_ID", "NAME");
            ViewBag.REF_NO = new SelectList(db.CUSTOMERS, "REF_NO", "NAME");
            ViewBag.ROOM_ID = new SelectList(db.ROOMS, "ROOM_ID", "ROOM_NAME");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SESSION_CODE,START_TIME,ACTIVITY_ID,ROOM_ID,REF_NO")] SESSION sESSION)
        {
            if (ModelState.IsValid)
            {
                db.SESSIONS.Add(sESSION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ACTIVITY_ID = new SelectList(db.ACTIVITIES, "ACTIVITY_ID", "NAME", sESSION.ACTIVITY_ID);
            ViewBag.REF_NO = new SelectList(db.CUSTOMERS, "REF_NO", "NAME", sESSION.REF_NO);
            ViewBag.ROOM_ID = new SelectList(db.ROOMS, "ROOM_ID", "ROOM_NAME", sESSION.ROOM_ID);
            return View(sESSION);
        }

        // GET: Sessions/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESSION sESSION = db.SESSIONS.Find(id);
            if (sESSION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACTIVITY_ID = new SelectList(db.ACTIVITIES, "ACTIVITY_ID", "NAME", sESSION.ACTIVITY_ID);
            ViewBag.REF_NO = new SelectList(db.CUSTOMERS, "REF_NO", "NAME", sESSION.REF_NO);
            ViewBag.ROOM_ID = new SelectList(db.ROOMS, "ROOM_ID", "ROOM_NAME", sESSION.ROOM_ID);
            return View(sESSION);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SESSION_CODE,START_TIME,ACTIVITY_ID,ROOM_ID,REF_NO")] SESSION sESSION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sESSION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ACTIVITY_ID = new SelectList(db.ACTIVITIES, "ACTIVITY_ID", "NAME", sESSION.ACTIVITY_ID);
            ViewBag.REF_NO = new SelectList(db.CUSTOMERS, "REF_NO", "NAME", sESSION.REF_NO);
            ViewBag.ROOM_ID = new SelectList(db.ROOMS, "ROOM_ID", "ROOM_NAME", sESSION.ROOM_ID);
            return View(sESSION);
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SESSION sESSION = db.SESSIONS.Find(id);
            if (sESSION == null)
            {
                return HttpNotFound();
            }
            return View(sESSION);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            SESSION sESSION = db.SESSIONS.Find(id);
            db.SESSIONS.Remove(sESSION);
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
