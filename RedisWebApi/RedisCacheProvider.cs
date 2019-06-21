using Microsoft.Extensions.Configuration;
using RedisWebApi.Contracts;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisWebApi
{
    public class RedisCacheProvider : ICacheProvider
    {
        IConfiguration configuration;
        private static RedisManagerPool redisManagerPool;
        public RedisCacheProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
            redisManagerPool = new RedisManagerPool(configuration.GetValue<string>("RedisConnection"));
        }

        public string Get(string key)
        {
            using (var client = redisManagerPool.GetClient())
            {
                return client.Get<string>(key);
            }
        }

        public void Post(string key, string value)
        {
            using (var client = redisManagerPool.GetClient())
            {
                client.Set<string>(key, value);
            }
        }
    }
}
