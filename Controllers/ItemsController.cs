using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ItemsController : Controller
    {
        private babblefishEntities db = new babblefishEntities();

        // GET: Items
        public ActionResult Index()
        {
            //var result = db.Database.SqlQuery<Item>("select * from items where name like 'HAZ%'").ToList();
            //return View(db.Items.ToList());
            return View(db.Database.SqlQuery<Item>("select Inactive, Name, [Display Name] DISPLAY_NAME, Type, Description, [MAS VENDOR CODE] MAS_VENDOR_CODE,[base price] Base_Price, [external id] external_id, [internal id] internal_id, [purchase price] purchase_price, [vendor code] vendor_code, id from items where name like 'HAZ%'").ToList());
        }
        [HttpPost]
        public ActionResult Index(string itemName)
        {
            return View(db.Database.SqlQuery<Item>("select Inactive, Name, [Display Name] DISPLAY_NAME, Type, Description, [MAS VENDOR CODE] MAS_VENDOR_CODE,[base price] Base_Price, [external id] external_id, [internal id] internal_id, [purchase price] purchase_price, [vendor code] vendor_code, id from items where name like '" + itemName.ToUpper() + "%'").ToList());

        }
        // GET: Items/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Inactive,Name,Display_Name,Vendor,Type,Description,MAS_Vendor_Code,Base_Price,External_ID,Internal_ID,Purchase_Price,Vendor_Code,Id")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Inactive,Name,Display_Name,Vendor,Type,Description,MAS_Vendor_Code,Base_Price,External_ID,Internal_ID,Purchase_Price,Vendor_Code,Id")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
