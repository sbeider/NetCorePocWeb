using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCorePocWebApp.Services
{
    public class DataInfo
    {
        public List<string> Data { get; set; }
        public bool IsFromCache { get; set; }
    }
}
