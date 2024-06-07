using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWave : MonoBehaviour
{
    [SerializeField]
    float skillPower;
    
    public ParticleSystem Ex;
    void Start()
    {
        StartCoroutine(DestroyWave());
 
    }

    IEnumerator DestroyWave()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Monster")
        {
            other.GetComponent<MonsterDamage>().OnDamage(10);

            if(PlayerAttack.instance.isButtonPressed3)
            {
                exPos(transform.position);
            }
        }

        /*if(other.gameObject.tag=="Monster" && PlayerAttack.instance.isButtonPressed3)
        {
            exPos(transform.position);
        }*/
     
    }

    void exPos(Vector3 pos)
    {
        Ex.Play();
        Ex.transform.position = pos;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * skillPower * Time.deltaTime);
        
    }
}
