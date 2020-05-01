using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blood_Test_Unit.Models;

namespace Blood_Test_Unit.Controllers
{
    public class Blood_SamplesController : Controller
    {
        private BloodUnitEntities db = new BloodUnitEntities();

        // GET: Blood_Samples
        public ActionResult Index()
        {
            return View(db.Blood_Samples.ToList());
        }

        // GET: Blood_Samples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Samples blood_Samples = db.Blood_Samples.Find(id);
            if (blood_Samples == null)
            {
                return HttpNotFound();
            }
            return View(blood_Samples);
        }

        // GET: Blood_Samples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blood_Samples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sampleID,Date,Blood_Samples1,Dna,Turn_Away,Comment")] Blood_Samples blood_Samples)
        {
            if (ModelState.IsValid)
            {
                db.Blood_Samples.Add(blood_Samples);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blood_Samples);
        }

        // GET: Blood_Samples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Samples blood_Samples = db.Blood_Samples.Find(id);
            if (blood_Samples == null)
            {
                return HttpNotFound();
            }
            return View(blood_Samples);
        }

        // POST: Blood_Samples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sampleID,Date,Blood_Samples1,Dna,Turn_Away,Comment")] Blood_Samples blood_Samples)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blood_Samples).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blood_Samples);
        }

        // GET: Blood_Samples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blood_Samples blood_Samples = db.Blood_Samples.Find(id);
            if (blood_Samples == null)
            {
                return HttpNotFound();
            }
            return View(blood_Samples);
        }

        // POST: Blood_Samples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blood_Samples blood_Samples = db.Blood_Samples.Find(id);
            db.Blood_Samples.Remove(blood_Samples);
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
