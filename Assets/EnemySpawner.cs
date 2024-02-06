using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyobject;
    public float spawntimer;
    public float timetospawn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timetospawn -= Time.deltaTime;
		if (timetospawn <= 0)
		{
            timetospawn = spawntimer;
            Instantiate(enemyobject, transform.position, Quaternion.identity);
		}
    }
}
