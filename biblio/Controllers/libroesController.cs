using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using biblio.Models;

namespace biblio.Controllers
{
    public class libroesController : Controller
    {
        private libreriaEntities db = new libreriaEntities();

        // GET: libroes
        public ActionResult Index()
        {
            var libro = db.libro.Include(l => l.autor);
            return View(libro.ToList());
        }

        // GET: libroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libro libro = db.libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: libroes/Create
        public ActionResult Create()
        {
            ViewBag.idautor = new SelectList(db.autor, "idautor", "nombreautor");
            return View();
        }

        // POST: libroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlibro,idautor,titulolibro,editorial,pais,año,npag,existencia,fechaingreso")] libro libro)
        {
            if (ModelState.IsValid)
            {
                db.libro.Add(libro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idautor = new SelectList(db.autor, "idautor", "nombreautor", libro.idautor);
            return View(libro);
        }

        // GET: libroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libro libro = db.libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.idautor = new SelectList(db.autor, "idautor", "nombreautor", libro.idautor);
            return View(libro);
        }

        // POST: libroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlibro,idautor,titulolibro,editorial,pais,año,npag,existencia,fechaingreso")] libro libro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idautor = new SelectList(db.autor, "idautor", "nombreautor", libro.idautor);
            return View(libro);
        }

        // GET: libroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            libro libro = db.libro.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            libro libro = db.libro.Find(id);
            db.libro.Remove(libro);
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
