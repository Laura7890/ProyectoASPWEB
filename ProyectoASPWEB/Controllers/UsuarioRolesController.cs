﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoASPWEB.Models;

namespace ProyectoASPWEB.Controllers
{
    public class UsuarioRolesController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new  inventario2021_2Entities())
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
    }
}