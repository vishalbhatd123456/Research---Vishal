public class DistributedCacheUsage
{
    private readonly IDistributedCache _cache;

    public DistributedCacheUsage(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        };

        var serializedValue = JsonSerializer.Serialize(value);
        await _cache.SetStringAsync(key,serializedValue, options);
    }
}