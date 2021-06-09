using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new inventario2021_2Entities())
            {
                return View(db.usuariorol.ToList());
            }
        }

        public static string NombreUsuarioRol(int idUsuarioRol)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.usuario.Find(idUsuarioRol).nombre;
            }
        }

        public ActionResult ListarUsuarioRol()
        {
            using (var db = new inventario2021_2Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public static string NombreRol(int idRol)
        {
            using (var db = new inventario2021_2Entities())
            {
                return db.roles.Find(idRol).descripcion;
            }
        }

        public ActionResult ListarRol()
        {
            using (var db = new inventario2021_2Entities())
            {
                return PartialView(db.roles.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(usuariorol usuariorol)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    db.usuariorol.Add(usuariorol);
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

    }
}