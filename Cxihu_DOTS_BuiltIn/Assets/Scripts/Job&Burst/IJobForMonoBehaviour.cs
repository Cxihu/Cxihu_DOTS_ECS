using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Burst;

[BurstCompile]
public struct Job2 : IJobFor
{
    public NativeArray<int> forNArray;
    public NativeArray<float> outtemp;
    public void Execute(int index)
    {
        outtemp[0] += math.mul(0.5f, 2f) * index;
        Debug.LogFormat("Job2 index:{0} ThreadId:{1}", index, System.Threading.Thread.CurrentThread.ManagedThreadId);
    }

}
public class IJobForMonoBehaviour : MonoBehaviour
{

    Job2 job2;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main ThreadId: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        job2 = new Job2();
        job2.forNArray = new NativeArray<int>(1000, Allocator.TempJob);
        job2.outtemp = new NativeArray<float>(1, Allocator.TempJob);
        // job2.Schedule(job2.forNArray.Length, new JobHandle()).Complete();
        job2.ScheduleParallel(job2.forNArray.Length, 64, new JobHandle()).Complete();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(job2.outtemp[0]);
    }
    private void OnDestroy()
    {
        job2.forNArray.Dispose();
        job2.outtemp.Dispose();
    }
}
