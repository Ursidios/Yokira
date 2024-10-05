using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int lifeAmount;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeAmount <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamege(int damage)
    {
        lifeAmount -= damage;
        anim.Play("Damage");
    }
}
