using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Jobs;
public class CreateEntitiesSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float dtime = Time.DeltaTime;
        Entities.ForEach((ref Translation translation, ref Rotation rotation, ref CreateEntitiesComponent component) =>
        {
            rotation.Value = math.mul(rotation.Value, quaternion.AxisAngle(math.right(), component.RotationSpeed * dtime));

            if (translation.Value.y < 10f)
            {
                translation.Value.y += component.MoveSpeed * dtime;
            }
            else
            {
                translation.Value.y = -10f;
            }
        }).Schedule();
    }
}
