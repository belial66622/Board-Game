using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SocialPlatforms.Impl;

public class Block : MonoBehaviour
{

    [SerializeField] private EBlockType bType;
    [SerializeField]private bool interacable;
    [SerializeField] protected int score;
    [SerializeField] protected Sprite moveCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetEmptyData()
    {
        SetValue(EBlockType.Empty, true);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(true);

    }

    protected virtual void MoveList()
    {

    }

    public EBlockType GetBType()
    {
        return bType;
    }


    public bool GetInteracable()
    {
        return interacable;
    }


    public EBlockType SetBType(EBlockType newtype)
    {

        bType = newtype;
        return bType;
    }


    public bool SetInteracable(bool newinteracable)
    {
        interacable = newinteracable;
        return interacable;
    }

    public int SetScore(int newScore)
    { 
        score= newScore;
        return score;
    }

    public int AddScore()
    {
        return score;
    }

    protected virtual void Move()
    { 
    
    
    }   



    public void GetValue(out EBlockType a, out bool b)
    {
        a = bType;
        b = interacable;
    }

    public void SetValue(EBlockType a, bool b)
    {
        SetBType(a);
        SetInteracable(b);
    }

    public void SetImage(Sprite a)
    { 
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = a;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
    }


    public void AttackZoneEnable(bool setAttackzone)
    { 
        transform.GetChild(1).gameObject.SetActive(setAttackzone);
    }




    public virtual List<Vector2Int> Move(Vector2Int Board, int x, int y)
    {
            List<Vector2Int> moveLocation = new List<Vector2Int>();
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            { }
        }
        return moveLocation;
    }
}
