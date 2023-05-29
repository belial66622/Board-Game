using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class Dragon : Block
{
    public override List<Vector2Int> Move(Vector2Int Board, int x, int y)
    {
        List<Vector2Int> moveLocation = new List<Vector2Int>();

        int i = Board.x ;
        int j = Board.y + 1;

        if (j < y)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x;
        j = Board.y - 1;

        if (j >= 0)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x + 1;
        j = Board.y ;

        if (i < x)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x + 1;
        j = Board.y - 1;

        if (i < x && j >= 0)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x - 1;
        j = Board.y ;

        if (i >= 0)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x - 1;
        j = Board.y - 1;

        if (i >= 0 && j >= 0)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x - 1;
        j = Board.y + 1;

        if (i >= 0 && j < y)
            moveLocation.Add(new Vector2Int(i, j));

        i = Board.x + 1;
        j = Board.y + 1;

        if (i < x && j < y)
            moveLocation.Add(new Vector2Int(i, j));

        return moveLocation;
    }


}
