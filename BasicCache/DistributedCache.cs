//dotnet add package Microsoft.Extensions.Caching.StackExchangeRedis

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;

ver services = new ServiceCollection();

services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:5050";
    options.InstanceName = "SampleInstance";
});

var serviceProvider = services.BuildServiceProvider();
var cache = serviceProvider.GetService<IDistributedCache>();