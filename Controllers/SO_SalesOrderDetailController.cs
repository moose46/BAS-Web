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
    public class SO_SalesOrderDetailController : Controller
    {
        private babblefishEntities db = new babblefishEntities();

        // GET: SO_SalesOrderDetail
        public ActionResult Index()
        {
            return View(db.Database.SqlQuery<SO_SalesOrderDetail>("GetAllRepeatingSalesOrders").Take(24).ToList());
            //return View(db.Database.SqlQuery<SO_SalesOrderDetail>("select * from SO_SalesOrderDetail WHERE  OrderType = 'R' AND soh.DateCreated >= DATEADD(YEAR, -1, GETDATE())").ToList());
            //return View(db.SO_SalesOrderDetail.ToList());
        }
        [HttpPost]
        public ActionResult Index(string itemCode)
        {
            return View(db.Database.SqlQuery<SO_SalesOrderDetail>("GetAllRepeatingSalesOrdersByItemCode " + itemCode.ToUpper() ));
            //return View(db.Database.SqlQuery<SO_SalesOrderDetail>("select * from SO_SalesOrderDetail WHERE  OrderType = 'R' AND soh.DateCreated >= DATEADD(YEAR, -1, GETDATE())").ToList());
            //return View(db.SO_SalesOrderDetail.ToList());
        }

        // GET: SO_SalesOrderDetail/Details/5
        public ActionResult Details(string SalesOrderNo, string LineKey)
        {
            if (SalesOrderNo == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SO_SalesOrderDetail sO_SalesOrderDetail = db.SO_SalesOrderDetail.Find(SalesOrderNo, LineKey);
            if (sO_SalesOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(sO_SalesOrderDetail);
        }

        // GET: SO_SalesOrderDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SO_SalesOrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesOrderNo,LineKey,LineSeqNo,ItemCode,ItemType,ItemCodeDesc,ExtendedDescriptionKey,Discount,Commissionable,SubjectToExemption,WarehouseCode,PriceLevel,MasterOrderLineKey,UnitOfMeasure,DropShip,PrintDropShipment,SalesKitLineKey,CostOfGoodsSoldAcctKey,SalesAcctKey,PriceOverridden,ExplodedKitItem,StandardKitBill,Revision,BillOption1,BillOption2,BillOption3,BillOption4,BillOption5,BillOption6,BillOption7,BillOption8,BillOption9,BackorderKitCompLine,SkipPrintCompLine,PromiseDate,AliasItemNo,SOHistoryDetlSeqNo,TaxClass,CustomerAction,ItemAction,WarrantyCode,ExpirationDate,ExpirationOverridden,CostOverridden,CostCode,CostType,CommentText,QuantityOrdered,QuantityShipped,QuantityBackordered,MasterOriginalQty,MasterQtyBalance,MasterQtyOrderedToDate,RepeatingQtyShippedToDate,UnitPrice,UnitCost,ExtensionAmt,UnitOfMeasureConvFactor,QuantityPerBill,LineDiscountPercent,Valuation,LotSerialFullyDistributed,APDivisionNo,VendorNo,PurchaseOrderNo,PurchaseOrderRequiredDate,LineWeight,CommodityCode,AlternateTaxIdentifier,TaxTypeApplied,NetGrossIndicator,DebitCreditIndicator,TaxAmt,TaxRate")] SO_SalesOrderDetail sO_SalesOrderDetail)
        {
            if (ModelState.IsValid)
            {
                db.SO_SalesOrderDetail.Add(sO_SalesOrderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sO_SalesOrderDetail);
        }

        // GET: SO_SalesOrderDetail/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SO_SalesOrderDetail sO_SalesOrderDetail = db.SO_SalesOrderDetail.Find(id);
            if (sO_SalesOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(sO_SalesOrderDetail);
        }

        // POST: SO_SalesOrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesOrderNo,LineKey,LineSeqNo,ItemCode,ItemType,ItemCodeDesc,ExtendedDescriptionKey,Discount,Commissionable,SubjectToExemption,WarehouseCode,PriceLevel,MasterOrderLineKey,UnitOfMeasure,DropShip,PrintDropShipment,SalesKitLineKey,CostOfGoodsSoldAcctKey,SalesAcctKey,PriceOverridden,ExplodedKitItem,StandardKitBill,Revision,BillOption1,BillOption2,BillOption3,BillOption4,BillOption5,BillOption6,BillOption7,BillOption8,BillOption9,BackorderKitCompLine,SkipPrintCompLine,PromiseDate,AliasItemNo,SOHistoryDetlSeqNo,TaxClass,CustomerAction,ItemAction,WarrantyCode,ExpirationDate,ExpirationOverridden,CostOverridden,CostCode,CostType,CommentText,QuantityOrdered,QuantityShipped,QuantityBackordered,MasterOriginalQty,MasterQtyBalance,MasterQtyOrderedToDate,RepeatingQtyShippedToDate,UnitPrice,UnitCost,ExtensionAmt,UnitOfMeasureConvFactor,QuantityPerBill,LineDiscountPercent,Valuation,LotSerialFullyDistributed,APDivisionNo,VendorNo,PurchaseOrderNo,PurchaseOrderRequiredDate,LineWeight,CommodityCode,AlternateTaxIdentifier,TaxTypeApplied,NetGrossIndicator,DebitCreditIndicator,TaxAmt,TaxRate")] SO_SalesOrderDetail sO_SalesOrderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sO_SalesOrderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sO_SalesOrderDetail);
        }

        // GET: SO_SalesOrderDetail/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SO_SalesOrderDetail sO_SalesOrderDetail = db.SO_SalesOrderDetail.Find(id);
            if (sO_SalesOrderDetail == null)
            {
                return HttpNotFound();
            }
            return View(sO_SalesOrderDetail);
        }

        // POST: SO_SalesOrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SO_SalesOrderDetail sO_SalesOrderDetail = db.SO_SalesOrderDetail.Find(id);
            db.SO_SalesOrderDetail.Remove(sO_SalesOrderDetail);
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
