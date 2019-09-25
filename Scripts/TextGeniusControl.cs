using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGeniusControl : MonoBehaviour {

    void FixedUpdate ()
    {
        transform.localPosition -= new Vector3(3f, 0, 0);

        if (this.gameObject.transform.localPosition.x < -186)
        {
            Destroy(this.gameObject);
        }
	}
}
