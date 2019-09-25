using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartController : MonoBehaviour {
    [SerializeField] private GameObject Menu;
    private void Start()
    {
        Time.timeScale = 1f;
        Menu.gameObject.SetActive(false);
    }
}
