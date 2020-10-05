using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;

    public Text countdown;

    private float highScore;
    public Text highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highScore");
        highScoreText.text = "HighScore: " + highScore.ToString();
    }


    public void startCountdown()
    {
        currentTime = startingTime;
        SoundManager.PlaySound("Play");
        countdown.color = Color.red;
        InvokeRepeating("Countdown", 0, 0.05f);
    }

    private void Countdown()
    {
        currentTime -= 10 * Time.deltaTime;
        countdown.text = currentTime.ToString("0");

        if (currentTime < 0.5f)
        {
            countdown.text = "GO!!!";
        }

        if (currentTime < 0)
        {
            startGame();
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("Main");
    }
}
