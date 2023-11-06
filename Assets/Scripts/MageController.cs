using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : MonoBehaviour
{

    public float speed;

    [SerializeField]
    Status status;

    public StaffBeahviour[] Staffs;

    StaffBeahviour equipedStaff;

    Animator animator;

    Rigidbody rigidbody;

    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        equipedStaff = Staffs[0];
        animator = GetComponent<Animator>();
        rigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStaff();
        Attack();
        Move();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * Time.fixedDeltaTime);
    }

    private void Move()
    {
        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        movement = new Vector3(hAxis, 0, vAxis).normalized * speed;

        animator.SetFloat("speed", movement.magnitude);

    }

    void Attack() 
    {
        if (Input.GetButtonDown("Fire1")) 
        { 
            animator.SetTrigger("atk");
        }
    }

    void ChangeStaff() 
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            equipedStaff = Staffs[0];
            Staffs[0].gameObject.SetActive(true);
            Staffs[1].gameObject.SetActive(false);
            Staffs[2].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            equipedStaff = Staffs[1];
            Staffs[0].gameObject.SetActive(false);
            Staffs[1].gameObject.SetActive(true);
            Staffs[2].gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equipedStaff = Staffs[2];
            Staffs[0].gameObject.SetActive(false);
            Staffs[1].gameObject.SetActive(false);
            Staffs[2].gameObject.SetActive(true);
        }
    }

    public void TakeDamage(int damage) 
    {
        status.TakeDamage(damage);
        if (status.isDead()) 
        {
            animator.SetBool("die", true);
        }
    }

    public void DoAttack() 
    {
        equipedStaff.DoAtack();
    }


}
