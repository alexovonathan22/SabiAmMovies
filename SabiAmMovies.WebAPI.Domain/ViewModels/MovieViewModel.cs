using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SabiAmMovies.WebAPI.Domain.ViewModels
{
    public class MovieViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public decimal BasePrice { get; set; } // when creating a movie this price is set
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public string CurrencyUnit { get; set; }
        public int MaxAge { get; set; }
        public string YearOfRelease { get; set; }
    }
}
