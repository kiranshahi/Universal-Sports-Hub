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
    public class StaffsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Staffs
        public ActionResult Index()
        {
            return View(db.STAFFS.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFS.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STAFF_ID,STAFF_NAME,STAFF_DESIGNATION,STAFF_TYPE")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.STAFFS.Add(sTAFF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTAFF);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFS.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STAFF_ID,STAFF_NAME,STAFF_DESIGNATION,STAFF_TYPE")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTAFF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTAFF);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFS.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            STAFF sTAFF = db.STAFFS.Find(id);
            db.STAFFS.Remove(sTAFF);
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
