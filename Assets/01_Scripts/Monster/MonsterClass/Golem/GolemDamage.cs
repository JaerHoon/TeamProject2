using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDamage : MonsterDamage
{
    Golem golem;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        golem = GetComponent<Golem>();
    }


    private void OnMouseEnter()
    {
        OnDamage(100f);
    }

    public override void OnDamage(float pow)
    {
        golem.CurrentHP -= pow;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
