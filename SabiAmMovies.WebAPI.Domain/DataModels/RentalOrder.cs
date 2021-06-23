using System;
using System.Collections.Generic;
using System.Text;

namespace SabiAmMovies.WebAPI.Domain.DataModels
{
    public class RentalOrder : Movie
    {
        public int UserId { get; set; }
        public int DaysRented { get; set; }
        public decimal CalculatedPrice { get; set; }
    }
}
