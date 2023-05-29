using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SBlock
{
    [SerializeField]
    private EBlockType type;
    [SerializeField]
    private bool interactable;
    [SerializeField]
    private Sprite blockImage;
    [SerializeField]
    private GameObject Gobject;

    public bool SetInteractable(EBlockType blocktype)
    {

        if (blocktype == EBlockType.Empty)
        {
            interactable = true;
            return interactable;
        }
        interactable= false;
        return interactable;
    }

    public EBlockType SetType(EBlockType blocktype)
    {
        type = blocktype;
        return type;
    }

    public Sprite SetImage(Sprite Image)
    { 
        blockImage= Image;
        return blockImage;
    }

    public bool GetInteractable()
    {
        return interactable;
    }

    public EBlockType GetBType()
    {
        return type;
    }

    public Sprite GetImage()
    {
        return blockImage;
    }

    public GameObject SetGobject(GameObject gobject)
    {
        gobject = Gobject;
        return Gobject;
    }

    public GameObject GetGobject()
    {
        return Gobject;
    }
}
