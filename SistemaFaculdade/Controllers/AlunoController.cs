using SistemaFaculdade.Context;
using SistemaFaculdade.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaFaculdade.Controllers
{
    public class AlunoController : Controller
    {
        private SistemaFaculdadeDb Db = new SistemaFaculdadeDb();

        public object IDAluno { get; private set; }

        // GET: Aluno
        public ActionResult Index()
        {
            return View(Db.Aluno.ToList());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Aluno = Db.Aluno.Find(ID);

            if (Aluno == null)
            {
                return HttpNotFound();
            }

            return View(Aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.IDCurso = new SelectList(Db.Cursoes, "IDCurso", "Descricao");
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDAluno,Nome,DataNascimento,IDCurso,MediaNota")] Aluno Aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Db.Aluno.Add(Aluno);
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IDCurso = new SelectList(Db.Cursoes, "IDCurso", "Descricao", Aluno.IDCurso);
                return View(Aluno);

            }
            catch
            {
                return View(Aluno);
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Aluno = Db.Aluno.Find(ID);
            if (Aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCurso = new SelectList(Db.Cursoes, "IDCurso", "Descricao", Aluno.IDCurso);
            return View(Aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IDAluno,Nome,DataNascimento,IDCurso,MediaNota")]Aluno Aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Db.Entry(Aluno).State = EntityState.Modified;
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IDCurso = new SelectList(Db.Cursoes, "IDCurso", "Descricao", Aluno.IDCurso);
                return View(Aluno);

            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Aluno = Db.Aluno.Find(ID);
            if (Aluno == null)
            {
                return HttpNotFound();
            }

            return View(Aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int ID, Aluno Aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Aluno = Db.Aluno.Find(ID);
                    Db.Aluno.Remove(Aluno);
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }


                return View(Aluno);
            }
            catch
            {
                return View(Aluno);
            }
        }
    }
}
