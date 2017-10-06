using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTimes_MVC.Models
{
    public class Times
    {
        [Display(Name = "ID")]
        public int TimeId { get; set; }

        [Required(ErrorMessage = "Digite o time")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Informe o estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe as cores do time")]
        public string Cores { get; set; }
    }
}