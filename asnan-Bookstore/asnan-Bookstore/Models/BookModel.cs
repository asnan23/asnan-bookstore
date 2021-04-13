using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using asnan_Bookstore.Helpers;
using Microsoft.AspNetCore.Http;

namespace asnan_Bookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the Title of your book")]
        //[MyCustomValidation("mvc")]
        public string Title { get; set; }
        
        public string Description { get;set; }
        [StringLength(500, MinimumLength = 5)]
        public string Author { get; set; }
        public string Category { get; set; }
        [Display(Name ="Total pages of book")]
        [Required(ErrorMessage = "Please enter the Total Page")]
        public int? TotalPage { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile ConvertPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        [Display(Name = "Choose the galery photo of your book")]
        [Required]
        public IFormFileCollection GaleryFiles { get; set; }
        public List<GaleryModel> Galery { get; set; }

        [Display(Name = "Upload you book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}
