using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            using (var db = new inventario2021_2Entities())
            {
                return View(db.roles.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(roles roles)
        {
            if (!ModelState.IsValid)

                return View();

            try
            {
                using (var db = new inventario2021_2Entities())
                {
                    db.roles.Add(roles);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", " error " + ex);
                return View();
            }

        }
    }
}