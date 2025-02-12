using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ObjectPoolBenchmark;
using PoolsLib;

BenchmarkRunner.Run<CacheBenchmarks>();

namespace ObjectPoolBenchmark
{
    [MemoryDiagnoser]
    public class CacheBenchmarks
    {
        private SimpleCache _simpleCache;
        private ObjectPoolCache _objectPoolCache;
        private int _counter;
        private const string HitKey = "hit_key";

        [GlobalSetup]
        public void Setup()
        {
            _simpleCache = new SimpleCache();
            _objectPoolCache = new ObjectPoolCache();
            _counter = 0;
        
            _simpleCache.Get(HitKey);
            _objectPoolCache.Get(HitKey);
        }
    
        [Benchmark]
        public void SimpleCache_CacheMiss()
        {
            string key = "key_" + _counter++;
            var obj = _simpleCache.Get(key);
            _simpleCache.Remove(key);
        }
    
        [Benchmark]
        public void OptimizedCache_CacheMiss()
        {
            string key = "key_" + _counter++;
            var obj = _objectPoolCache.Get(key);
            _objectPoolCache.Remove(key);
        }
    
        [Benchmark]
        public void SimpleCache_CacheHit()
        {
            var obj = _simpleCache.Get(HitKey);
        }

        [Benchmark]
        public void OptimizedCache_CacheHit()
        {
            var obj = _objectPoolCache.Get(HitKey);
        }
    }
}