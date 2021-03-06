﻿using MVC5.BLL.Models;
using MVC5.DAL.Repositories;
using MVC5.DAL.Repositories.Interfaces;
using System.Data;
using System.Net;
using System.Web.Mvc;
//using Linq;

namespace MVC5.Controllers
{
    public class ItemController : Controller
    {

        // It works
        //private readonly IItemRepository db = new ItemRepositoryInMemoryData();
        private readonly IItemRepository db = new ItemRepository();

        
        // GET: Catalogue
        public ActionResult Index()
        {
            var items = db.GetItems();
            return View(items);
        }


        // GET: Catalogue/Details/5
        public ActionResult Details(int id)
        {
            var item = db.GetItemById(id);
            return View(item);
        }


        // GET: Catalogue/Create
        public ActionResult Create()
        {
            return View(new Item());
        }

        // POST: Catalogue/Create
        [HttpPost]
        public ActionResult Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.InsertItem(item);
                }

                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(item);
        }

        // GET: Catalogue/Edit/5
        public ActionResult Edit(int? id)
        {
            var item = db.GetItemById(id);
            return View(item);
        }

        // POST: Catalogue/Edit/5
        [HttpPost]
        public ActionResult Edit(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.UpdateItem(item);
                }
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes");
                return View(item);
            }
        }

        // GET: Catalogue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var item = db.GetItemById(id);

            if (item == null)
                return HttpNotFound();

            return View(item);

        }

        // POST: Catalogue/Delete/5
        [HttpPost]
        public ActionResult Delete(Item iitem)
        {
            try
            {
                //var item = _itemRepository.GetItemByID(id);
                db.DeleteItem(iitem);
                //_itemRepository.Save();
            }

            catch (DataException)
            {
                return RedirectToAction("Delete", new System.Web.Routing.RouteValueDictionary {
                    { "id", iitem.Id },
                    { "saveChangesError", true }
                });
            }

            return RedirectToAction("Index");
        }

        //private bool VerifyId(int? id)
        //{
        //    if (id == null)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    //var item = db.GetItemById(id);

        //    //if (item == null)
        //    //    return HttpNotFound();
        //}
    }
}
