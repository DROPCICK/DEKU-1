using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEKUTEST : MonoBehaviour

 {
        [SerializeField] float speed; //скорость персонажа
        Rigidbody rb; //ссылка на Rigidbody
        Vector3 direction; //Направление движения

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }


}
