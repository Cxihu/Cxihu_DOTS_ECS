using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class CreateEntitiesManager : MonoBehaviour
{
    public GameObject GOPrefab;
    public int X = 10;
    public int Y = 10;
    public int Z = 10;
    BlobAssetStore blobAssetStore;
    Entity entity;
    EntityManager entityManager;

    // Start is called before the first frame update
    void Start()
    {
        if (!GOPrefab)
        {
            Debug.LogError("GOPrefab==null");
            return;
        }
        blobAssetStore = new BlobAssetStore();
        entity = GameObjectConversionUtility.ConvertGameObjectHierarchy(GOPrefab, GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, blobAssetStore));
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        CreateEntities();
    }

    void CreateEntities()
    {

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                for (int k = 0; k < Z; k++)
                {
                    Entity Etemp = entityManager.Instantiate(entity);
                    Translation translation = new Translation { Value = new float3(i - X / 2, j - Y / 2, k - Z / 2) };
                    entityManager.SetComponentData(Etemp, translation);
                    entityManager.AddComponentData(Etemp, new CreateEntitiesComponent() { MoveSpeed = 1f, RotationSpeed = 2f });
                }
            }

        }

    }

    private void OnDestroy()
    {
        blobAssetStore.Dispose();
    }

}
