using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SerwisSamochodowy.Models
{
    public class Logowanie_konta
    {
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Login { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayName("Hasło")]
        public string Haslo { get; set; }
    }
}