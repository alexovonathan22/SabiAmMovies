using SabiAmMovies.WebAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabiAmMovies.WebAPI.Domain.DataModels
{

    // Base Class for TPT Inheritance for movies
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public int MaxAge { get; set; }
        public string YearOfRelease { get; set; }
        public decimal BasePrice { get; set; } // when creating a movie this price is set
        public decimal Rate { get; set; }
        public string CurrencyUnit { get; set; }
    }
}
