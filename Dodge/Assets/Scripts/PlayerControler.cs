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
        // �� ��Ʈ�ѷ��� �޸� Ʈ�������� �����´�.
    }

    // Update is called once per frame
    void Update()
    {   //AddForce�� �̴� �����̱⿡ ���ӵ��� �����.
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



        //GetAxis ���̽�ƽ���� ��ǲ�� �޴´�.


        // �־��� �࿡ �Է°��� ��ȯ. ex. Horizontal ���� �Է°��� �޾ƿ� xInput �Լ��� �Ҵ�
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // xInput�� ����� �Է°� * �ӵ��� xSpeed ������ �Ҵ�
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //new Vector3�� Ȱ���Ͽ� �÷��̾��� �̵��ӵ��� ��Ÿ���� ���͸� ����
        //xSpeed���� x������ zSpeed���� z������, y�� 0���� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //playerRigid��  Rigidbody ������Ʈ�� ���� �÷��̾� ������Ʈ�� ����Ű�� ����.
        //playerRigid.velocity�� �÷��̾��� ���� �ӵ��� ��Ÿ���� �Ӽ�.
        //�Ӽ��� ������ ���� ���͸� �Ҵ������ν� �÷��̾ �����̰� �Ѵ�.
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
