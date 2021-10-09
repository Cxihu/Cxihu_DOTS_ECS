using Unity.Burst;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public class StaticBurstClass
{
    [BurstCompile]
    public static float MathFunc()
    {
        float f = 0;
        for (int i = 0; i < 1000000; i++)
        {
            f += math.sqrt(math.mul(Time.deltaTime, Time.deltaTime) * i);
        }
        return f;
    }
}
