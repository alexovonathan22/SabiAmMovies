using System;
using System.Collections.Generic;
using System.Text;

namespace SabiAmMovies.WebAPI.Domain.Common
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        // Add what should be common application wide for the database models
    }
}
