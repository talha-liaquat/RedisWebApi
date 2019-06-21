using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RedisWebApi.Contracts;
using ServiceStack.Redis;

namespace RedisWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        ICacheProvider cacheProvider;
        public CacheController(ICacheProvider cacheProvider)
        {
            this.cacheProvider = cacheProvider;
        }

        [HttpGet]
        public ActionResult<CacheItem> Get(string key)
        {
            return new CacheItem
            {
                Key = key,
                Value = cacheProvider.Get(key)
            };
        }

        [HttpPost]
        public void Post([FromBody]CacheItem item)
        {
            cacheProvider.Post(item.Key, item.Value);
        }
    }
}