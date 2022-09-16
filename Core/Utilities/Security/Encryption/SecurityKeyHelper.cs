using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //WebAPI/appsetting.json'daki "SecurityKey": "mysupersecretkeymysupersecretkey" biz burda bunu byte [] array'e cevirerek veriyoruz.
        //Çünki asp.net JWT un anlayabileceği format byte[] array'dir.
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
