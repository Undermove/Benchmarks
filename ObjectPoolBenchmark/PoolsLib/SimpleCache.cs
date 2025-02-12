using System.Collections.Concurrent;

namespace PoolsLib;

public class SimpleCache
{
    private readonly ConcurrentDictionary<string, ExpensiveObject> _cache = new();

    public ExpensiveObject Get(string key)
    {
        if (!_cache.TryGetValue(key, out var obj))
        {
            obj = new ExpensiveObject();
            _cache[key] = obj;
        }
        return obj;
    }
    
    public void Remove(string key)
    {
        _cache.Remove(key, out var obj);
    }
}