using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NetCorePocWebApp.Services;
using NetCorePocWebApp.Settings;

namespace NetCorePocWebApp.Controllers
{
    [Route("api/cacheddata")]
    [ApiController]
    public class CachedDataController : ControllerBase
    {
        private ICachedDataService _service;
     
        public CachedDataController(ICachedDataService service)
        {
            _service = service;            
        }
       

        [HttpGet]
        public List<string> Get()
        {
            return _service.GetData();
        }
    }
}
