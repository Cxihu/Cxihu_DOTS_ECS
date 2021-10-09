using UnityEngine;
using Unity.Entities;

public class RotationCubeEntities : MonoBehaviour, IConvertGameObjectToEntity
{
    public float Espeed = 5f;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        RotationCubeCommpont rotationCubeCommpont = new RotationCubeCommpont { speed = Espeed };
        dstManager.AddComponentData(entity, rotationCubeCommpont);
    }
}
