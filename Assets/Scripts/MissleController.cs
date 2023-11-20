using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleController : MonoBehaviour
{
    [SerializeField]
    int damage;

    [SerializeField]
    MagicType magicType;

    [SerializeField]
    float speed;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 5);
    }

    public int GetDamage() 
    { 
        return damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
