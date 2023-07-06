using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    private Vector3 bulltetRotation = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulltetRotation.y = rotationSpeed;
        transform.Rotate(bulltetRotation);

    }
}
