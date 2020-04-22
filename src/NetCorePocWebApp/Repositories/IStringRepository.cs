using System;
using System.Collections.Generic;

namespace NetCorePocWebApp.Repositories
{
    public interface IStringRepository
    {
        List<string> GetResponse();
    }
}