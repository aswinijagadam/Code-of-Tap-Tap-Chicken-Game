using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {

    [SerializeField] private Transform Cloud;

    private void Start()
    {
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
    Instantiate(Cloud, new Vector3
    (Cloud.position.x + Random.Range(0, 10), Cloud.position.y + Random.Range(-1, 1), Cloud.position.z + Random.Range(-5, 20)), Quaternion.identity);
    }
}
