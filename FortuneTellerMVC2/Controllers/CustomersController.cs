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
    public class CustomersController : Controller
    {
        private FortuneTellerMVC2Entities db = new FortuneTellerMVC2Entities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Birthmonth).Include(c => c.Color);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            else if (customer.Color.ROYGBIV == "red")
            {

                ViewBag.Transporation = "a nice car.";
            }
            else if (customer.Color.ROYGBIV == "orange")
            {
                ViewBag.Transporation = "a jet pack.";
            }
            else if (customer.Color.ROYGBIV == "yellow")
            {
                ViewBag.Transporation = "a submarine";
            }
            else if (customer.Color.ROYGBIV == "green")
            {
                ViewBag.Transporation = "a rickshaw.";
            }
            else if (customer.Color.ROYGBIV == "blue")
            {
                ViewBag.Transporation = "a work van.";
            }
            else if (customer.Color.ROYGBIV == "indigo")
            {
                ViewBag.Transporation = "a private jet.";
            }
            else if (customer.Color.ROYGBIV == "violet")
            {
                ViewBag.Transporation = "a roman chariot.";
            }
            else
            {
                ViewBag.Transporation = "a unicycle.";
            }


            if (customer.Age % 2 == 0)
            {
                ViewBag.Age = 10;
            }

            else
            {
                ViewBag.Age = 40;
            }


            if (customer.Siblings == 0)
            {
                ViewBag.VacationHome = "Japan";
            }

            else if (customer.Siblings == 1)
            {
                ViewBag.VacationHome = "New Zealand";
            }

            else if (customer.Siblings == 2d)
            {
                ViewBag.VacationHome = "Hawaii";
            }

            else if (customer.Siblings == 3d)
            {
                ViewBag.VacationHome = "New York";
            }

            else if (customer.Siblings > 3d)
            {
                ViewBag.VacationHome = "Florida";
            }

            else
            {
                ViewBag.VacationHome = "a back ally";
            }


            if (customer.Birthmonth.BirthMonth1 == "January" || customer.Birthmonth.BirthMonth1== "February" || customer.Birthmonth.BirthMonth1 == "March"|| customer.Birthmonth.BirthMonth1 == "April")
            {
                ViewBag.BirthMonth = 10000;
            }

            else if (customer.Birthmonth.BirthMonth1 == "May" || customer.Birthmonth.BirthMonth1 == "June" || customer.Birthmonth.BirthMonth1 == "July" || customer.Birthmonth.BirthMonth1 == "August")
            {
                ViewBag.BirthMonth = 15000;
            }

            else if (customer.Birthmonth.BirthMonth1 == "September" || customer.Birthmonth.BirthMonth1 == "October" || customer.Birthmonth.BirthMonth1 == "November" || customer.Birthmonth.BirthMonth1 == "December")
            {
                ViewBag.BirthMonth = 200000; 
            }

            else
            {
                ViewBag.BirthMonth = 5;
            }


            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.BirthMonthID = new SelectList(db.Birthmonths, "BirthMonthID", "BirthMonth1");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ROYGBIV");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,BirthMonthID,ColorID,FirstName,LastName,Age,Siblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BirthMonthID = new SelectList(db.Birthmonths, "BirthMonthID", "BirthMonth1", customer.BirthMonthID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ROYGBIV", customer.ColorID);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BirthMonthID = new SelectList(db.Birthmonths, "BirthMonthID", "BirthMonth1", customer.BirthMonthID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ROYGBIV", customer.ColorID);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,BirthMonthID,ColorID,FirstName,LastName,Age,Siblings")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BirthMonthID = new SelectList(db.Birthmonths, "BirthMonthID", "BirthMonth1", customer.BirthMonthID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ROYGBIV", customer.ColorID);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
