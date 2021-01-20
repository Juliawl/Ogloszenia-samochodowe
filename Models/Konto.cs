using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerwisSamochodowy.Models
{
    public class Konto
    {
        public int Konto_ID { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayName("Imię")]
        public string Imie { get; set; }
        
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Miasto { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayName("E-mail")]
        public string E_mail { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayName("Nr telefonu")]
        public string Nr_telefonu { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Login { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayName("Hasło")]
        public string Haslo { get; set; }
    }
}