using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;
using UnityEngine.UIElements;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    InputHandler inputHandler;
    [SerializeField]
    private int col, row;
    [SerializeField]
    private GameObject[,] grid;
    [SerializeField]
    private SBlock block;
    [SerializeField]
    private List<Sprite> blockImage;
    [SerializeField]
    private GameObject singleBlock;
    public Action<GameObject, GameObject> changeBlock , checkBlock, ClearCheckBoard;
    public Action clearBlock ;
    private Vector2Int[] gTemp;
    private List<Vector2Int> tempValue;
    [SerializeField] private Block currentBlock;
    private Block[,] allBlock;
    private bool checkLoseCondition;
    [SerializeField]private UI endgame;

    private void OnEnable()
    {
        clearBlock += clear;
        checkBlock += CheckCurBlock;
        changeBlock += ChangeCurBlock;
        ClearCheckBoard += checkBoard;
    }


    private void OnDisable()
    {
        clearBlock -= clear;
        checkBlock -= CheckCurBlock;
        changeBlock -= ChangeCurBlock;
        ClearCheckBoard -= checkBoard;
    }


    // Start is called before the first frame update
    void Start()
    {
        MakeTable();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MakeTable()
    {
        grid = new GameObject[col, row];
        allBlock = new Block[col, row];

        for (int x = 0; x < col; x++)
        { for (int y = 0; y < row; y++)

            {
                grid[x, y] = GenerateSingleBlock(x, y);
                allBlock[x,y] = grid[x,y].GetComponent<Block>();
            }
        }
    }



    GameObject GenerateSingleBlock(int i, int j)
    {
        float x = -7 + (i % col) * 1.25f;
        float y = 3 - (math.floor(j % row)) * 1.25f;
        GameObject temp = Instantiate(singleBlock,transform);
        temp.name = (string.Format("X:{0}, Y:{1}", i + 1, j + 1));
        //new GameObject(string.Format("X:{0}, Y:{1}", i + 1, j + 1));
        //temp.transform.parent = this.transform;
        temp.transform.position = new Vector2(x, y);
        temp.transform.localScale = new Vector2(1.25f, 1.25f);



        //Utility.GetRandomEnum<EBlockType>();


        /*
         *  Debug.Log(block[i, j].GetBType());
         block[i, j].SetType(EBlockType.Empty);
        block[i, j].SetInteractable(EBlockType.Empty);
        block[i, j].SetImage(blockImage[UnityEngine.Random.Range(0, blockImage.Count)]);
         
         */
        /*            
         *            

                      GameObject temp;
                      temp = Instantiate(cardleft, transform);

                      temp.transform.GetComponentInChildren<SpriteRenderer>().sprite = newDeckCard[i].Card();
                      temp.transform.localScale = new Vector2(0.5f, 0.5f);*/

        return temp;
    }



    Sprite SetImage(EBlockType a)
    {
        return blockImage[(int)a];
    }

    void clear()
    {
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            { allBlock[x, y].AttackZoneEnable(false); }
        }
    }

    void CheckCurBlock (GameObject hitinfo, GameObject passGameobject)
    {

        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                if (grid[x, y] == hitinfo)
                {
                    checkLoseCondition = false;
                    currentBlock = passGameobject.GetComponent<Block>();
                    //Debug.Log(hitinfo.transform);
                   tempValue =  currentBlock.Move(new Vector2Int (x,y), col, row);

                    for (int i = 0; i < tempValue.Count; i++)
                    {
                        if (!allBlock[tempValue[i].x, tempValue[i].y].GetInteracable())
                        { 
                            checkLoseCondition = true;
                        }
                        allBlock[tempValue[i].x, tempValue[i].y].AttackZoneEnable(true);
                    }
                }

            }

        }


    }


    void ChangeCurBlock(GameObject hitinfo,GameObject passGameObject)
    {
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                if (grid[x, y] == hitinfo)
                {
                    grid[x, y].GetComponent<Block>().SetValue(passGameObject.GetComponent<Block>().GetBType(), passGameObject.GetComponent<Block>().GetInteracable());
                    grid[x, y].GetComponent<Block>().SetImage(passGameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite) ;
                    Debug.Log(checkLoseCondition);
                    if (checkLoseCondition)
                    { 
                        inputHandler.EvendGame();
                        endgame.endgame();
                    }
                    return;
  
                }

            }

        }
    }

    void checkBoard(GameObject hitinfo, GameObject passGameObject)
    {
        gTemp = new Vector2Int[3];
        int i = 0;
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                if (passGameObject.GetComponent<Block>().GetBType() == grid[x, y].GetComponent<Block>().GetBType())
                {
                    gTemp[i] = new Vector2Int(x,y);
                    i++;
                }

                if (i == 3)
                {
                    for (int a=0; a < 3; a++)
                    {
                        grid[gTemp[a].x,gTemp[a].y].GetComponent<Block>().SetEmptyData();
                    }
                }

            }
        }
    }

}
