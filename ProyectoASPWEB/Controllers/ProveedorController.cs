using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (var db = new inventario2021_2Entities())
            {
                return View(db.proveedor.ToList());
            }
        }

        public ActionResult Create()

        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021_2Entities())

                {
                    db.proveedor.Add(proveedor);
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
                    proveedor finduser = db.proveedor.Where(a => a.id == id).FirstOrDefault();
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
        public ActionResult Edit(proveedor proveedorEdit)
        {
            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    proveedor user = db.proveedor.Find(proveedorEdit.id);

                    user.nombre = proveedorEdit.nombre;
                    user.direccion = proveedorEdit.direccion;
                    user.telefono = proveedorEdit.telefono;
                    user.nombre_contacto = proveedorEdit.nombre_contacto;


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
                proveedor user = db.proveedor.Find(id);
                return View(user);
            }
        }
    }
}