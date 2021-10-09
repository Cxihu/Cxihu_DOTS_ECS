using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
public static class StaticBurstClass
{
    [BurstCompile]
    public static float MathFunc()
    {
        float f = 0;
        for (int i = 0; i < 1000000; i++)
        {
            f += math.sqrt(math.mul(99.9f, 88.8f) * i);
        }
        return f;
    }
}
