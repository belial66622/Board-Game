using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Action<int> addScore;
    [SerializeField] UI ui;
    int score;

    private void OnEnable()
    {
        addScore += AddScore;
    }

    private void OnDisable()
    {
        addScore -= AddScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { Application.Quit(); }
        
    }

    void AddScore(int a)
    {
        score += a;
        ui.addsScore(score);
    }

}
