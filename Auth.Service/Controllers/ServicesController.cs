using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Service.Controllers
{

    [Authorize]
    [Route("[controller]/[action]")]
    public class ServicesController : Controller
    {
        public object Index()
        {
            return new 
            { 
                 Values = "Some Data"
            
            };
        }
    }
}
