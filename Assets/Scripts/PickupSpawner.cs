using System.Collections.Generic;
using UnityEngine;

public class PickupObjectSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private PickupObject[] PickupObjectPrefabs;    //Polymorphism

    [Header("Spawn Settings")]
    [SerializeField] private Vector3 areaSize = new Vector3(12f, 3f, 4f);

    [SerializeField] private float minSpacing = 1.8f;

    [SerializeField] private float spawnInterval = 1f;

    [SerializeField] private int maxPickupObjects = 4;

    private List<PickupObject> _activePickupObjects = new List<PickupObject>();
    private float _spawnTimer = 0f;

     void Update()
    {
        _activePickupObjects.RemoveAll(PickupObject => PickupObject == null);

        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0f && _activePickupObjects.Count < maxPickupObjects)
        {
            if (TrySpawnRandomPickupObject())
            {
                _spawnTimer = spawnInterval;
            }
        }
    }

    private bool TrySpawnRandomPickupObject()
    {
        PickupObject prefab = PickupObjectPrefabs[Random.Range(0, PickupObjectPrefabs.Length)];

        Vector3 position = GetRandomPointInArea();
        if (IsTooCloseToOtherPickupObjects(position)) return false;

        PickupObject newPickupObject = Instantiate(prefab, position, Quaternion.identity);
        _activePickupObjects.Add(newPickupObject);

        return true;
    }


    private bool IsTooCloseToOtherPickupObjects(Vector3 position)
    {
        foreach (PickupObject PickupObject in _activePickupObjects)
        {
            if (PickupObject != null && Vector3.Distance(PickupObject.transform.position, position) < minSpacing) return true;
        }
        return false;
    }

    private Vector3 GetRandomPointInArea()
    {
        Vector3 localOffset = new Vector3(
            Random.Range(-0.5f, 0.5f) * areaSize.x,
            Random.Range(-0.5f, 0.5f) * areaSize.y,
            Random.Range(-0.5f, 0.5f) * areaSize.z
            );
        return transform.position + localOffset;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, areaSize);
    }
}
