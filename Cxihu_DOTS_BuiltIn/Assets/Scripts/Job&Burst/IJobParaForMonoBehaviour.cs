using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Burst;

[BurstCompile]
public struct Job3 : IJobParallelFor
{
    public NativeArray<int> forNArray;
    public NativeArray<float> outtemp;

    public void Execute(int index)
    {
        outtemp[0] += math.mul(0.5f, 2f) * index;
        Debug.LogFormat("Job3 index:{0} ThreadId:{1}", index, System.Threading.Thread.CurrentThread.ManagedThreadId);
    }
}
public class IJobParaForMonoBehaviour : MonoBehaviour
{

    Job3 job3;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main ThreadId: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        job3 = new Job3();
        job3.forNArray = new NativeArray<int>(1000, Allocator.TempJob);
        job3.outtemp = new NativeArray<float>(1, Allocator.TempJob);
        job3.Schedule(job3.forNArray.Length, 1000).Complete();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(job3.outtemp[0]);
    }
    private void OnDestroy()
    {
        job3.forNArray.Dispose();
        job3.outtemp.Dispose();
    }
}
