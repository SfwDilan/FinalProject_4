using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        //.NET'te Extensions yazarken hem class'ın hem de içindeki metotların static olması gerek.
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));  //JwtHelper sınıfında bu satırdaki kodla yapabilirdik ama uzatmadan kısaca yapmak için daha güzel bir yoldur extension ...claims.AddEmail
        }

        public static void AddName(this ICollection<Claim> claims, string name) //this ICollection<Claim> ::net'in bu nesnesine git ve AddName adlı metotu ekle demek.
        {
            claims.Add(new Claim(ClaimTypes.Name, name)); //bunu yazmak yerine claims.AddName diyebilirsin
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier)); //bunu yazmak yerine claims.AddNameIdentifier 
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role))); //claims.AddRole
        }
    }
}
