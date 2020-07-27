using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NetCorePocWebApp.Settings;

namespace NetCorePocWebApp.Services
{
    public interface ICachedDataService
    {
        DataInfo GetData();
    }
}