using SerwisSamochodowy.Baza_danych;
using SerwisSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerwisSamochodowy.Controllers
{
    public class KontoController : Controller
    {
        Serwis_samochodowyEntities _konta_baza = new Serwis_samochodowyEntities();
        // GET: Konto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rejestracja()
        {
            Konto _konto = new Konto();
            return View(_konto);
        }

        [HttpPost]
        public ActionResult Rejestracja(Konto _konto)
        {
            if (ModelState.IsValid)
            {
                if (_konta_baza.Konta.Any(m => m.E_mail == _konto.E_mail))
                {
                    ModelState.AddModelError("Error", "Ten e-mail jest już zajęty");
                    return View();
                }

                else if (_konta_baza.Konta.Any(m => m.Login == _konto.Login))
                {
                    ModelState.AddModelError("Error", "Ten login jest już zajęty");
                    return View();
                }

                else
                {
                    Konta _konta = new Baza_danych.Konta();
                    _konta.Imie = _konto.Imie;
                    _konta.Nazwisko = _konto.Nazwisko;
                    _konta.Miasto = _konto.Miasto;
                    _konta.E_mail = _konto.E_mail;
                    _konta.Nr_telefonu = _konto.Nr_telefonu;
                    _konta.Login = _konto.Login;
                    _konta.Haslo = _konto.Haslo;
                    _konta_baza.Konta.Add(_konta);
                    _konta_baza.SaveChanges();
                    _konto = new Konto();
                    return RedirectToAction("Stworzone_konto", "Konto");
                    
                }
            }
            return View(_konto);

        }

        public ActionResult Stworzone_konto()
        {
            return View();
        }

        public ActionResult Logowanie()
        {
            Logowanie_konta _logowanie = new Logowanie_konta();
            return View(_logowanie);
        }

        [HttpPost]
        public ActionResult Logowanie(Logowanie_konta _logowanie)
        {
            if (ModelState.IsValid)
            {
                if (_konta_baza.Konta.Where(m => m.Login == _logowanie.Login && m.Haslo == _logowanie.Haslo).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Wprowadzono błędne dane");
                    return View();
                }
                else
                {
                    Session["Login"] = _logowanie.Login;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Wylogowanie()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}