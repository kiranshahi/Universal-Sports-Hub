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
    public class RoomsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Rooms
        public ActionResult Index()
        {
            return View(db.ROOMS.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM rOOM = db.ROOMS.Find(id);
            if (rOOM == null)
            {
                return HttpNotFound();
            }
            return View(rOOM);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ROOM_ID,ROOM_NAME")] ROOM rOOM)
        {
            if (ModelState.IsValid)
            {
                db.ROOMS.Add(rOOM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rOOM);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM rOOM = db.ROOMS.Find(id);
            if (rOOM == null)
            {
                return HttpNotFound();
            }
            return View(rOOM);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ROOM_ID,ROOM_NAME")] ROOM rOOM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOOM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rOOM);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROOM rOOM = db.ROOMS.Find(id);
            if (rOOM == null)
            {
                return HttpNotFound();
            }
            return View(rOOM);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ROOM rOOM = db.ROOMS.Find(id);
            db.ROOMS.Remove(rOOM);
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
