using BetterRedis.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRedis.Services
{
    public class RedisService : IRedisRepository
    {
        private readonly IDistributedCache _distributedCache;
        private ConcurrentDictionary<string, bool> _keys;

        public RedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _keys = new ConcurrentDictionary<string, bool>();
        }

        public ConcurrentDictionary<string, bool> Keys => _keys;

        public async Task ClearAsync(CancellationToken cancellationToken = default)
        {
            //foreach (var key in _keys.Keys)
            //{
            //    await this.RemoveAsync(key, cancellationToken);
            //}

            IEnumerable<Task> tasks = _keys.Keys.Select(x => this.RemoveAsync(x, cancellationToken));
            await Task.WhenAll(tasks);
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            string? cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (cachedValue == null)
            {
                return default(T?);
            }

            return JsonConvert.DeserializeObject<T>(cachedValue);
        }

        public async Task<T?> GetSetAsync<T>(string key, Func<Task<T>> databaseQuery, CancellationToken cancellationToken = default) where T : class
        {
            T? cachedValue = await this.GetAsync<T>(key, cancellationToken);

            if (cachedValue != null)
            {
                return cachedValue;
            }

            cachedValue = await databaseQuery();

            await this.SetAsync(key, cachedValue, cancellationToken);

            return cachedValue;
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            return _distributedCache.RefreshAsync(key, token);
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(key, cancellationToken);
            _keys.TryRemove(key, out bool _);
        }

        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            string cacheValue = JsonConvert.SerializeObject(value);
            await _distributedCache.SetStringAsync(key, cacheValue, cancellationToken);
            _keys.TryAdd(key, false);
        }
    }
}
