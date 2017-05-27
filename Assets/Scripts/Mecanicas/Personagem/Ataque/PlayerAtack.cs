using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour {
    private bool attacking = false;

    private float attackDelay = 0.3f;
    private float attackTimer = 0;

    public Collider2D attackTrigger;

    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown("f") && !attacking)
        {
            attacking = true;
            attackTrigger.enabled = true;
            attackTimer = attackDelay;
        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

        //anim.SetBool("attaking", attacking);
    }
}
