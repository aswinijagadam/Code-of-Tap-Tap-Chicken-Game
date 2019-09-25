using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using UnityEngine.Audio;

public class WedgeControl : MonoBehaviour
{
    [SerializeField] private GameObject Lose_Menu;

    [SerializeField] private AudioClip ticking_Sound_1;
    [SerializeField] private AudioClip ticking_Sound_2;
    int tickingSoundIndex = 0;
    private bool isTickingSound;

    [SerializeField] private GameObject guideButtonOne;
    [SerializeField] private GameObject guideButtonTwo;

    public AudioClip WinSound;
    public AudioClip LoseSound;

    public ParticleSystem winParticle;

    private static int _ADS = 3;

    private float SoundTreckVolume;

    public AudioMixerGroup SoundTreck;

    private bool isGuideActive;
    private bool isGuideTwoActive;

    [SerializeField] private GameObject youWinText;

    [SerializeField] private ParticleSystem plumage;

    [SerializeField] private GameObject  guideOne;
    [SerializeField] private GameObject guideTwo;

    [SerializeField] private GameObject Exit_to_Menu;
    [SerializeField] private GameObject Exit_from_Menu;

    public float speed = 150f;
    float direction = 1;
    float SceneSince_time;
    float SceneSince_time1;
    public float Scene_time = 23;
    float timer_time = 3;
    int ifnumber = 0;
    int ifnumber_0;

    int ScoreLabelBigIf = 0;
    float ScoreNumberScale;

    [SerializeField] private GameObject Win_Menu;

    [SerializeField] private GameObject score_Label;

    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text timer;
    [SerializeField] private GameObject timer_3;
    Vector3 point = new Vector3(-1.23f, -1.12f, 0.68f);

