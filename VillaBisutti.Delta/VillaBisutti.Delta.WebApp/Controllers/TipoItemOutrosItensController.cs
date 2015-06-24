﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using model = VillaBisutti.Delta.Core.Model;
using data = VillaBisutti.Delta.Core.Data;

namespace VillaBisutti.Delta.WebApp.Controllers
{
    public class TipoItemOutrosItensController : Controller
    {

        // GET: /TipoItemOutrosItens/
        public ActionResult Index()
        {
			return View(new data.TipoItemOutroItemItemDiverso().GetCollection(0));
        }

        // GET: /TipoItemOutrosItens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemOutrosItens tipoitemoutrositens = new data.TipoItemOutroItemItemDiverso().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemoutrositens);
        }

        // GET: /TipoItemOutrosItens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemOutrosItens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nome")] model.TipoItemOutrosItens tipoitemoutrositens)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemOutroItemItemDiverso().Insert(tipoitemoutrositens);
                return RedirectToAction("Index");
            }

            return View(tipoitemoutrositens);
        }

        // GET: /TipoItemOutrosItens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemOutrosItens tipoitemoutrositens = new data.TipoItemOutroItemItemDiverso().GetElement(id.HasValue ? id.Value : 0);
			if (tipoitemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemoutrositens);
        }

        // POST: /TipoItemOutrosItens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nome")] model.TipoItemOutrosItens tipoitemoutrositens)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemOutroItemItemDiverso().Update(tipoitemoutrositens);
                return RedirectToAction("Index");
            }
            return View(tipoitemoutrositens);
        }

        // GET: /TipoItemOutrosItens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemOutrosItens tipoitemoutrositens = new data.TipoItemOutroItemItemDiverso().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemoutrositens == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemoutrositens);
        }

        // POST: /TipoItemOutrosItens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.TipoItemOutroItemItemDiverso().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}