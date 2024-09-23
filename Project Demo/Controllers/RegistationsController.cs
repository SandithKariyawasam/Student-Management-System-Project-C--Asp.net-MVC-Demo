using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Demo.Models;

namespace Project_Demo.Controllers
{
    public class RegistationsController : Controller
    {
        private lindaaEntities db = new lindaaEntities();

        // GET: Registations
        public ActionResult Index()
        {
            var registations = db.registations.Include(r => r.batch).Include(r => r.course);
            return View(registations.ToList());
        }

        // GET: Registations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registations.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // GET: Registations/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1");
            ViewBag.course_id = new SelectList(db.courses, "id", "course1");
            return View();
        }

        // POST: Registations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.registations.Add(registation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "id", "course1", registation.course_id);
            return View(registation);
        }

        // GET: Registations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registations.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "id", "course1", registation.course_id);
            return View(registation);
        }

        // POST: Registations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,firstname,lastname,nic,course_id,batch_id,telno")] registation registation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.batches, "id", "batch1", registation.batch_id);
            ViewBag.course_id = new SelectList(db.courses, "id", "course1", registation.course_id);
            return View(registation);
        }

        // GET: Registations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registation registation = db.registations.Find(id);
            if (registation == null)
            {
                return HttpNotFound();
            }
            return View(registation);
        }

        // POST: Registations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registation registation = db.registations.Find(id);
            db.registations.Remove(registation);
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
