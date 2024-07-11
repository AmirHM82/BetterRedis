using BetterRedis.Repositories;
using BetterRedis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterRedis
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Adds Redis distributed caching and better redis services to the specified Microsoft.Extensions.Hosting.IHostApplicationBuilder.
        /// </summary>
        /// <param name="builder">Represents a hosted applications and services builder which is in startup</param>
        /// <param name="connectionString">A string representing the location of database</param>
        /// <returns>The <see cref="IHostApplicationBuilder"/> so that additional calls can be chained.</returns>
        public static IHostApplicationBuilder AddBetterRedis(this IHostApplicationBuilder builder, string connectionString)
        {
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
            });
            builder.Services.AddSingleton<IRedisRepository, RedisService>();
            return builder;
        }
    }
}
