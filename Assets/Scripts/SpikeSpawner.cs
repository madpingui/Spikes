using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    private List<GameObject> pooledObjects;
    public GameObject spike;
    public int amoutToPool;
    public float delay = 0.1f;   

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amoutToPool; i++)
        {
            tmp = Instantiate(spike);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        InvokeRepeating("Spawn", delay, delay);
    }

    private void Spawn()
    {
        GameObject spike = GetPooledObject();
        if(spike != null)
        {
            spike.transform.position = new Vector3(Random.Range(-6, 6), 10, 0);
            spike.SetActive(true);
        }
        else
        {
            spike = Instantiate(this.spike, new Vector3(Random.Range(-6, 6), 10, 0), Quaternion.identity);
            pooledObjects.Add(spike);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }
}
