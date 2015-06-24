﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VillaBisutti.Delta.Core.Model;
using VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class CardapioController : Controller
    {
        private Context db = new Context();

        // GET: /Cardapio/
        public ActionResult Index()
        {
            return View(db.Cardapio.ToList());
        }

        // GET: /Cardapio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cardapio cardapio = db.Cardapio.Find(id);
            if (cardapio == null)
            {
                return HttpNotFound();
            }
            return View(cardapio);
        }

        // GET: /Cardapio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Cardapio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                db.Cardapio.Add(cardapio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cardapio);
        }

        // GET: /Cardapio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cardapio cardapio = db.Cardapio.Find(id);
            if (cardapio == null)
            {
                return HttpNotFound();
            }
            return View(cardapio);
        }

        // POST: /Cardapio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardapio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cardapio);
        }

        // GET: /Cardapio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cardapio cardapio = db.Cardapio.Find(id);
            if (cardapio == null)
            {
                return HttpNotFound();
            }
            return View(cardapio);
        }

        // POST: /Cardapio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cardapio cardapio = db.Cardapio.Find(id);
            db.Cardapio.Remove(cardapio);
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
