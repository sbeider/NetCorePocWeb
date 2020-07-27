using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using NetCorePocWebApp.Repositories;
using NetCorePocWebApp.Services;

namespace Tests
{
    public class Tests
    {
       

        [SetUp]
        public void Setup()
        {
         
            
        }

        [Test]
        public void GetData_Returns_Data_When_Data_Is_In_Cache()
        {
            var mockRepository = new Mock<IStringRepository>();
            var mockMemoryCache = CreateMockMemoryCache(new List<string> { "testOne", "testTwo" });
            var service = new CachedDataService(mockRepository.Object, mockMemoryCache.Object);

            Assert.IsNotNull(mockMemoryCache.Object.Get("AllValues"));

            var data = service.GetData();
            //mock repository is NOT set up, but the mock cache is set up, so if we get the data, we know that the cache was used
            Assert.AreEqual("testOne", data.Data[0]);
            Assert.AreEqual("testTwo", data.Data[1]);
            Assert.IsTrue(data.IsFromCache);

        }

        [Test]
        public void GetData_Returns_Data_When_Data_Is_Not_In_Cache()
        {
            var mockRepository = new Mock<IStringRepository>();
            mockRepository.Setup(r => r.GetResponse()).Returns(new List<string> { "testOne", "testTwo" });

            var mockMemoryCache = CreateMockMemoryCache();
            var service = new CachedDataService(mockRepository.Object, mockMemoryCache.Object);

            Assert.IsNull(mockMemoryCache.Object.Get("AllValues"));

            //mock repository is set up, but the mock cache is NOT set up, so if we get the data, we know that the cache was used
            var data = service.GetData();
            Assert.AreEqual("testOne", data.Data[0]);
            Assert.AreEqual("testTwo", data.Data[1]);
            Assert.IsFalse(data.IsFromCache);

        }

        private Mock<IMemoryCache> CreateMockMemoryCache(object expectedValue)
        {
            var mockMemoryCache = new Mock<IMemoryCache>();

            //TryGetValue is a method called by IMemoryCache.Get()
            mockMemoryCache.Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue)).Returns(true);
            return mockMemoryCache;
        }

        private Mock<IMemoryCache> CreateMockMemoryCache()
        {
            var mockMemoryCache = new Mock<IMemoryCache>();
            object expectedValue;
            mockMemoryCache.Setup(x => x.TryGetValue(It.IsAny<object>(), out expectedValue)).Returns(false);

            //CreateEntry is a method called by IMemoryCache.Set()
            var cacheEntry = new Mock<ICacheEntry>();
            mockMemoryCache.Setup(m => m.CreateEntry(It.IsAny<object>())).Returns(cacheEntry.Object);
            
            return mockMemoryCache;
        }

    }
}