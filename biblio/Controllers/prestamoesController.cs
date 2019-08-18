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
    public class prestamoesController : Controller
    {
        private libreriaEntities db = new libreriaEntities();

        // GET: prestamoes
        public ActionResult Index()
        {
            var prestamo = db.prestamo.Include(p => p.libro).Include(p => p.usuario);
            return View(prestamo.ToList());
        }

        // GET: prestamoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: prestamoes/Create
        public ActionResult Create()
        {
            ViewBag.idLibro = new SelectList(db.libro, "idlibro", "titulolibro");
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nomusuario");
            return View();
        }

        // POST: prestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idprestamo,idLibro,idusuario,fechaprestamo,fechadevo,ndias,observacion")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.prestamo.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLibro = new SelectList(db.libro, "idlibro", "titulolibro", prestamo.idLibro);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nomusuario", prestamo.idusuario);
            return View(prestamo);
        }

        // GET: prestamoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLibro = new SelectList(db.libro, "idlibro", "titulolibro", prestamo.idLibro);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nomusuario", prestamo.idusuario);
            return View(prestamo);
        }

        // POST: prestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idprestamo,idLibro,idusuario,fechaprestamo,fechadevo,ndias,observacion")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLibro = new SelectList(db.libro, "idlibro", "titulolibro", prestamo.idLibro);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nomusuario", prestamo.idusuario);
            return View(prestamo);
        }

        // GET: prestamoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prestamo prestamo = db.prestamo.Find(id);
            db.prestamo.Remove(prestamo);
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
