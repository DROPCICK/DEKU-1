using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class predator : MonoBehaviour
{
    [SerializeField] float speed; //скорость персонажа
    [SerializeField] float gravity = 200f;
    [SerializeField] List<string> kick = new List<string>();
    Animator anim; //Добавляем ссылку на аниматор
    Rigidbody rb; //ссылка на Rigidbody
    Vector3 direction; //Направление движения
    GameObject[] players;
    float distan;
    public float viewDistance = 100; // радиус обнаружения
    public float kickDistance = 2; // расстояние для удара
    PlayerController pcTarget;
    PlayerController pc;
    CharacterController ccTarget;
    CharacterController cc;
    public float power = 1f;
    float patrolTimer;
    public float timeToPatroling = 3f;
    Vector3 oldPosition;
    Vector3 newPosition;

    void Start()
    {
        kick.Add("chappy");
        kick.Add("box");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        pc = GetComponent<PlayerController>();

        //Находим игрока
        FindTarget();
        //player = FindObjectOfType<Rigidbody>().gameObject; //Находим игрока
    }

    void FindTarget()
    {
        if (tag == "Enemy")
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
        else if (tag == "Player")
        {
            players = GameObject.FindGameObjectsWithTag("Enemy");
        }

        float closest = Mathf.Infinity;
        pcTarget = null;

        foreach (GameObject player in players)
        {
            distan = Vector3.Distance(transform.position, player.transform.position);
            if (distan < closest)
            {
                closest = distan;
                pcTarget = player.GetComponent<PlayerController>();
                ccTarget = player.GetComponent<CharacterController>();
            }
        }
    }

    void Update()
    {

        FindTarget();

        if (pcTarget == null || pc.GetDead())
        {
            return;
        }
        
        distan = Vector3.Distance(transform.position, pcTarget.transform.position);
        //меняем анимацию персонажа
        if (distan < viewDistance)
        {
            if (distan > kickDistance)
            {
                transform.LookAt(pcTarget.transform);
                direction = transform.forward;
                direction.y -= gravity * Time.deltaTime;
                cc.Move(direction * Time.deltaTime * speed);
                anim.SetBool("run", true);
            }
            else
            {
                transform.LookAt(pcTarget.transform);
                anim.SetBool("run", false);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("stend"))
                {
                    string k = kick[Random.Range(0, kick.Count)];
                    anim.SetTrigger(k);
                    pcTarget.ChangeHealth(-power * Random.Range(10, 100) / 100);

                    if (Random.Range(1, 10) > 8)
                    {
                        ccTarget.Move(transform.forward * 2);
                        //print("otskok");
                    }
                }
            }
        }
        else
        {
            oldPosition = transform.position;
            cc.Move(transform.forward * Time.deltaTime * speed);
            newPosition = transform.position;

            if (oldPosition != newPosition)
            {   
                anim.SetBool("run", true);
                //transform.Rotate(new Vector3(0, 30, 0));
            }

            patrolTimer += Time.deltaTime;
            if (patrolTimer > timeToPatroling)
            {
                transform.Rotate(new Vector3(0, Random.Range(-180, 180), 0));
                patrolTimer = 0;
                timeToPatroling = Random.Range(1, 6);
            }
        }
    }

}
