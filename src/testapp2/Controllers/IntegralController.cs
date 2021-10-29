using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapp2.Services;
using testapp2.Models;

namespace testapp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegralController : ControllerBase
    {
        [HttpPost]
        public IntegralOutput Post([FromBody]IntegralInput integralInput)
        {
            IntegralService integralService = new IntegralService();
            return integralService.Calculate(integralInput);
        }
    }
}
