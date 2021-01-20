using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerwisSamochodowy.Controllers
{
    public class UzytkownikController : Controller
    {


        public ActionResult Profil()
        {
            if (Session["Login"] != null)
            {
                ViewBag.Login = Session["Login"];
                return View();
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
        }


    }
}