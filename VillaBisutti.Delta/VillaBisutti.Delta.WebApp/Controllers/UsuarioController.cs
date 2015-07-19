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
    public class UsuarioController : Controller
    {
        // GET: /Usuario/
        public ActionResult Index()
        {
			ViewBag.Perfis = new SelectList(Util.TiposAcesso, "Key", "Value");
			return View(new data.Usuario().GetCollection(0));
        }

		// POST: /Usuario/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		public ActionResult Create()
		{
			ViewBag.Perfis = Util.TiposAcesso;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ItemCreated([Bind(Include = "Id,Nome,Email,Senha,Perfil")] model.Usuario usuario)
		{
			if (ModelState.IsValid)
			{
				new data.Usuario().Insert(usuario);
				return RedirectToAction("Index", "Usuario");
			}
			return View(usuario);
		}

		public ActionResult ListPerfil()
		{
			ViewBag.Perfis = Util.TiposAcesso;
			return View();

		}

        // GET: /Usuario/Details/5
		//public ActionResult Details(int? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	Usuario usuario = db.Usuario.Find(id);
		//	if (usuario == null)
		//	{
		//		return HttpNotFound();
		//	}
		//	return View(usuario);
		//}

		//// GET: /Usuario/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		

		//	return View(usuario);
		//}

		//// GET: /Usuario/Edit/5
		//public ActionResult Edit(int? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	Usuario usuario = db.Usuario.Find(id);
		//	if (usuario == null)
		//	{
		//		return HttpNotFound();
		//	}
		//	return View(usuario);
		//}

		//// POST: /Usuario/Edit/5
		//// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		//// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit([Bind(Include="Id,Nome,Email,Senha")] Usuario usuario)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		db.Entry(usuario).State = EntityState.Modified;
		//		db.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	return View(usuario);
		//}

		//// GET: /Usuario/Delete/5
		//public ActionResult Delete(int? id)
		//{
		//	if (id == null)
		//	{
		//		return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
		//	}
		//	Usuario usuario = db.Usuario.Find(id);
		//	if (usuario == null)
		//	{
		//		return HttpNotFound();
		//	}
		//	return View(usuario);
		//}

		//// POST: /Usuario/Delete/5
		//[HttpPost, ActionName("Delete")]
		//[ValidateAntiForgeryToken]
		//public ActionResult DeleteConfirmed(int id)
		//{
		//	Usuario usuario = db.Usuario.Find(id);
		//	db.Usuario.Remove(usuario);
		//	db.SaveChanges();
		//	return RedirectToAction("Index");
		//}

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		db.Dispose();
		//	}
		//	base.Dispose(disposing);
		//}
    }
}