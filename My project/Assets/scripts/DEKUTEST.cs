using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEKUTEST : MonoBehaviour

 {
        [SerializeField] float speed; //�������� ���������
        Animator anim; //��������� ������ �� ��������
        Rigidbody rb; //������ �� Rigidbody
        Vector3 direction; //����������� ��������

        void Start()
        {
          anim = GetComponent<Animator>();
          rb = GetComponent<Rigidbody>();
        }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        //������ �������� ���������
        if (direction.magnitude > 0)
        {
           
            anim.SetBool("run", true);
        }
        else anim.SetBool("run", false);
        //

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("chappy" );
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("box");
        }


    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

    }

        
}
