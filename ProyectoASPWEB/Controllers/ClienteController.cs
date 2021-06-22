using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (var db = new inventario2021_2Entities())
            {
                return View(db.cliente.ToList());
            }
        }

        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021_2Entities())

                {
                    db.cliente.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    cliente finduser = db.cliente.Where(a => a.id == id).FirstOrDefault();
                    return View(finduser);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cliente clienteEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    cliente user = db.cliente.Find(clienteEdit.id);

                    user.nombre = clienteEdit.nombre;
                    user.documento = clienteEdit.documento;
                    user.email = clienteEdit.email;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021_2Entities())
            {
                cliente user = db.cliente.Find(id);
                return View(user);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021_2Entities())
            {
                var cliente = db.cliente.Find(id);
                db.cliente.Remove(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Hola()
        {
            return View(User);
        }
    }
}