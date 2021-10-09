using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class RotationCudeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float dtime = Time.DeltaTime;
        Entities.WithAll<RotationCubeCommpont>().ForEach((ref RotationCubeCommpont rcc, ref Rotation rot) =>
        {
            rot.Value = math.mul(rot.Value, quaternion.AxisAngle(math.up(), rcc.speed * dtime));
        }).Schedule();
    }
}
