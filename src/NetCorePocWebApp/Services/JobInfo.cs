using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCorePocWebApp.Services
{
    public class JobInfo
    {
        public List<long> ElapsedTimes { get; set; }
        public long OverallElapsedTime { get; set; }
    }
}
