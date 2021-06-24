using System;
using System.Collections.Generic;
using System.Text;

namespace SabiAmMovies.WebAPI.Domain.Constants
{
    public static class UserConstants
    {
        public static string Admin = "AppAdmin";
        public static string User = "AppUser";
    }
    public static class AuthorizedUserTypes
    {
        public const string Admin = "AuthorizedAdmin";
        public const string Users = "AuthorizedUsers";
        public const string UserAndAdmin = "AuthorizedUserAdmin";
    }
}
