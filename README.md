# BetterRedis .NET Library

## Overview
BetterRedis is a .NET library designed to simplify the use of Redis caching and extend its capabilities. This library abstracts the complexities of working directly with Redis and offers a more streamlined interface for developers.

## Features
- **Simplified API:** Easy-to-use methods for common caching operations.
- **Data Serialization:** Built-in support for efficient serialization and deserialization of objects.
- **Extensible:** Easily extend and customize the library to fit your specific needs.

## Installation
You can install the BetterRedis library via NuGet package manager:

```bash
dotnet add package BetterRedis
```

Alternatively, you can use the NuGet Package Manager in Visual Studio to search for and install `BetterRedis`.

## Getting Started
### Prerequisites
- .NET 8.0 or later
- Redis server (local or remote)

### Basic Usage

1. **Configuration:**
   Configure BetterRedis in your application startup:

   ```csharp
   services.AddBetterRedis(options =>
   {
       options.ConnectionString = "your-redis-connection-string";
       // Additional configuration options
   });
   ```

2. **Caching Data:**
   Use the BetterRedis cache manager to store and retrieve data:

   ```csharp
   var cacheManager = serviceProvider.GetRequiredService<IRedisRepository>();

   // Set a value in cache
   await cacheManager.SetAsync("key", "value");

   // Get a value from cache
   var value = await cacheManager.GetAsync<string>("key");
   ```

3. **Cache Invalidation:**
   Invalidate cache entries when necessary:

   ```csharp
   await cacheManager.RemoveAsync("key");
   ```
   
   Or Invalidate all entries:
   
   ```csharp
   await cacheManager.ClearAsync();
   ```

5. **Cache Extension:**
   Extend the duration of cache entry:

   ```csharp
   await cacheManager.RefreshAsync("key");
   ```

## Contributing
We welcome contributions to enhance BetterRedis. To contribute:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with detailed information about your changes.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE.txt) file for details.

## Contact
For any questions or support, please create an issue on GitHub or contact the maintainers.

---

BetterRedis makes Redis caching simple and efficient, enabling developers to build high-performance applications effortlessly. Try it out today and see the difference it can make in your .NET projects!
