using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRedis.Repositories
{
    public interface IRedisRepository
    {
        /// <summary>
        /// Contains all keys that have been cached so far.
        /// </summary>
        ConcurrentDictionary<string, bool> Keys { get; }

        /// <summary>
        /// Gets a value with the given key.
        /// </summary>
        /// <typeparam name="T">The type of object expected as result.</typeparam>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="cancellationToken">Optional. The System.Threading.CancellationToken used to propagate notifications
        /// that the operation should be canceled.</param>
        /// <returns>The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        /// the located object or null.</returns>
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;

        /// <summary>
        /// Gets a value with the given key.
        /// If it does not exist, query data using databaseQuery, and Sets the value with the given key.
        /// </summary>
        /// <typeparam name="T">The type of object expected as result and argument.</typeparam>
        /// <param name="key">A string identifying the value.</param>
        /// <param name="databaseQuery"></param>
        /// <param name="cancellationToken">Optional. The System.Threading.CancellationToken used to propagate notifications
        /// that the operation should be canceled.</param>
        /// <returns>The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        /// the located object or null.</returns>
        Task<T?> GetSetAsync<T>(string key, Func<Task<T>> databaseQuery, CancellationToken cancellationToken = default)
            where T : class;

        /// <summary>
        /// Sets the value with the given key.
        /// </summary>
        /// <typeparam name="T">The type of object expected as argument.</typeparam>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="cancellationToken">Optional. The System.Threading.CancellationToken used to propagate notifications
        /// that the operation should be canceled.</param>
        /// <returns>The System.Threading.Tasks.Task that represents the asynchronous operation.</returns>
        Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default)
            where T : class;

        /// <summary>
        /// Removes the value with the given key.
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="cancellationToken">Optional. The System.Threading.CancellationToken used to propagate notifications
        /// that the operation should be canceled.</param>
        /// <returns>The System.Threading.Tasks.Task that represents the asynchronous operation.</returns>
        Task RemoveAsync(string key, CancellationToken cancellationToken = default);

        /// <summary>
        /// Clears all the cached objects
        /// </summary>
        /// <param name="cancellationToken">Optional. The System.Threading.CancellationToken used to propagate notifications
        /// that the operation should be canceled.</param>
        /// <returns>The System.Threading.Tasks.Task that represents the asynchronous operation.</returns>
        Task ClearAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Refreshes a value in the cache based on its key, resetting its sliding expiration timeout (if any).
        /// </summary>
        /// <param name="key">A string identifying the requested value.</param>
        /// <param name="token">Optional. The System.Threading.CancellationToken used to propagate notifications
        /// that the operation should be canceled.</param>
        /// <returns>The System.Threading.Tasks.Task that represents the asynchronous operation.</returns>
        Task RefreshAsync(string key, CancellationToken token = default);
    }
}
