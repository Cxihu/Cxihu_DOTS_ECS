using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct JobCol:IJob
{
    public NativeQueue<float> nativeQueue;

    public void Execute()
    {
       
    }
}
public class NativeContainerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        JobCol jobCol = new JobCol();
        jobCol.nativeQueue = new Unity.Collections.NativeQueue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
