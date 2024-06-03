using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    protected Monster monster;
    protected bool IsATK;
    protected BoxCollider hitBox;
    

    protected void Init()
    {
        monster = GetComponent<Monster>();
        hitBox = GetComponentInChildren<BoxCollider>();
    }


    public virtual void OnATK()
    {
        IsATK = true;
    }

    public virtual void OffATK()
    {
        IsATK = false;
    }
    public virtual void Attack()
    {

    }
    public virtual void Attack1()
    { 
    }
    

    public virtual void EndAttack()
    {

    }

    public virtual void Attack2()
    {

    }

    public virtual void Attack3()
    {

    }
    public virtual void Hit(CharacterDamage player)
    {
        

    }
}