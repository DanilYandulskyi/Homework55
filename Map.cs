using UnityEngine;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    [SerializeField] List<Resource> _resources = new List<Resource>();
    [SerializeField] List<Unit> _units = new List<Unit>();

    private static List<Resource> _collectedResources = new List<Resource>();
    
    private void Awake()
    {
        foreach (Unit unit in _units)
        {
            foreach (Resource resource in _resources)
            {
                unit.SetResourse(resource);
                _resources.Remove(resource);
                break;
            }
        }
    }

    public static void CollectResource(Resource resource)
    {
        _collectedResources.Add(resource);
    }
}
