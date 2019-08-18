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
    public class estadousuariosController : Controller
    {
        private libreriaEntities db = new libreriaEntities();

        // GET: estadousuarios
        public ActionResult Index()
        {
            return View(db.estadousuario.ToList());
        }

        // GET: estadousuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadousuario estadousuario = db.estadousuario.Find(id);
            if (estadousuario == null)
            {
                return HttpNotFound();
            }
            return View(estadousuario);
        }

        // GET: estadousuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: estadousuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idestadousuario,estadousuario1")] estadousuario estadousuario)
        {
            if (ModelState.IsValid)
            {
                db.estadousuario.Add(estadousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadousuario);
        }

        // GET: estadousuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadousuario estadousuario = db.estadousuario.Find(id);
            if (estadousuario == null)
            {
                return HttpNotFound();
            }
            return View(estadousuario);
        }

        // POST: estadousuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idestadousuario,estadousuario1")] estadousuario estadousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadousuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadousuario);
        }

        // GET: estadousuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            estadousuario estadousuario = db.estadousuario.Find(id);
            if (estadousuario == null)
            {
                return HttpNotFound();
            }
            return View(estadousuario);
        }

        // POST: estadousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            estadousuario estadousuario = db.estadousuario.Find(id);
            db.estadousuario.Remove(estadousuario);
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
