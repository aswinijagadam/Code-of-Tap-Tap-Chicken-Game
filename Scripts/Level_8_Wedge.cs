using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Monetization;
using UnityEngine.Audio;

public class Level_8_Wedge : MonoBehaviour
{
    public float speed = 150f;
    float direction = 1;
    float SceneSince_time;
    float SceneSince_time1;
    float SceneSince_time2;
    float SceneSince_time3;
    float SceneSince_time4;
    float SceneSince_time5;
    float SceneSince_time6;
    float SceneSince_time7;
    float SceneSince_time8;
    float SceneSince_time9;
    float SceneSince_time10;
    float SceneSince_time11;
    float SceneSince_time12;
    float SceneSince_time13;
    float SceneSince_time14;
    float SceneSince_time15;
    float SceneSince_time16;
    float SceneSince_time17;
    float SceneSince_time18;
    float SceneSince_time19;
    float SceneSince_time20;
    float SceneSince_time21;
    float SceneSince_time22;
    float SceneSince_time23;
    float SceneSince_time24;
    float SceneSince_time25;
    float SceneSince_time26;
    float SceneSince_time27;
    float SceneSince_time28;
    float SceneSince_time29;
    float SceneSince_time30;
    float SceneSince_time31;
    float SceneSince_time32;
    float SceneSince_time33;
    float SceneSince_time34;
    public float Scene_time = 23;
    float timer_time = 3;
    int ifnumber = 0;
    int ifnumber_0 = 0;

    [SerializeField] private AudioClip ticking_Sound_1;
    [SerializeField] private AudioClip ticking_Sound_2;
    int tickingSoundIndex = 0;
    private bool isTickingSound;

    private static int _ADS = 1;

    private float SoundTreckVolume;

    [SerializeField] private GameObject Lose_Menu;
    [SerializeField] private GameObject Win_Menu;

    [SerializeField] private ParticleSystem plumage;

    [SerializeField] private GameObject youWinText;

    [SerializeField] private GameObject Exit_to_Menu;
    [SerializeField] private GameObject Exit_from_Menu;

    public AudioClip WinSound;
    public AudioClip LoseSound;
    public AudioMixerGroup SoundTreck;

    public ParticleSystem winParticle;

    private GameObject chicken;

    int ScoreLabelBigIf = 0;
    float ScoreNumberScale;

    [SerializeField] private GameObject score_Label;

    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text timer;
    [SerializeField] private GameObject timer_3;
    Vector3 point = new Vector3(-1.23f, -1.12f, 0.68f);

    public void ExitFromMenu()
    {
        Exit_from_Menu.SetActive(false);
        Lose_Menu.SetActive(false);
        Exit_to_Menu.SetActive(true);
        Time.timeScale = 1f;
        if (Time.timeSinceLevelLoad > timer_time)
        {
            score_Label.gameObject.SetActive(true);
        }
    }

