using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisWebApi.Contracts
{
    public interface ICacheProvider
    {
        string Get(string key);
        void Post(string key, string value);
    }
}
