using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField]private LayerMask layer;
    float delay = 0.1f , current;
    private Vector2Int tempBlock;
    [SerializeField]GridManager gridManager;
    public Action<GameObject> passGameobject;
    private GameObject tempPassGameobject;
    [SerializeField]private NextBlock changeBlock;
    [SerializeField] Timer timer;
    bool startGame = true;
    public Func<bool> EvstartGame, EvendGame;
    [SerializeField]Score score;
    [SerializeField]Block tempRef;

    private void OnEnable()
    {
        passGameobject += PassValue;
        EvstartGame += StartGame;
        EvendGame+= EndGame;
    }

    private void OnDisable()
    {
        passGameobject -= PassValue;
        EvstartGame -= StartGame;
        EvendGame -= EndGame;
    }


    private void Awake()
    {
        _mainCamera = Camera.main;
        current= delay;
    }

    private void Update()
    {
        if (startGame)
        { 
        if (current <= 0)
        {
            RaycastHover(Input.mousePosition);
            current= delay;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastObject(Input.mousePosition);
        }
        current -= Time.deltaTime;
        }
    }

    private void RaycastObject(Vector2 screenPosition)
    {
        Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
        var hit = Physics2D.Raycast(worldPosition, Vector2.zero,Mathf.Infinity,layer);
        if (hit.collider != null)

        { if (hit.collider.transform.TryGetComponent(out Block type))
            {
                /*if(type.GetInteracable())
                Debug.Log(hit.transform);*/
                if (type.GetInteracable())
                {
                    gridManager.changeBlock(hit.transform.gameObject, tempPassGameobject);
                    if (!startGame)
                    {
                        timer.stopTimer();
                        return;
                    }
                    int a = tempRef.AddScore();
                    score.addScore(a);
                    timer.ResetTimer();
                    gridManager.ClearCheckBoard(hit.transform.gameObject, tempPassGameobject);
                    changeBlock.changeBlock();
                    gridManager.clearBlock();
                }
            }

        }
    }


    private void RaycastHover(Vector2 screenPosition)
    {
        Vector2 worldPosition = _mainCamera.ScreenToWorldPoint(screenPosition);
        var hit = Physics2D.Raycast(worldPosition, Vector2.zero, Mathf.Infinity, layer);
        if (hit.collider != null)

        {
            if (hit.collider.transform.TryGetComponent(out Block type))
            {
                //gridmanager check hover block
                if(type.GetInteracable())
                {
                    gridManager.clearBlock();
                    gridManager.checkBlock(hit.transform.gameObject, tempPassGameobject);
                }
            }

        }
    }

    void PassValue(GameObject NextBlock)
    {
        tempPassGameobject = NextBlock;
        tempRef = NextBlock.GetComponent<Block>();
    }

    public bool StartGame()
    {
        startGame = true;
        return startGame;
    }

    public bool EndGame()
    { 
        startGame= false;
        return startGame;
    }
}
