using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    [SerializeField] protected Status status;

    [SerializeField] protected float speed;

    protected Animator animator;

    protected Rigidbody rigidbody;

    // Start is called before the first frame update
    protected void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) 
    { 
        status.TakeDamage(damage);
        animator.SetTrigger("dmg");
        if (isDead()) 
        {
            animator.SetBool("die", true);
        }
    }

    public bool isDead() 
    {
        return status.isDead();
    }

}
