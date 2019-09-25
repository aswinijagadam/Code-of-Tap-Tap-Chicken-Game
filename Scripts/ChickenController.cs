using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChickenController : MonoBehaviour {

    int Chicken_Voice_Range;

    public float speed = 50f;
    private Rigidbody _body;
    private AudioSource _audio;
    public AudioClip ChickenSound;
    public AudioClip Chicken_sound_1;
    public AudioClip Chicken_sound_2;
    public AudioClip Chicken_sound_3;
    public AudioClip Chicken_sound_4;

    private Animator _animator;
    private float Sound_From_Time;
    float timer_time = 3;
    float scorelabelTime = 204;

    int FloorScore = 0;

    void Start()
    {   
        if (SceneManager.GetActiveScene().name == "Level-1")
        {
            scorelabelTime = 19;
        }
        if (SceneManager.GetActiveScene().name == "Level-2")
        {
            scorelabelTime = 24;
        }
        if (SceneManager.GetActiveScene().name == "Level-3")
        {
            scorelabelTime = 39;
        }
        if (SceneManager.GetActiveScene().name == "Level-4")
        {
            scorelabelTime = 64;
        }
        if (SceneManager.GetActiveScene().name == "Level-5")
        {
            scorelabelTime = 84;
        }
        if (SceneManager.GetActiveScene().name == "Level-6")
        {
            scorelabelTime = 104;
        }
        if (SceneManager.GetActiveScene().name == "Level-7")
        {
            scorelabelTime = 124;
        }
        if (SceneManager.GetActiveScene().name == "Level-8")
        {
            scorelabelTime = 154;
        }
        if (SceneManager.GetActiveScene().name == "Level-9")
        {
            scorelabelTime = 184;
        }

        PlayerPrefs.SetString("LoadScene", SceneManager.GetActiveScene().name);
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
        _body = GetComponent<Rigidbody>();
        _body.drag = 0;
        Time.fixedDeltaTime = 0.02f;
    }


    void FixedUpdate() {


            if (Input.GetMouseButtonDown(0) && Time.timeSinceLevelLoad > timer_time && FloorScore < 2 && Time.timeSinceLevelLoad < scorelabelTime)
            {
                _body.AddForce(Vector3.up * speed, ForceMode.Impulse);
            _audio.PlayOneShot(ChickenSound, 2f);
            if (FloorScore == 1)
            {
                Sound_From_Time = Time.time;
            }
            if (Time.time > Sound_From_Time + 2f)
            {
                Chicken_Voice_Range = Random.Range(1, 4);
                if (Mathf.Round(Chicken_Voice_Range) == 1)
                {
                    _audio.PlayOneShot(Chicken_sound_1, 0.5f);
                }
                if (Mathf.Round(Chicken_Voice_Range) == 2)
                {
                    _audio.PlayOneShot(Chicken_sound_2, 0.5f);
                }
                if (Mathf.Round(Chicken_Voice_Range) == 3)
                {
                    _audio.PlayOneShot(Chicken_sound_3, 0.5f);
                }
                if (Mathf.Round(Chicken_Voice_Range) == 4)
                {
                    _audio.PlayOneShot(Chicken_sound_4, 0.5f);
                }
            }
            FloorScore++;
            }
            
            if(Input.GetMouseButton(0) && Time.timeSinceLevelLoad > timer_time && FloorScore > 0 &&
            Input.GetMouseButtonDown(0) == false && Time.timeSinceLevelLoad < scorelabelTime)
        {
            if(this.gameObject.name == "chicken_1(Clone)")
            {
                _animator.SetBool("IsDrag", true);
            }
            else
            {
                _animator.SetBool("Drag", true);
            }
            if (_body.drag < 12)
            {
                _body.drag += 0.15f;
            }
        }
            if(Input.GetMouseButton(0) == false)
        {
            _body.drag = 0;
            if (this.gameObject.name == "chicken_1(Clone)")
            {
                _animator.SetBool("IsDrag", false);
            }
            else
            {
                _animator.SetBool("Drag", false);
            }

        }



    }
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "floor" && FloorScore > 0)
            {
             FloorScore = 0;
            _body.drag = 0;

            }

        if (other.gameObject.tag == "enemy")
        {
            StartCoroutine(Died());
        }
    }

    IEnumerator Died()
    {
        yield return new WaitForSecondsRealtime(0);
        Destroy(this.gameObject);
    }

}
