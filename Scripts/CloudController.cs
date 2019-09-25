using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    public float speed;

	void Update ()
    {
        transform.Translate(Vector3.right * speed);
        if(transform.position.x > 30)
        {
            Destroy(this.gameObject);
        }
	}
}
