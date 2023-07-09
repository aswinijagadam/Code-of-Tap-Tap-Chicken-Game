using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewStart : MonoBehaviour {

    public void Restart()
    {
        Scene now_Scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(now_Scene.name);
    }
}
public static void main (String args[]){}
