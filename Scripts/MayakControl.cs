using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayakControl : MonoBehaviour {
    float speed;
    private void Start()
    {
        speed = Random.Range(1, 2);
    }
    void Update ()
    {
        transform.Rotate(0, speed , 0);
	}
}
