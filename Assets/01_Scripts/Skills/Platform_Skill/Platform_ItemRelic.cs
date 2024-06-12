using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_ItemRelic : Platform
{
    bool IsSkillInfo;
    void Start()
    {
        Init();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsSkillInfo=true;
            OnSkillInfo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsSkillInfo=false;
            OffSkillInfo();
        }
    }

    private void Update()
    {
        if (IsSkillInfo && Input.GetKeyDown(KeyCode.E))
        {
            GetItem();
            IsSkillInfo = false;
            OffSkillInfo();
        }
    }

}
