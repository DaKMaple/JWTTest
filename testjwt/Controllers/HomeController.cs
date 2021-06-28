using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testjwt.identityserver;
using testjwt.Models;

namespace testjwt.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IAuthenticateService _authenservice;
        public HomeController(IAuthenticateService service) {
            _authenservice = service;
        }
        [HttpGet]
        public string GetToken(User user) {
           
            ///正常来说这里应该是链接数据库查询用户名密码是否正确，但是这里我们直接模拟一下测试就可以了
            if (user.UserName != "张三" || user.PWD != "123")
            {
                return "用户名或密码错误";
            }
            //签发token
            string token;
            if (_authenservice.IsAuthenticated(user,out token))
            {
                return token;
            }
            return "用户名或密码错误";
        }
    }
}
