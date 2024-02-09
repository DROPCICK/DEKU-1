using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Text HpText;
    Animator anim; //Добавляем ссылку на аниматор

    float health = 100;
    bool isDead = false;

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

    public void ChangeHealth(float count)
    {
        health = health + count;
        if (health <= 0)
        {
            isDead = true;
            anim.SetTrigger("dead");
            tag = "Dead";
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "hospital")
        {
            ChangeHealth(50);
            Destroy(collider.gameObject);
        }
    }
    public float GetHealth()
    {
        return health;
    }

    public bool GetDead()
    {
        return isDead;
    }
}
