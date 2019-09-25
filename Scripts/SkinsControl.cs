using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsControl : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        transform.localScale += new Vector3(0.25f, 0.25f, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.localScale -= new Vector3(0.25f, 0.25f, 0);
    }
}
