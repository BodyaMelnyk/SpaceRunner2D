using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
    
    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefabs) 
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomEnemyIndex = Random.Range(0, prefabs.Length);

            GameObject spawned = Instantiate(prefabs[randomEnemyIndex], _container);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container);
            spawned.SetActive(false);
            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }
}
