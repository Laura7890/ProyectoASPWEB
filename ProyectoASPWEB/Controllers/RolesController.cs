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

    }
}