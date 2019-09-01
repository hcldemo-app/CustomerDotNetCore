using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GICMicro.Models;
using Microsoft.EntityFrameworkCore;

namespace GICMicro.Controllers
{
    public class CompanyController : Controller
    {
        Models.LmsDbMyHclContext db = new Models.LmsDbMyHclContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.CompanyId.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CompanyId companyID = db.CompanyId.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("CompanyId,CustomerCode,CompanyName,ContactName,ContactTitle,Address,City,RegionState,PostalCode,Country,PhoneNumber")] CompanyId companyID)
        {
            if (ModelState.IsValid)
            {
                db.CompanyId.Add(companyID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyID);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return  BadRequest();
            }
            CompanyId companyID = db.CompanyId.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("CompanyID1,CustomerCode,CompanyName,ContactName,ContactTitle,Address,City,RegionState,PostalCode,Country,PhoneNumber")] CompanyId companyID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyID);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CompanyId companyID = db.CompanyId.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }
            return View(companyID);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyId companyID = db.CompanyId.Find(id);
            db.CompanyId.Remove(companyID);
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
