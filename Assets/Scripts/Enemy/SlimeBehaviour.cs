using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : Character
{

    [SerializeField] Transform atkOrigin;
    [SerializeField] float atkDistance;
    [SerializeField] float atkCooldown;


    MageController target;

    bool isAtk = false;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<MageController>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector3.Distance(transform.position,
            target.transform.position);

        if (targetDistance > atkDistance)
        {
            Vector3 lookTarget = 
                new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            transform.LookAt(lookTarget, Vector3.up);
            Vector3 newPos = 
                Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            rigidbody.position = newPos;
        } 
        else if (!isAtk) 
        { 
            isAtk= true;
            StartCoroutine("DoAttack");
        }

        if (isDead()) 
        { 
            Destroy(gameObject);
        }
    }

    IEnumerator DoAttack() 
    {
        RaycastHit hit;
        Debug.DrawRay(atkOrigin.position, transform.forward * 2, Color.red, 1);
        if (Physics.Raycast(atkOrigin.position, transform.forward * 2, out hit)) 
        {
            MageController mage = hit.transform.gameObject.GetComponent<MageController>();
            mage.TakeDamage(1);
        }
        yield return new WaitForSeconds(atkCooldown);
        isAtk = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "atk") 
        {
            MissleController missle = collision.gameObject.GetComponent<MissleController>();
            TakeDamage(missle.GetDamage());
            Destroy(missle.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "atk") 
        { 
            
        }
    }

}
