using Microsoft.Extensions.ObjectPool;

namespace PoolsLib;

public class ExpensiveObjectPooledPolicy : PooledObjectPolicy<ExpensiveObject>
{
    public override ExpensiveObject Create() => new();
    public override bool Return(ExpensiveObject obj)
    {
        obj.Reset();
        return true;
    }
}