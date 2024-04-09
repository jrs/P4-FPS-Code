using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public TextMeshProUGUI timerText;
    private bool _isTimerRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        //StartGameTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(_isTimerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayGameTimer(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                _isTimerRunning = false;
                GameObject.Find("Game Manager").GetComponent<CrossFade>().FadeIn();
            }
        }
    }

    public void StartGameTimer()
    {
        _isTimerRunning = true;
    }

    public void EndGameTimer()
    {
        _isTimerRunning = false;
    }

    private void DisplayGameTimer(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
