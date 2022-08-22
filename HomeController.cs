using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NETMVCAssignment2.Models;
using System.Net;
using System.Runtime.Serialization;
using System.Data.Entity;

namespace ASP.NETMVCAssignment2.Controllers
{
    public class HomeController : Controller
    {
        MYBUSEntities1 db = new MYBUSEntities1();

        // GET: Bus
        public ActionResult Index()
        {

            return View(db.BusInfoes.ToList());
        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusID,BoardingPoint,TravelDate,Amount,Rating")] BusInfo busInfo)
        {
            if (ModelState.IsValid)
            {
                db.BusInfoes.Add(busInfo);
                try
                {
                    db.SaveChanges();

                }
                catch (DbEntityValidationException e)
                {
                    System.Console.WriteLine(e);
                }
                return RedirectToAction("Index");
            }

            return View(busInfo);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo busInfo = db.BusInfoes.Find(id);
            if (busInfo == null)
            {
                return HttpNotFound();
            }
            return View(busInfo);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo busInfo = db.BusInfoes.Find(id);
            if (busInfo == null)
            {
                return HttpNotFound();
            }
            return View(busInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusID,BoardingPoint,TravelDate,Amount,Rating")] BusInfo busInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busInfo);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo busInfo = db.BusInfoes.Find(id);
            if (busInfo == null)
            {
                return HttpNotFound();
            }
            return View(busInfo);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusInfo busInfo = db.BusInfoes.Find(id);
            db.BusInfoes.Remove(busInfo);
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

    [Serializable]
    internal class DbEntityValidationException : Exception
    {
        public DbEntityValidationException()
        {
        }

        public DbEntityValidationException(string message) : base(message)
        {
        }

        public DbEntityValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DbEntityValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
}