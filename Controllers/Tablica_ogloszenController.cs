using SerwisSamochodowy.Baza_danych;
using SerwisSamochodowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SerwisSamochodowy.Controllers
{
    public class Tablica_ogloszenController : Controller
    {

        private Baza_samochodowEntities _samochody_baza;
        public Tablica_ogloszenController()
        {
            _samochody_baza = new Baza_samochodowEntities();
        }

        public ActionResult Tablica()
        {
            IEnumerable<Tablica_ogloszen> Tablica_ogloszen_lista = (from _lista_samochody in _samochody_baza.Samochodies
                        join       
                        _lista_kategorie in _samochody_baza.Kategories
                        on _lista_samochody.Kategoria_ID equals _lista_kategorie.Kategoria_ID
                        select new Tablica_ogloszen()
                        {
                            Zdjecie = _lista_samochody.Zdjecie,
                            Kategoria_samochodu = _lista_kategorie.Kategoria_nazwa,
                            Marka = _lista_samochody.Marka,
                            Model = _lista_samochody.Model,
                            Kolor = _lista_samochody.Kolor,
                            Rok_produkcji = _lista_samochody.Rok_produkcji,
                            Przebieg = _lista_samochody.Przebieg,
                            Rodzaj_paliwa = _lista_samochody.Rodzaj_paliwa,
                            Nr_vin = _lista_samochody.Nr_vin,
                            Nr_kontaktowy = _lista_samochody.Nr_kontaktowy,
                            Opis = _lista_samochody.Opis,
                            Cena = _lista_samochody.Cena                        
                        }
                        ).ToList();
            return View(Tablica_ogloszen_lista);
        }
     
    }
}