using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisWebApi.Contracts
{
    public class CacheItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
