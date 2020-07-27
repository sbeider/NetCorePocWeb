using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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


            Task<long> task1 = new Task<long>(() => DoJob(1));
            task1.Start();
            Task<long> task2 = new Task<long>(() => DoJob(2));
            task2.Start();


            //long[] result = await Task.WhenAll(task1, task2);
            long elapsed1 = await task1;
            long elapsed2 = await task2;
            stopWatch.Stop();

            return new JobInfo
            {
                ElapsedTimes = new List<long> { elapsed1, elapsed2 },
                OverallElapsedTime = stopWatch.ElapsedMilliseconds
            };

        }

        private long DoJob(int jobNumber)
        {
            try
            {
                int elapsed = jobNumber * 2000;
                Thread.Sleep(elapsed);

                //if (jobNumber < 5)
                //{
                //    throw new Exception($"Exception for job#{jobNumber}");
                //}

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
