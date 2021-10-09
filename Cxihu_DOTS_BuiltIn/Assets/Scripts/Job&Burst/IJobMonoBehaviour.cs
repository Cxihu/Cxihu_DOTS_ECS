using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Collections;

public class IJobMonoBehaviour : MonoBehaviour
{
    // [BurstCompatible]
    public struct Job1 : IJob
    {
        public int lenth;//1000000
        public NativeArray<float> outtemp;
        public void Execute()
        {
            for (int i = 0; i < lenth; i++)
            {
                outtemp[0] += math.sqrt(math.mul(99.9f, 88.8f) * i);
            }

        }
    }

    Job1 job1;
    // Start is called before the first frame update
    void Start()
    {
        job1 = new Job1();
        job1.lenth = 1000000;
        job1.outtemp = new NativeArray<float>(1, Allocator.TempJob);
        //job1.Schedule().Complete();
        //job1.outtemp.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        job1.Schedule().Complete();
        Debug.Log(job1.outtemp[0]);
    }
    private void OnDestroy()
    {
        job1.outtemp.Dispose();
    }
}
