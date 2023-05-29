using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]    float timerDelay;
    [SerializeField] UI ui;
    [SerializeField] InputHandler inputHandler;
    public Action resetTimer;
    public Func<bool> stopTimer;
    bool endgame = false;
    private void OnEnable()
    {
        resetTimer += resetTimer;
        stopTimer += StopGame;
    }

    private void OnDisable()
    {
        resetTimer-= resetTimer;
        stopTimer-= StopGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!endgame)
        {
            if (timerDelay <= 0)
            {
                ui.endgame();
                inputHandler.EvendGame();
                endgame = true;
            }
            timerDelay -= Time.deltaTime;
            ui.timerValue(timerDelay);
        }

    }


    public float ResetTimer()
    {
        timerDelay = 10;
        return timerDelay;
    }

    bool StopGame()
    {
        endgame = true;
        return endgame;
    }
}
