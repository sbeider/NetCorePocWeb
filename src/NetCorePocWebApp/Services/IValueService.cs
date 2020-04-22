using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCorePocWebApp.Settings;

namespace NetCorePocWebApp.Services
{
    public interface IValueService
    {
        ApiSettings Get();
    }
}