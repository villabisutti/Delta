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
    public class ItemBebidaSelecionadoController : Controller
    {
        // GET: /ItemBebidaSelecionado/
        public ActionResult Index(int id, bool ContratacaoVB, bool FornecimentoVB = false)
        {
			ViewBag.Id = id;
			//var itembebidaselecionado = db.ItemBebidaSelecionado.Include(i => i.ContratoAditivo).Include(i => i.Evento).Include(i => i.ItemBebida);
			//return View(itembebidaselecionado.ToList());
			return View(new data.ItemBebidaSelecionado().GetItensCompartimentados(id, ContratacaoVB, FornecimentoVB));
        }

        // GET: /ItemBebidaSelecionado/Details/5
        public ActionResult Details(int? id)
        {
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//if (itembebidaselecionado == null)
			//{
			//	return HttpNotFound();
			//}
			//return View(itembebidaselecionado);
			return View();
		}

        // GET: /ItemBebidaSelecionado/Create
        public ActionResult Create()
        {
			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo");
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel");
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome");
            return View();
        }

        // POST: /ItemBebidaSelecionado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,EventoId,ContratoAditivoId,ItemBebidaId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,FornecedorStartado,Quantidade,HorarioEntrega,ContatoFornecimento,Observacoes")] model.ItemBebidaSelecionado itembebidaselecionado)
        {
			//if (ModelState.IsValid)
			//{
			//	db.ItemBebidaSelecionado.Add(itembebidaselecionado);
			//	db.SaveChanges();
			//	return RedirectToAction("Index");
			//}

			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo", itembebidaselecionado.ContratoAditivoId);
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itembebidaselecionado.EventoId);
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itembebidaselecionado.ItemBebidaId);
			//return View(itembebidaselecionado);
			return View();
		}

        // GET: /ItemBebidaSelecionado/Edit/5
        public ActionResult Edit(int? id)
        {
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//if (itembebidaselecionado == null)
			//{
			//	return HttpNotFound();
			//}
			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo", itembebidaselecionado.ContratoAditivoId);
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itembebidaselecionado.EventoId);
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itembebidaselecionado.ItemBebidaId);
			//return View(itembebidaselecionado);
			return View();
		}

        // POST: /ItemBebidaSelecionado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,EventoId,ContratoAditivoId,ItemBebidaId,Definido,Contratado,ContratacaoBisutti,FornecimentoBisutti,FornecedorStartado,Quantidade,HorarioEntrega,ContatoFornecimento,Observacoes")] model.ItemBebidaSelecionado itembebidaselecionado)
        {
			//if (ModelState.IsValid)
			//{
			//	db.Entry(itembebidaselecionado).State = EntityState.Modified;
			//	db.SaveChanges();
			//	return RedirectToAction("Index");
			//}
			//ViewBag.ContratoAditivoId = new SelectList(db.ContratoAdivitivo, "Id", "Arquivo", itembebidaselecionado.ContratoAditivoId);
			//ViewBag.EventoId = new SelectList(db.Evento, "Id", "NomeResponsavel", itembebidaselecionado.EventoId);
			//ViewBag.ItemBebidaId = new SelectList(db.ItemBebida, "Id", "Nome", itembebidaselecionado.ItemBebidaId);
			//return View(itembebidaselecionado);
			return View();
		}

        // GET: /ItemBebidaSelecionado/Delete/5
        public ActionResult Delete(int? id)
        {
			//if (id == null)
			//{
			//	return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			//}
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//if (itembebidaselecionado == null)
			//{
			//	return HttpNotFound();
			//}
			//return View(itembebidaselecionado);
			return View();
		}

        // POST: /ItemBebidaSelecionado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			//ItemBebidaSelecionado itembebidaselecionado = db.ItemBebidaSelecionado.Find(id);
			//db.ItemBebidaSelecionado.Remove(itembebidaselecionado);
			//db.SaveChanges();
			//return RedirectToAction("Index");
			return View();
		}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
				//db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}