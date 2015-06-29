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
    public class TipoItemSomIluminacaoController : Controller
    {

        // GET: /TipoItemSomIluminacao/
        public ActionResult Index()
        {
			return View(new data.TipoItemSomIluminacao().GetCollection(0));
        }

        // GET: /TipoItemSomIluminacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemSomIluminacao tipoitemsomiluminacao = new data.TipoItemSomIluminacao().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemsomiluminacao);
        }

        // GET: /TipoItemSomIluminacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoItemSomIluminacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] model.TipoItemSomIluminacao tipoitemsomiluminacao)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemSomIluminacao().Insert(tipoitemsomiluminacao);
                return RedirectToAction("Index");
            }

            return View(tipoitemsomiluminacao);
        }

        // GET: /TipoItemSomIluminacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemSomIluminacao tipoitemsomiluminacao = new data.TipoItemSomIluminacao().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemsomiluminacao);
        }

        // POST: /TipoItemSomIluminacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,PadraoAniversario,PadraoBarmitzva,PadraoBatmitzva,PadraoCasamento,PadraoCorporativo,PadraoDebutante,PadraoOutro")] model.TipoItemSomIluminacao tipoitemsomiluminacao)
        {
            if (ModelState.IsValid)
            {
				new data.TipoItemSomIluminacao().Update(tipoitemsomiluminacao);
                return RedirectToAction("Index");
            }
            return View(tipoitemsomiluminacao);
        }

        // GET: /TipoItemSomIluminacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			model.TipoItemSomIluminacao tipoitemsomiluminacao = new data.TipoItemSomIluminacao().GetElement(id.HasValue ? id.Value : 0);
            if (tipoitemsomiluminacao == null)
            {
                return HttpNotFound();
            }
            return View(tipoitemsomiluminacao);
        }

        // POST: /TipoItemSomIluminacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			new data.TipoItemSomIluminacao().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
