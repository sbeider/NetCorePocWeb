using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NetCorePocWebApp.Services;
using NetCorePocWebApp.Settings;

namespace NetCorePocWebApp.Controllers
{
    [Route("api/paralleltasks")]
    [ApiController]
    public class ParallelTasksController : ControllerBase
    {
        private ICachedDataService _service;
     
        public ParallelTasksController()
        {                
        }
       

        [HttpGet]
        public async Task<JobInfo> Get()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();


            Task<long> task1 = DoJob(1);       
            Task<long> task2 = DoJob(2);
           

           
            long[] result = await Task.WhenAll(task1, task2);
            stopWatch.Stop();

            return new JobInfo
            {
                ElapsedTimes = result.ToList(),
                OverallElapsedTime = stopWatch.ElapsedMilliseconds
            };

        }

        private async Task<long> DoJob(int jobNumber)
        {
            try
            {


                int elapsed = jobNumber * 2000;
                await Task.Delay(elapsed);

                if (jobNumber == 1)
                {
                    throw new Exception("Exception 1");
                 };

                return elapsed;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Exception details: " + exception.ToString());
                return 0;
            }
        }
    }
}
