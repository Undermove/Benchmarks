using System.Collections.Concurrent;
using Microsoft.Extensions.ObjectPool;

namespace PoolsLib;

public class ObjectPoolCache
{
    private readonly ObjectPool<ExpensiveObject> _objectPool;
    private readonly ConcurrentDictionary<string, ExpensiveObject> _cache = new();

    public ObjectPoolCache(int maximumRetained = 20)
    {
        var policy = new ExpensiveObjectPooledPolicy();
        _objectPool = new DefaultObjectPool<ExpensiveObject>(policy, maximumRetained);
    }

    public ExpensiveObject Get(string key)
    {
        if (!_cache.TryGetValue(key, out var obj))
        {
            obj = _objectPool.Get();
            _cache[key] = obj;
        }
        return obj;
    }
    
    public void Remove(string key)
    {
        if (_cache.Remove(key, out var obj))
        {
            _objectPool.Return(obj);
        }
    }
}