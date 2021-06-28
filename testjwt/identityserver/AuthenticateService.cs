using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testjwt.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace testjwt.identityserver
{

    public class AuthenticateService : IAuthenticateService
    {
        public readonly tokenModel _jwtModel;
        public AuthenticateService(IOptions<tokenModel> jwtModel) {
            _jwtModel = jwtModel.Value;
        }
        public bool IsAuthenticated(User user, out string token)
        {
            
            token = string.Empty;
           
            var claims = new[] {
                new Claim(ClaimTypes.Name,user.UserName)
            };
            //密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.Secret));
            //凭证
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //生成Token
            var jwtToken = new JwtSecurityToken(_jwtModel.Issuer, _jwtModel.Audience, claims,
                expires: DateTime.Now.AddMinutes(_jwtModel.AccessExpiration),
                signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return true;
        }
    }
}
