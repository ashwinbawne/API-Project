//using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class Emp
    {
        public long SerialNo { get; set; }

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public string Dateofbirth { get; set; }


        public string Hobbies { get; set; }

        [Required(ErrorMessage = "Hobbie  is required")]
        public List<string> Hobbie { get; set; }



        public string Gender { get; set; }

        [Required(ErrorMessage = "State is required")]

        public string State { get; set; }


        public int StateID { get; set; }
        public List<SelectListItem> StateData { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        public int CityID { get; set; }

        public List<SelectListItem> CityData { get; set; }
        public string UploadImage { get; set; }

        public string UploadPdf { get; set; }

        public HttpPostedFileBase FormImageFile { get; set; }

        public HttpPostedFileBase FormPdfFile { get; set; }
        public List<Emp> lst { get; set; }
    }
}