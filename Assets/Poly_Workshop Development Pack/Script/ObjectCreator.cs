using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] GameObject prefabToCreate;
    public void CreatePrefabObject(Transform positionToCreate)
    {
        Instantiate(prefabToCreate, positionToCreate.position, positionToCreate.rotation, positionToCreate);
    }
}
