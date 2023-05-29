using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;

public class Bishop : Block
{
    public override List<Vector2Int> Move(Vector2Int Board, int x, int y)
    {
        List<Vector2Int> moveLocation = new List<Vector2Int>();


        for (int i = Board.x + 1 , j = Board.y - 1 ; i < x && j >= 0; i++ , j--)
        {
                moveLocation.Add(new Vector2Int(i, j));

        }

        for (int i = Board.x + 1 , j = Board.y + 1; i < x && j < y; i++ , j++)
        {

                moveLocation.Add(new Vector2Int(i, j));
        }


        for (int i = Board.x - 1, j = Board.y - 1; i >= 0 && j >= 0 ; i--, j--)
        {

                moveLocation.Add(new Vector2Int(i, j));

        }

        for (int i = Board.x - 1 , j = Board.y + 1; i >= 0 && j < y; i-- , j++)
        {

                moveLocation.Add(new Vector2Int(i, j));

        }





        return moveLocation;
    }

}
