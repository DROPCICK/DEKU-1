using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject particle; // добавляем ссылку на эффект взрыва
    [SerializeField] Text TimeText;
    [SerializeField] Text ScoreText;
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;

    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
      // transform.position = new Vector3(x, y, z);

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0, moveVertical);
        if (Input.GetKey(KeyCode.LeftShift))

        {
            speed=20f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))

        {
            speed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*direction.y = 1;*/
        }
        direction = transform.TransformDirection(direction) * speed;
        controller.Move(direction * Time.deltaTime);
    }
}       
