using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    private Rigidbody playerRigid = default;
    public float speed = default;


    // Start is called before the first frame update
    void Start()
    {
        playerRigid = transform.GetComponent<Rigidbody>();
        // 내 컨트롤러에 달린 트랜스폼을 가져온다.
    }

    // Update is called once per frame
    void Update()
    {   //AddForce는 미는 동작이기에 가속도가 생긴다.
        //if (Input.GetKey(KeyCode.UpArrow) == true)
        //{
        //    playerRigid.AddForce(0f, 0f, speed);

        //}
        //if (Input.GetKey(KeyCode.DownArrow) == true)
        //{
        //    playerRigid.AddForce(0f, 0f, -speed);

        //}
        //if (Input.GetKey(KeyCode.RightArrow) == true)
        //{
        //    playerRigid.AddForce(speed, 0f, 0f);

        //}
        //if (Input.GetKey(KeyCode.LeftArrow) == true)
        //{
        //    playerRigid.AddForce(-speed, 0f, 0f);

        //}

        //GetAxis 조이스틱으로 인풋을 받는다.
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
            playerRigid.velocity = newVelocity;

    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
