using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    private Rigidbody playerRigid = default;
    public float speed = default;
    public float rotationSpeed = 5f;


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


        // 주어진 축에 입력값을 반환. ex. Horizontal 축의 입력값을 받아와 xInput 함수에 할당
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // xInput에 저장된 입력값 * 속도로 xSpeed 변수에 할당
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //new Vector3을 활용하여 플레이어의 이동속도를 나타내는 벡터를 생성
        //xSpeed값을 x축으로 zSpeed값을 z축으로, y는 0으로 설정
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //playerRigid는  Rigidbody 컴포넌트를 가진 플레이어 오브젝트를 가르키는 변수.
        //playerRigid.velocity는 플레이어의 현재 속도를 나타내는 속성.
        //속성에 위에서 만든 벡터를 할당함으로써 플레이어를 움직이게 한다.
        playerRigid.velocity = newVelocity;


        Vector3 direction = new Vector3(xInput, 0f, zSpeed);  
        if (direction.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }



    }
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
