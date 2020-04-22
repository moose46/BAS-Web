using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class NullBasePriceController : Controller
    {
        private babblefishEntities db = new babblefishEntities();


        // GET: NullBasePrice
        public ActionResult Index()
        {
            //var results = db.Database.SqlQuery<spNetSuiteItemsWithNullBasePrice_Result>("spNetSuiteItemsWithNullBasePrice").ToList();
            return View(db.Database.SqlQuery<spNetSuiteItemsWithNullBasePrice_Result>("spNetSuiteItemsWithNullBasePrice").ToList());
        }

        // GET: NullBasePrice/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NullBasePrice/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NullBasePrice/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NullBasePrice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NullBasePrice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: NullBasePrice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NullBasePrice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
