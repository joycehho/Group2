using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject teleportObject;

    public void TeleportTo(Transform to)
    {
        teleportObject.transform.position = to.position;
        teleportObject.transform.rotation = to.rotation;
    }
}
