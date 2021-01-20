using SerwisSamochodowy.Baza_danych;
using SerwisSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerwisSamochodowy.Controllers
{
    public class SamochodController : Controller
    {
        private Baza_samochodowEntities _samochody_baza;

        public SamochodController()
        {
            _samochody_baza = new Baza_samochodowEntities();
        }

        public ActionResult Dodaj_ogloszenie()
        {
            if (Session["Login"] != null)
            {
                Samochod _samochod = new Samochod();
                _samochod.Kategoria_wybor = (from _kategoria_wybor in _samochody_baza.Kategories
                                             select new SelectListItem()
                                             {
                                                 Text = _kategoria_wybor.Kategoria_nazwa,
                                                 Value = _kategoria_wybor.Kategoria_ID.ToString(),
                                                 Selected = true
                                             });
                return View(_samochod);
            }
            else
            {
                return RedirectToAction("Logowanie", "Konto");
            }
            
        }

        [HttpPost]
        public JsonResult Dodaj_ogloszenie(Samochod _samochod)
        {
            string Nowy_obraz = Guid.NewGuid() + Path.GetExtension(_samochod.Zdjecie.FileName);
            _samochod.Zdjecie.SaveAs(Server.MapPath("~/Obrazy/" + Nowy_obraz));

            Samochody _samochody = new Baza_danych.Samochody();
            _samochody.Zdjecie = "~/Obrazy/" + Nowy_obraz;
            _samochody.Samochod_ID = Guid.NewGuid();
            _samochody.Kategoria_ID = _samochod.Kategoria_ID;
            _samochody.Marka = _samochod.Marka;
            _samochody.Model = _samochod.Model;
            _samochody.Kolor = _samochod.Kolor;
            _samochody.Rok_produkcji = _samochod.Rok_produkcji;
            _samochody.Przebieg = _samochod.Przebieg;
            _samochody.Rodzaj_paliwa = _samochod.Rodzaj_paliwa;
            _samochody.Nr_vin = _samochod.Nr_vin;
            _samochody.Cena = _samochod.Cena;
            _samochody.Nr_kontaktowy = _samochod.Nr_kontaktowy;
            _samochody.Opis = _samochod.Opis;
            _samochody_baza.Samochodies.Add(_samochody);
            _samochody_baza.SaveChanges();

            return Json(new { Success = true, Message = "Ogłoszenie zostało dodane"}, JsonRequestBehavior.AllowGet);
        }
    }
}