using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NextBlock : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tBlock;
    [SerializeField]private GameObject block, temp;
    [SerializeField]private InputHandler nextBlock;
    public Func<GameObject> changeBlock;
    [SerializeField]private EBlockType tempE;
    [SerializeField]private bool tempbool;
    [SerializeField]private int tempint;


    private void OnEnable()
    {
        changeBlock += RandomBlock;  
    }

    private void OnDisable()
    {
        changeBlock -= RandomBlock;
    }


    // Start is called before the first frame update
    void Start()
    {
        RandomBlock();
        
    }

    public GameObject RandomBlock ()
    {   

        block = tBlock[UnityEngine.Random.Range(0, tBlock.Count)];
     //   block = tBlock[3];



        block.GetComponent<Block>().GetValue(out tempE, out tempbool);

        temp.GetComponent<Block>().SetValue(tempE, tempbool);

        temp.GetComponent<Block>().SetImage(block.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite);
        nextBlock.passGameobject(block);
            
        return block;
            //block.GetComponent<SpriteRenderer>().sortingOrder = 3;

       
    }



}

