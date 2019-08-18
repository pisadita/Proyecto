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
    public class View_usuario_estado_libro_prestamoController : Controller
    {
        private libreriaEntities db = new libreriaEntities();

        // GET: View_usuario_estado_libro_prestamo
        public ActionResult Index()
        {
            return View(db.View_usuario_estado_libro_prestamo.ToList());
        }

        // GET: View_usuario_estado_libro_prestamo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_usuario_estado_libro_prestamo view_usuario_estado_libro_prestamo = db.View_usuario_estado_libro_prestamo.Find(id);
            if (view_usuario_estado_libro_prestamo == null)
            {
                return HttpNotFound();
            }
            return View(view_usuario_estado_libro_prestamo);
        }

        // GET: View_usuario_estado_libro_prestamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: View_usuario_estado_libro_prestamo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nomusuario,telusuario,estadousuario,titulolibro,ndias,fechaprestamo,fechadevo,observacion")] View_usuario_estado_libro_prestamo view_usuario_estado_libro_prestamo)
        {
            if (ModelState.IsValid)
            {
                db.View_usuario_estado_libro_prestamo.Add(view_usuario_estado_libro_prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view_usuario_estado_libro_prestamo);
        }

        // GET: View_usuario_estado_libro_prestamo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_usuario_estado_libro_prestamo view_usuario_estado_libro_prestamo = db.View_usuario_estado_libro_prestamo.Find(id);
            if (view_usuario_estado_libro_prestamo == null)
            {
                return HttpNotFound();
            }
            return View(view_usuario_estado_libro_prestamo);
        }

        // POST: View_usuario_estado_libro_prestamo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nomusuario,telusuario,estadousuario,titulolibro,ndias,fechaprestamo,fechadevo,observacion")] View_usuario_estado_libro_prestamo view_usuario_estado_libro_prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(view_usuario_estado_libro_prestamo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(view_usuario_estado_libro_prestamo);
        }

        // GET: View_usuario_estado_libro_prestamo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_usuario_estado_libro_prestamo view_usuario_estado_libro_prestamo = db.View_usuario_estado_libro_prestamo.Find(id);
            if (view_usuario_estado_libro_prestamo == null)
            {
                return HttpNotFound();
            }
            return View(view_usuario_estado_libro_prestamo);
        }

        // POST: View_usuario_estado_libro_prestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            View_usuario_estado_libro_prestamo view_usuario_estado_libro_prestamo = db.View_usuario_estado_libro_prestamo.Find(id);
            db.View_usuario_estado_libro_prestamo.Remove(view_usuario_estado_libro_prestamo);
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
