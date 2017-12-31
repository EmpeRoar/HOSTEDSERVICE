using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SERVICEPROVIDER;

namespace HOSTEDSERVICE.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
         
            _personService.AddToDb();
            return new string[] { "value1", "value2" };
        }
    }
}