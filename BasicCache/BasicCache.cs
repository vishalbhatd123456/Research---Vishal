using System;
using Microst.Extensions.Caching.Memory;

public class BasicCache
{
    private IMemoryCache _cache;

    public BasicCache()
    {
        _cache = new MemoryCache(new MemoryCacheOptions());
    }

    public void SetCache<T>(string key, T value, TimeSpan expiration)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        };
        _cache.Set(key, value, cacheEntryOptions);
    }

    public T GetCache<T>(string key)
    {
        //get the value of the cache placed at the key level
        // key -> value pair cache
        try{
        _cache.TryGetValue(key, out T value);
        }
        catch(CacheEception ex)
        {
            console.log("Cache couldnt be found with the key {0} and excption 
            is {1}",key,ex);
        }
    }

    //Usage
    virtual cache = new BasicCache();
    cache.SetCache("key1","value1",TimeSpan.FromMinutes(1));
    var value = cache.GetCache<string>("key1");
}