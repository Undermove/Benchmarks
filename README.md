# Benchmarks
Some personal benchmarks

## Simple ConcurrentDictionary cache VS ObjectPool cache

Experiment:
1) Get request
2) Store object in cache
3) Remove from cache
4) End request

### Results:

Simple ConcurrentDictionary cache after k6 bombing
![1](/ObjectPoolBenchmark/SimplePoolCacheAfterLoad.png)

ObjectPool cache after k6 bombing
![2](/ObjectPoolBenchmark/ObjectPoolCacheAfterLoad.png)