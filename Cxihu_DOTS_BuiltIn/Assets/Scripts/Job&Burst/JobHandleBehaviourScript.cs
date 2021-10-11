using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
public class JobHandleBehaviourScript : MonoBehaviour
{
    Job2 job2;
    Job3 job3;
    // Start is called before the first frame update
    void Start()
    {
        job2 = new Job2();
        job2.forNArray = new NativeArray<int>(1000, Allocator.TempJob);
        job2.outtemp = new NativeArray<float>(1, Allocator.TempJob);
        job3 = new Job3();
        job3.forNArray = new NativeArray<int>(1000, Allocator.TempJob);
        job3.outtemp = new NativeArray<float>(1, Allocator.TempJob);

        JobHandle jobHandle2 = job2.ScheduleParallel(job2.forNArray.Length,1000, new JobHandle());
        job3.Schedule(job3.forNArray.Length, 1000, jobHandle2).Complete();
        Debug.Log("job2.outtemp[0]:" + job2.outtemp[0]);
        Debug.Log("job3.outtemp[0]:" + job3.outtemp[0]);
        job2.forNArray.Dispose();
        job2.outtemp.Dispose();
        job3.forNArray.Dispose();
        job3.outtemp.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
    }
}
