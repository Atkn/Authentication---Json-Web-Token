using Auth.Service.Manager.Abstraction;
using Auth.Service.Model.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Service.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IJwtAuthenticationManager _authService;
        public AccountController(IJwtAuthenticationManager _authService)
        {
            this._authService = _authService;
        }
        public IActionResult Index()
        {
            return Json(new { message= "page is showing"});
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] UserCredential credential)
        {
            var token = _authService.Authenticate(credential.UserName, credential.Password);
            if (string.IsNullOrEmpty(token))
                //return Unauthorized(new UnauthorizedObjectResult(null) { StatusCode = 200, Value = ""});
                return Unauthorized();
            return Ok(token);
        }
    }
}
