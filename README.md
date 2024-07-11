# RedisEnhanced .NET Library

## Overview
RedisEnhanced is a .NET library designed to simplify the use of Redis caching and extend its capabilities. This library abstracts the complexities of working directly with Redis and offers a more streamlined and intuitive interface for developers. With RedisEnhanced, you can leverage the power of Redis with minimal effort and maximize your application's performance through efficient caching strategies.

## Features
- **Simplified API:** Easy-to-use methods for common caching operations.
- **Advanced Caching Strategies:** Support for various caching patterns like time-based expiration, sliding expiration, and more.
- **Data Serialization:** Built-in support for efficient serialization and deserialization of objects.
- **Cache Invalidation:** Automatic and manual cache invalidation mechanisms.
- **Logging and Monitoring:** Integrated logging and monitoring for cache operations.
- **Extensible:** Easily extend and customize the library to fit your specific needs.

## Installation
You can install the RedisEnhanced library via NuGet package manager:

```bash
dotnet add package RedisEnhanced
```

Alternatively, you can use the NuGet Package Manager in Visual Studio to search for and install `RedisEnhanced`.

## Getting Started
### Prerequisites
- .NET 5.0 or later
- Redis server (local or remote)

### Basic Usage

1. **Configuration:**
   Configure RedisEnhanced in your application startup:

   ```csharp
   services.AddRedisEnhanced(options =>
   {
       options.ConnectionString = "your-redis-connection-string";
       // Additional configuration options
   });
   ```

2. **Caching Data:**
   Use the RedisEnhanced cache manager to store and retrieve data:

   ```csharp
   var cacheManager = serviceProvider.GetRequiredService<IRedisEnhancedCacheManager>();

   // Set a value in cache
   await cacheManager.SetAsync("key", "value", TimeSpan.FromMinutes(10));

   // Get a value from cache
   var value = await cacheManager.GetAsync<string>("key");
   ```

3. **Cache Invalidation:**
   Invalidate cache entries when necessary:

   ```csharp
   await cacheManager.RemoveAsync("key");
   ```

### Advanced Usage
Explore advanced features like custom serializers, logging, and more in the [documentation](#).

## Contributing
We welcome contributions to enhance RedisEnhanced. To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with detailed information about your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact
For any questions or support, please create an issue on GitHub or contact the maintainers.

---

RedisEnhanced makes Redis caching simple and efficient, enabling developers to build high-performance applications effortlessly. Try it out today and see the difference it can make in your .NET projects!
