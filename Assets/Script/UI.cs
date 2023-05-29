using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Button retry;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider Timer;
    public Action endgame;
    public Action<float> timerValue;
    public Action<int> addsScore;

    private void OnEnable()
    {
        endgame+= EndGame;
        timerValue += SlideValue;
        addsScore += ChangeScore;
    }

    private void OnDisable()
    {
        endgame -= EndGame;
        timerValue -= SlideValue;
        addsScore -= ChangeScore;
    }

    private void Start()
    {
        retry.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    void EndGame ()
    {
        panel.SetActive(true);

    }

    void ChangeScore(int score)
    { 
        text.text = score.ToString();
    }

    public void SlideValue( float time)
    { 
        Timer.value = time;
    }
}
