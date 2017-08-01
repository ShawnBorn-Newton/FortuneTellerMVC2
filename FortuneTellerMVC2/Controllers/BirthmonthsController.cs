using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FortuneTellerMVC2.Models;

namespace FortuneTellerMVC2.Controllers
{
    public class BirthmonthsController : Controller
    {
        private FortuneTellerMVC2Entities db = new FortuneTellerMVC2Entities();

        // GET: Birthmonths
        public ActionResult Index()
        {
            return View(db.Birthmonths.ToList());
        }

        // GET: Birthmonths/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birthmonth birthmonth = db.Birthmonths.Find(id);
            if (birthmonth == null)
            {
                return HttpNotFound();
            }
            return View(birthmonth);
        }

        // GET: Birthmonths/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Birthmonths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BirthMonthID,BirthMonth1")] Birthmonth birthmonth)
        {
            if (ModelState.IsValid)
            {
                db.Birthmonths.Add(birthmonth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birthmonth);
        }

        // GET: Birthmonths/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birthmonth birthmonth = db.Birthmonths.Find(id);
            if (birthmonth == null)
            {
                return HttpNotFound();
            }
            return View(birthmonth);
        }

        // POST: Birthmonths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BirthMonthID,BirthMonth1")] Birthmonth birthmonth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birthmonth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birthmonth);
        }

        // GET: Birthmonths/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Birthmonth birthmonth = db.Birthmonths.Find(id);
            if (birthmonth == null)
            {
                return HttpNotFound();
            }
            return View(birthmonth);
        }

        // POST: Birthmonths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birthmonth birthmonth = db.Birthmonths.Find(id);
            db.Birthmonths.Remove(birthmonth);
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