    void Start()
    {
        winParticle.Stop();
        ScoreNumberScale = Mathf.Round(Random.Range(3, 7));
        PlayerPrefs.SetInt("IsDied", 0);
        youWinText.SetActive(false);
        if (Monetization.isSupported)
        {
            Monetization.Initialize("3272263", false);
        }
        Win_Menu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneSince_time = Random.Range(4, 8);
        SceneSince_time1 = Random.Range(9, 13);
        SceneSince_time2 = Random.Range(15, 20);
        SceneSince_time3 = Random.Range(21, 26);
        SceneSince_time4 = Random.Range(27, 30);

        SceneSince_time5 = Random.Range(31, 34);
        SceneSince_time6 = Random.Range(35, 39);
        SceneSince_time7 = Random.Range(40, 45);
        SceneSince_time8 = Random.Range(46, 51);

        SceneSince_time9 = Random.Range(52, 56);
        SceneSince_time10 = Random.Range(57, 59);
        SceneSince_time11 = Random.Range(60, 64);
        SceneSince_time12 = Random.Range(66, 70);

        SceneSince_time13 = Random.Range(71, 74);
        SceneSince_time14 = Random.Range(75, 78);
        SceneSince_time15 = Random.Range(79, 84);
        SceneSince_time16 = Random.Range(85, 88);

        SceneSince_time17 = Random.Range(90, 93);
        SceneSince_time18 = Random.Range(94, 98);
        SceneSince_time19 = Random.Range(100, 104);
        SceneSince_time20 = Random.Range(105, 108);

        SceneSince_time21 = Random.Range(109, 112);
        SceneSince_time22 = Random.Range(113, 117);
        SceneSince_time23 = Random.Range(118, 121);
        SceneSince_time24 = Random.Range(123, 127);

        SceneSince_time25 = Random.Range(128, 132);
        SceneSince_time26 = Random.Range(133, 135);
        SceneSince_time27 = Random.Range(136, 140);
        SceneSince_time28 = Random.Range(142, 147);

        SceneSince_time29 = Random.Range(148, 151);
        SceneSince_time30 = Random.Range(152, 156);
        SceneSince_time31 = Random.Range(157, 160);
        SceneSince_time32 = Random.Range(161, 165);

        SceneSince_time33 = Random.Range(166, 170);
        SceneSince_time34 = Random.Range(172, 176);
        isTickingSound = false;
        score_Label.gameObject.SetActive(false);
        Exit_to_Menu.SetActive(false);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && ifnumber_0 == 0)
        {
            StartCoroutine(SoundTrackDown());
            GetComponent<AudioSource>().PlayOneShot(LoseSound);
            StartCoroutine(died());
            _ADS++;
        }
    }

    IEnumerator SoundTrackDown()
    {
        SoundTreck.audioMixer.SetFloat("SoundTreckVolume", -20);
        yield return new WaitForSecondsRealtime(5);
        while (SoundTreck.audioMixer.GetFloat("SoundTreckVolume", out SoundTreckVolume))
        {
            SoundTreck.audioMixer.SetFloat("SoundTreckVolume", SoundTreckVolume + 0.1f);
            if (SoundTreckVolume >= -1)
            {
                break;
            }
        }
    }

    IEnumerator died()
    {
        plumage.Play();
        PlayerPrefs.SetInt("IsDied", 1);
        Exit_to_Menu.SetActive(false);
        score_Label.gameObject.SetActive(false);
        speed = 0;
        yield return new WaitForSecondsRealtime(2);
        if (ifnumber_0 == 0)
        {
            Lose_Menu.gameObject.SetActive(true);
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
        while (score_Label.transform.localScale.x < 1.5f)
        {
            score_Label.transform.localScale += new Vector3(0.09f, 0.09f, 0);
        }
        yield return new WaitForSecondsRealtime(1);
        while (score_Label.transform.localScale.x != 1)
        {
            score_Label.transform.localScale -= new Vector3(0.09f, 0.09f, 0);
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
        PlayerPrefs.SetString("Level-10_Open/Closed", "open");
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

    IEnumerator TickingSounds()
    {
        if (tickingSoundIndex == 0)
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
        if (Lose_Menu.activeSelf == false && Exit_to_Menu.activeSelf == true)
        {
            isTickingSound = false;
        }
    }

    public void IsTickingFalse()
    {
        isTickingSound = false;
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
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time2)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time3)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time4)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time5)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time6)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time7)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time8)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time9)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time10)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time11)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time12)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time13)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time14)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time15)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time16)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time17)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time18)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time19)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time20)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time21)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time22)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time23)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time24)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time25)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time26)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time27)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time28)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time29)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time30)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time31)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time32)
        {
            direction = -1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time33)
        {
            direction = 1;
        }
        if (Mathf.Round(Time.timeSinceLevelLoad) - 3 == SceneSince_time34)
        {
            direction = -1;
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
            if (isTickingSound == false)
            {
                StartCoroutine(TickingSounds());
                isTickingSound = true;
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
}

