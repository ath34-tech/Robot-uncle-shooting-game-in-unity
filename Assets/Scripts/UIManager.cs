using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();

    }
    public Image[] AllImages;
    public static int score;
    public Text Score;
    public void UpdateLives(int currentLive)
    {
        _audio.Play();
        Destroy(AllImages[currentLive]);
    }
    public void UpdateScore(int scoreVal)
    {
        score += scoreVal;
        Score.text = "Score: " + score;
    }
}
