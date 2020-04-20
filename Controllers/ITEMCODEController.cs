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
    public class ITEMCODEController : Controller
    {
        private babblefishEntities db = new babblefishEntities();

        // GET: ITEMCODE
        public ActionResult Index()
        {
            return View(db.ITEMCODE_MAS_NS.ToList());
        }
        [HttpPost]
        public ActionResult Index(string itemCode)
        {
            return View(db.Database.SqlQuery<ITEMCODE_MAS_NS>("select * from ITEMCODE_MAS_NS where MAS like '" + itemCode.ToUpper() + "%' or Netsuite like '" + itemCode.ToUpper() + "%'").ToList());
        }

        // GET: ITEMCODE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMCODE_MAS_NS iTEMCODE_MAS_NS = db.ITEMCODE_MAS_NS.Find(id);
            if (iTEMCODE_MAS_NS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMCODE_MAS_NS);
        }

        // GET: ITEMCODE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ITEMCODE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAS,NETSUITE,DateCreated,DateUpdated,id")] ITEMCODE_MAS_NS iTEMCODE_MAS_NS)
        {
            if (ModelState.IsValid)
            {
                db.ITEMCODE_MAS_NS.Add(iTEMCODE_MAS_NS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iTEMCODE_MAS_NS);
        }

        // GET: ITEMCODE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMCODE_MAS_NS iTEMCODE_MAS_NS = db.ITEMCODE_MAS_NS.Find(id);
            if (iTEMCODE_MAS_NS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMCODE_MAS_NS);
        }

        // POST: ITEMCODE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAS,NETSUITE,DateCreated,DateUpdated,id")] ITEMCODE_MAS_NS iTEMCODE_MAS_NS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEMCODE_MAS_NS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iTEMCODE_MAS_NS);
        }

        // GET: ITEMCODE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEMCODE_MAS_NS iTEMCODE_MAS_NS = db.ITEMCODE_MAS_NS.Find(id);
            if (iTEMCODE_MAS_NS == null)
            {
                return HttpNotFound();
            }
            return View(iTEMCODE_MAS_NS);
        }

        // POST: ITEMCODE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEMCODE_MAS_NS iTEMCODE_MAS_NS = db.ITEMCODE_MAS_NS.Find(id);
            db.ITEMCODE_MAS_NS.Remove(iTEMCODE_MAS_NS);
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
