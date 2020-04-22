using System;
using System.Collections.Generic;

namespace NetCorePocWebApp.Repositories
{
    public class StringRepository : IStringRepository
    {   
        List<string> IStringRepository.GetResponse()
        {
            return new List<string> { "string1", "string2" };
        }
    }
}