using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testjwt.Controllers
{
    [Route("api/[controller]/[action]")]
    public class testController : Controller
    {
        [HttpGet]
        [Authorize]
        public string Index()
        {
            return "恭喜你又学会一个新技能！";
        }
    }
}