    void Start()
    {   
        winParticle.Stop();
        guideOne.SetActive(false);
        guideTwo.SetActive(false);
        ScoreNumberScale = Mathf.Round(Random.Range(3, 7));
        PlayerPrefs.SetInt("IsDied", 0);
        youWinText.SetActive(false);
        if (Monetization.isSupported)
        {
            Monetization.Initialize("3272263", false);
        }
        ifnumber_0 = 0;       
        Win_Menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneSince_time = Random.Range(4, 8);
        SceneSince_time1 = Random.Range(9, 13);
        score_Label.gameObject.SetActive(false);
        isGuideActive = false;
        isGuideTwoActive = false;
        isTickingSound = false;
        Exit_to_Menu.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && ifnumber_0 == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(LoseSound);
            StartCoroutine(died());
            StartCoroutine(SoundTrackDown());
            _ADS++;
        }
    }

    IEnumerator SoundTrackDown()
    {
        SoundTreck.audioMixer.SetFloat("SoundTreckVolume", -20);
        yield return new WaitForSecondsRealtime(5);
        while(SoundTreck.audioMixer.GetFloat("SoundTreckVolume", out SoundTreckVolume))
        {
            SoundTreck.audioMixer.SetFloat("SoundTreckVolume", SoundTreckVolume + 0.1f);
            if(SoundTreckVolume >= -1)
            {
                break;
            }
        }
    }

    IEnumerator died()
    {
        plumage.Play();
        Exit_to_Menu.SetActive(false);
        score_Label.gameObject.SetActive(false);
        speed = 0;
        PlayerPrefs.SetInt("IsDied", 1); // 0 - жива, 1 - умерла
        guideTwo.SetActive(false);
        yield return new WaitForSecondsRealtime(2);
        if (ifnumber_0 == 0)
        {
            Lose_Menu.gameObject.SetActive(true);
            guideTwo.SetActive(false);
        }
        if (Monetization.IsReady("video") && _ADS % 4 == 0)
        {
            ShowAdCallbacks options = new ShowAdCallbacks();
            ShowAdPlacementContent ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
            ad.Show(options);
        }
        Time.timeScale = 1f;
        ifnumber_0++;
        plumage.Pause();
    }

    IEnumerator BigScoreLabel()
    {
        while(score_Label.transform.localScale.x < 1.5f)
        {
            score_Label.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
        yield return new WaitForSecondsRealtime(1);
        while (score_Label.transform.localScale.x != 1)
        {
            score_Label.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
        }
        ScoreLabelBigIf = 0;
    }

    IEnumerator Win()
    {
        winParticle.Play();
        StartCoroutine(SoundTrackDown());
        _ADS++;
        GetComponent<AudioSource>().PlayOneShot(WinSound);
        scoreLabel.text = "0";
        Destroy(score_Label);
        Destroy(Exit_to_Menu);
        Exit_from_Menu.SetActive(false);
        guideTwo.SetActive(false);
        PlayerPrefs.SetString("Level-2_Open/Closed", "open");
        speed = 0;
        yield return new WaitForSecondsRealtime(3);
        Win_Menu.gameObject.SetActive(true);
        if (Monetization.IsReady("video") && _ADS % 4 == 0)
        {
            ShowAdCallbacks options = new ShowAdCallbacks();
            ShowAdPlacementContent ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;
            ad.Show(options);
        }
    }

    IEnumerator youWin()
    {
        youWinText.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        youWinText.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        youWinText.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        youWinText.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        youWinText.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        youWinText.SetActive(false);
    }

    IEnumerator GuideOne()
    {   
        yield return new WaitForSecondsRealtime(1.4f);
        isTickingSound = true;
        guideOne.SetActive(true);
        guideButtonOne.SetActive(false);
        score_Label.SetActive(false);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1.1f);
        guideButtonOne.SetActive(true);
    }

    public void IsTickingFalse()
    {
        isTickingSound = false;
    }

    IEnumerator GuideTwo()
    {
        yield return new WaitForSecondsRealtime(9);
        if (Lose_Menu.activeSelf == false && Win_Menu.activeSelf == false && guideOne.activeSelf == false)
        {
            isTickingSound = true;
            guideTwo.SetActive(true);
            guideButtonTwo.SetActive(false);
            score_Label.SetActive(false);
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(1.1f);
            guideButtonTwo.SetActive(true);
        }
    }

    IEnumerator TickingSounds()
    {
        if(tickingSoundIndex == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(ticking_Sound_1);
            tickingSoundIndex++;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(ticking_Sound_2);
            tickingSoundIndex--;
        }
        yield return new WaitForSecondsRealtime(1f);
        if(guideOne.activeSelf == false && guideTwo.activeSelf == false && Lose_Menu.activeSelf == false && Exit_to_Menu.activeSelf == true)
        {
            isTickingSound = false;
        }
    }

    void Update()
    {
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time1)
        {
            direction = 1;
        }

        if (Time.timeSinceLevelLoad >= Scene_time && Time.timeSinceLevelLoad > timer_time && ifnumber_0 == 0)
        {
            ifnumber_0++;
            StartCoroutine(Win());
            StartCoroutine(youWin());
            // должно открывать новое меню с переходом на следующий уровень
        }

        if ((Mathf.Round(Time.timeSinceLevelLoad - 3)) % ScoreNumberScale == 0 && ScoreLabelBigIf == 0 && ifnumber_0 == 0 && Time.timeSinceLevelLoad < Scene_time && Time.timeSinceLevelLoad > timer_time)
        {
            StartCoroutine(BigScoreLabel());
            ScoreNumberScale = Mathf.Round(Random.Range(3, 10));
            ScoreLabelBigIf++;
        }

        if (Time.timeSinceLevelLoad <= Scene_time && Time.timeSinceLevelLoad > timer_time)
        {   
            if(isTickingSound  == false)
            {
                StartCoroutine(TickingSounds());
                isTickingSound = true;
            }
            if (isGuideActive == false && Lose_Menu.activeSelf == false && Win_Menu.activeSelf == false)
            {
                StartCoroutine(GuideOne());
                isGuideActive = true;
            }
            if (isGuideTwoActive == false && guideOne.activeSelf == false && Lose_Menu.activeSelf == false && Win_Menu.activeSelf == false)
            {
                StartCoroutine(GuideTwo());
                isGuideTwoActive = true;
            }
            scoreLabel.text = Mathf.Round(Scene_time - Time.timeSinceLevelLoad).ToString();
        }
        if (Time.timeSinceLevelLoad <= timer_time + 1)
        {
            if (Time.timeSinceLevelLoad < 2.5)
            {
                timer.text = Mathf.Round(timer_time - Time.timeSinceLevelLoad).ToString();
            }
            else
            {
                timer.text = "GO!";
                timer_3.transform.localScale = new Vector3(1.9f, 1.9f, 0);
                timer_3.transform.localPosition = new Vector3(-95, 73, 0);
            }
        }
        if (Time.timeSinceLevelLoad > timer_time && ifnumber == 0)
        {
            timer_3.gameObject.SetActive(false);
            score_Label.gameObject.SetActive(true);
            Exit_to_Menu.SetActive(true);
            ifnumber++;

        }
        if (Time.timeSinceLevelLoad > timer_time)
        {
            Vector3 currPos = transform.position;
            transform.RotateAround(point, Vector3.up, Time.deltaTime * speed * direction);
        }
    }

    public void ExitFromMenu()
    {
        Exit_from_Menu.SetActive(false);
        Lose_Menu.SetActive(false);
        Exit_to_Menu.SetActive(true);
        Time.timeScale = 1f;
        if(Time.timeSinceLevelLoad > timer_time)
        {
            score_Label.gameObject.SetActive(true);
        }
    }
}

