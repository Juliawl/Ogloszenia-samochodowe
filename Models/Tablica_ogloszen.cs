using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SerwisSamochodowy.Models
{
    public class Tablica_ogloszen
    {
        public Guid Samochod_ID { get; set; }
        public string Kategoria_samochodu { get; set; }
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
        public string Zdjecie { get; set; }    

    }
}