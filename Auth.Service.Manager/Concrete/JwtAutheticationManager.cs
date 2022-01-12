using Auth.Service.Manager.Abstraction;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Auth.Service.Manager.Concrete
{
    public class JwtAutheticationManager : IJwtAuthenticationManager
    {
        //add db transaction query
        private readonly IDictionary<string, string> _users = new Dictionary<string, string> {
            {
                "yourUserName","yourPassword"

            },
            {
                "yourUserNameV2","yourPasswordV2"
            }
        };
        private readonly string _key;
        public JwtAutheticationManager(string key)
        {
            _key = key;
        }
        public string Authenticate(string userName, string password)
        {
            if (_users.Any(x => x.Key == userName && x.Value == password))
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {

                        new Claim(ClaimTypes.Name, userName),
                        new Claim(ClaimTypes.Email, "atakan.acarr@outlook.com")
                    }),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }
            return "";
        }
    }
}
