using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_NormalATK : Platform
{
    private void Start()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("����");
        }
    }
}