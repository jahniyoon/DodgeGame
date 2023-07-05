using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnr : MonoBehaviour
{

    public GameObject bulletPrefab = default;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    public Transform bulletPool = default;
    private Transform target = default;
    private float spawnRate = default;
    private float timeAfterSpawn = default;


    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerControler>().transform;
        transform.LookAt(target);

        //FindObject 같은 타입은 잘 안쓴다. 쉬워서 쓴 것
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        transform.LookAt(target);

        if (spawnRate <= timeAfterSpawn)
        {
            timeAfterSpawn = 0;

            GameObject bullet = Instantiate(bulletPrefab,
                transform.position, transform.rotation);

            bullet.transform.LookAt(target);


            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
