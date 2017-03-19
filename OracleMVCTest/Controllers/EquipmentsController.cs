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
    public class EquipmentsController : Controller
    {
        private Entities2 db = new Entities2();

        // GET: Equipments
        public ActionResult Index()
        {
            return View(db.EQUIPMENTS.ToList());
        }

        // GET: Equipments/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENTS.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // GET: Equipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EQUIPMENT_ID,EQUIPMENT_NAME,QUANTITY")] EQUIPMENT eQUIPMENT)
        {
            if (ModelState.IsValid)
            {
                db.EQUIPMENTS.Add(eQUIPMENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eQUIPMENT);
        }

        // GET: Equipments/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENTS.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EQUIPMENT_ID,EQUIPMENT_NAME,QUANTITY")] EQUIPMENT eQUIPMENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eQUIPMENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eQUIPMENT);
        }

        // GET: Equipments/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EQUIPMENT eQUIPMENT = db.EQUIPMENTS.Find(id);
            if (eQUIPMENT == null)
            {
                return HttpNotFound();
            }
            return View(eQUIPMENT);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            EQUIPMENT eQUIPMENT = db.EQUIPMENTS.Find(id);
            db.EQUIPMENTS.Remove(eQUIPMENT);
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
