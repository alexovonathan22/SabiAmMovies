using SabiAmMovies.WebAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SabiAmMovies.WebAPI.Domain.DataModels
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string AuthToken { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public bool IsEmailConfirm { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string OTP { get; set; }
    }
}
