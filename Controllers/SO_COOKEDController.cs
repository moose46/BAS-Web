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
    public class SO_COOKEDController : Controller
    {
        private babblefishEntities db = new babblefishEntities();

        // GET: SO_COOKED
        public ActionResult Index()
        {

           // return View(db.Database.SqlQuery<SO_COOKED>("select top (10) * from so_cooked").ToList());

            return View(db.SO_COOKED.ToList().Take(100));
        }

        // GET: SO_COOKED/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SO_COOKED sO_COOKED = db.SO_COOKED.Find(id);
            if (sO_COOKED == null)
            {
                return HttpNotFound();
            }
            return View(sO_COOKED);
        }

        // GET: SO_COOKED/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SO_COOKED/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "externalid,tranId,Customer,trandate,orderstatus,startdate,enddate,otherrefnum,memo,salesrep,opportunity,saleseffectivedate,leadsource,partner,Department,Class,Location,couponcode,promocode,discount_discountItem,discount_discountrate,itemLine_item,xlated_part,final_part,itemLine_quantity,itemLine_serialNumbers,itemLine_units,itemLine_salesPrice,itemLine_amount,itemLine_description,NetSuiteDescription,itemLine_isTaxable,itemLine_priceLevel,itemLine_department,itemLine_class,itemLine_location,itemLine_custom_Field_Name,itemLine_custom_Field_Name1,itemLine_custom_Field_Name2,shipdate,shipcarrier,shipmethod,shipcomplete,shipaddresslist,shipattention,shipaddressee,shipAddr1,shipAddr2,shipCity,shipState,shipZip,shipCountry,shipPhone,terms,billattention,billAddressee,billAddr1,billAddr2,billCity,billState,billZip,billCountry,billPhone,currency,exchangerate,istaxable,taxitem,taxrate,tobeprinted,tobeemailed,email,tobefaxed,fax,customermessage,custbody_nsts_ci_exclude,custom_Field_Name,custom_Field_Name1,custom_Field_Name2,LineSeqNo,Id")] SO_COOKED sO_COOKED)
        {
            if (ModelState.IsValid)
            {
                db.SO_COOKED.Add(sO_COOKED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sO_COOKED);
        }

        // GET: SO_COOKED/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SO_COOKED sO_COOKED = db.SO_COOKED.Find(id);
            if (sO_COOKED == null)
            {
                return HttpNotFound();
            }
            return View(sO_COOKED);
        }

        // POST: SO_COOKED/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "externalid,tranId,Customer,trandate,orderstatus,startdate,enddate,otherrefnum,memo,salesrep,opportunity,saleseffectivedate,leadsource,partner,Department,Class,Location,couponcode,promocode,discount_discountItem,discount_discountrate,itemLine_item,xlated_part,final_part,itemLine_quantity,itemLine_serialNumbers,itemLine_units,itemLine_salesPrice,itemLine_amount,itemLine_description,NetSuiteDescription,itemLine_isTaxable,itemLine_priceLevel,itemLine_department,itemLine_class,itemLine_location,itemLine_custom_Field_Name,itemLine_custom_Field_Name1,itemLine_custom_Field_Name2,shipdate,shipcarrier,shipmethod,shipcomplete,shipaddresslist,shipattention,shipaddressee,shipAddr1,shipAddr2,shipCity,shipState,shipZip,shipCountry,shipPhone,terms,billattention,billAddressee,billAddr1,billAddr2,billCity,billState,billZip,billCountry,billPhone,currency,exchangerate,istaxable,taxitem,taxrate,tobeprinted,tobeemailed,email,tobefaxed,fax,customermessage,custbody_nsts_ci_exclude,custom_Field_Name,custom_Field_Name1,custom_Field_Name2,LineSeqNo,Id")] SO_COOKED sO_COOKED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sO_COOKED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sO_COOKED);
        }

        // GET: SO_COOKED/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SO_COOKED sO_COOKED = db.SO_COOKED.Find(id);
            if (sO_COOKED == null)
            {
                return HttpNotFound();
            }
            return View(sO_COOKED);
        }

        // POST: SO_COOKED/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SO_COOKED sO_COOKED = db.SO_COOKED.Find(id);
            db.SO_COOKED.Remove(sO_COOKED);
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
