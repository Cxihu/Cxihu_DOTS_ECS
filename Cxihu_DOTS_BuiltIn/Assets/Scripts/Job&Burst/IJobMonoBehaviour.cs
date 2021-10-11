using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;
using Unity.Burst;

public class IJobMonoBehaviour : MonoBehaviour
{
    [BurstCompile]
    public struct Job1 : IJob
    {
        [ReadOnly]
        public int lenth;//1000
        public NativeArray<float> outtemp;
        public void Execute()
        {
            for (int i = 0; i < lenth; i++)
            {
                string str = "i:" + i;
                Debug.Log(str);
                outtemp[0] += math.mul(0.5f, 2f) * i;
            }

        }
    }

    Job1 job1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Main ThreadId: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        job1 = new Job1();
        job1.lenth = 1000;
        job1.outtemp = new NativeArray<float>(1, Allocator.TempJob);
        job1.Schedule().Complete();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(job1.outtemp[0]);
    }
    private void OnDestroy()
    {
        job1.outtemp.Dispose();
    }
}
