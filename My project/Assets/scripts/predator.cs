using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class predator : MonoBehaviour

 {
        [SerializeField] float speed; //скорость персонажа
        [SerializeField] float gravity = 200f;
        [SerializeField] List<string> kick = new List<string>();
        Animator anim; //ƒобавл€ем ссылку на аниматор
        Rigidbody rb; //ссылка на Rigidbody
        Vector3 direction; //Ќаправление движени€
        [SerializeField] GameObject player;
        float distan;
    void Start()
        {
          kick.Add("chappy");
          kick.Add("box");
          anim = GetComponent<Animator>();
          rb = GetComponent<Rigidbody>();
          //player = FindObjectOfType<Rigidbody>().gameObject; //Ќаходим игрока
        
        }


    void Update()
    {
        distan = Vector3.Distance(transform.position, player.transform.position);
        //мен€ем анимацию персонажа
        if (distan < 100)
            if (distan > 2) //100 - радиус обнаружени€

            {
                transform.LookAt(player.transform);
                direction = transform.forward;
                direction.y -= gravity * Time.deltaTime;
                GetComponent<CharacterController>().Move(direction * Time.deltaTime * speed);
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("stend")) {
                    string k = kick[Random.Range(0, kick.Count)];
                    anim.SetTrigger(k);

                }



            }




        
        


    }

    

        
}
