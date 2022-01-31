using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFaculdade.Context;
using SistemaFaculdade.Models;

namespace SistemaFaculdade.Controllers
{
    public class Professors1Controller : Controller
    {
        private SistemaFaculdadeDb db = new SistemaFaculdadeDb();

        // GET: Professors1
        public ActionResult Index()
        {
            var professors = db.Professors.Include(p => p.Disciplina);
            return View(professors.ToList());
        }

        // GET: Professors1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professors1/Create
        public ActionResult Create()
        {
            ViewBag.IDDisciplina = new SelectList(db.Disciplinas, "IDDisciplina", "Descricao");
            return View();
        }

        // POST: Professors1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProfessor,Nome,DataNascimento,IDDisciplina,Salario")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDDisciplina = new SelectList(db.Disciplinas, "IDDisciplina", "Descricao", professor.IDDisciplina);
            return View(professor);
        }

        // GET: Professors1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDDisciplina = new SelectList(db.Disciplinas, "IDDisciplina", "Descricao", professor.IDDisciplina);
            return View(professor);
        }

        // POST: Professors1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProfessor,Nome,DataNascimento,IDDisciplina,Salario")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDDisciplina = new SelectList(db.Disciplinas, "IDDisciplina", "Descricao", professor.IDDisciplina);
            return View(professor);
        }

        // GET: Professors1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professors1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
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
