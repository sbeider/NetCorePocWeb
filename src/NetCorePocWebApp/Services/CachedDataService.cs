using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using NetCorePocWebApp.Repositories;
using NetCorePocWebApp.Settings;

namespace NetCorePocWebApp.Services
{
    public class CachedDataService : ICachedDataService
    {
        private readonly ApiSettings _apiSettings;
        private IMemoryCache _memoryCache;
        private IStringRepository _dataRepository;


        public CachedDataService(IStringRepository dataRepository, IMemoryCache memoryCache)
        {
            _dataRepository = dataRepository;
            _memoryCache = memoryCache;
        }
        public List<string> GetData()
        {
            const string key = "AllValues";
            List<string> data;
            bool found = _memoryCache.TryGetValue(key, out data);
            if (!found)
            {
                data = _dataRepository.GetResponse();
                _memoryCache.Set(key, data, DateTime.UtcNow.AddMinutes(1));
            }
            return data;

           
        }      
        
    }
}
