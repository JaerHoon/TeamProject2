using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMove : MonoBehaviour
{
    protected Monster monster;
    protected NavMeshAgent agent;

    protected bool IsMove;


    protected virtual void Init()
    {
        monster = GetComponent<Monster>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = monster.monsterData.MoveSpeed;
       
    }

    public virtual void Setting()
    {
        agent.destination = this.transform.position;
    }
    

    public virtual void OnMove()
    {
        IsMove = true;
    }

    public virtual void OffMove()
    {
        agent.destination = this.transform.position;
        IsMove = false;
    }



    protected virtual void Move()
    {
        agent.destination = monster.playerTr.position;
    }

    private void Update()
    {
        if (IsMove)
        {
            Move();
        }
    }
}