using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedManager : MonoBehaviour
{
    public static SpawnedManager instance;

    public Transform objectPool;

    private void Start()
    {
        instance = this;
    }
}
