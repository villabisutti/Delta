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
    public class ItemDecoracaoCerimonialController : Controller
    {
		public ActionResult Buscar(int combo, string texto)
		{
			return View(new data.ItemDecoracaoCerimonial().Filtrar(combo, texto));
		}
		// GET: /ItemDecoracao/
		public ActionResult Index()
		{
			return View();
		}

		// GET: /ItemDecoracao/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemDecoracaoCerimonial itemdecoracaocerimonial = new data.ItemDecoracaoCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (itemdecoracaocerimonial == null)
			{
				return HttpNotFound();
			}
			return View(itemdecoracaocerimonial);
		}

		// GET: /ItemDecoracao/Create
		public ActionResult Create()
		{
			SelectList TipoItemDecoracaoCerimonial = new SelectList(new data.TipoItemDecoracaoCerimonial().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.TipoItemDecoracaoCerimonial = TipoItemDecoracaoCerimonial;
			return View();
		}

		// POST: /ItemDecoracao/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,Quantidade,TipoItemDecoracaoCerimonialId")] model.ItemDecoracaoCerimonial itemdecoracaocerimonial)
		{
			if (ModelState.IsValid)
			{
				new data.ItemDecoracaoCerimonial().Insert(itemdecoracaocerimonial);
				return RedirectToAction("Index");
			}

			return View(itemdecoracaocerimonial);
		}

		// GET: /ItemDecoracao/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemDecoracaoCerimonial itemdecoracaocerimonial = new data.ItemDecoracaoCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (itemdecoracaocerimonial == null)
			{
				return HttpNotFound();
			}
			SelectList TipoItemDecoracaoCerimonial = new SelectList(new data.TipoItemDecoracaoCerimonial().GetCollection(0).OrderBy(tid => tid.Nome), "Id", "Nome");
			ViewBag.TipoItemDecoracaoCerimonial = TipoItemDecoracaoCerimonial;
			return View(itemdecoracaocerimonial);
		}

		// POST: /ItemDecoracao/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Id,Nome,Quantidade,TipoItemDecoracaoCerimonialId")] model.ItemDecoracaoCerimonial itemdecoracaocerimonial)
		{
			if (ModelState.IsValid)
			{
				new data.ItemDecoracaoCerimonial().Update(itemdecoracaocerimonial);
				return RedirectToAction("Index");
			}
			return View(itemdecoracaocerimonial);
		}

		// GET: /ItemDecoracao/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			model.ItemDecoracaoCerimonial itemdecoracaocerimonial = new data.ItemDecoracaoCerimonial().GetElement(id.HasValue ? id.Value : 0);
			if (itemdecoracaocerimonial == null)
			{
				return HttpNotFound();
			}
			return View(itemdecoracaocerimonial);
		}

		// POST: /ItemDecoracao/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			new data.ItemDecoracaoCerimonial().Delete(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}
	}
}