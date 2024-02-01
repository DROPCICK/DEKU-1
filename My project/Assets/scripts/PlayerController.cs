using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    
    
    [SerializeField] Text HpText;
    Animator anim; //Добавляем ссылку на аниматор

    int health = 100;
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();

        ChangeHealth(100);
        




    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void ChangeHealth(int count)
    {

        health = health + count;
        if (health <=0)
        {
            anim.SetTrigger("dead");
        }
        //������ �������� UIText � Unity
        //HpText.text = "HP: " + health.ToString();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "hospital")
        {
            ChangeHealth(50); 


            //GetComponent<AudioSource>().Play();


            Destroy(collider.gameObject);
        }

    }
    public int GetHealth()
    {
        return health;
    }
}
