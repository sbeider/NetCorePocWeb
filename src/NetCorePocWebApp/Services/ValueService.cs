using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using NetCorePocWebApp.Controllers;
using NetCorePocWebApp.Settings;

namespace NetCorePocWebApp.Services
{
    public class ValueService : IValueService
    {
        private readonly ApiSettings _apiSettings;
               

        public ValueService(IOptions<ApiSettings> options)
        {
            _apiSettings = options.Value;
        }
        public ApiSettings Get() => _apiSettings;      
         
    }
}
