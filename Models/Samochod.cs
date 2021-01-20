using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerwisSamochodowy.Models
{
    public class Samochod
    {
        public Guid Samochod_ID { get; set; }
        public int Kategoria_ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Kolor { get; set; }
        public string Rok_produkcji { get; set; }
        public double Przebieg { get; set; }
        public string Rodzaj_paliwa { get; set; }
        public string Nr_vin { get; set; }
        public double Cena { get; set; }
        public string Nr_kontaktowy { get; set; }
        public string Opis { get; set; }
        public HttpPostedFileBase Zdjecie { get; set; }
        public IEnumerable<SelectListItem> Kategoria_wybor { get; set; }
    }
}