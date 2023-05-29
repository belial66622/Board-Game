using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SocialPlatforms.Impl;

public class Rock : Block
{
    public override List<Vector2Int> Move(Vector2Int Board, int x, int y)
    {
        List<Vector2Int> moveLocation = new List<Vector2Int>();

        for (int i = Board.y - 1; i >= 0; i--)
        {
            moveLocation.Add(new Vector2Int( Board.x, i));
        }
        for (int i = Board.y +1; i < y; i++)
        {
            moveLocation.Add(new Vector2Int(Board.x, i));
        }
        for (int i = Board.x - 1; i >= 0; i--)
        {
            moveLocation.Add(new Vector2Int(i, Board.y));
        }
        for (int i = Board.x + 1; i < x; i++)
        {
            moveLocation.Add(new Vector2Int(i, Board.y));
        }

        return moveLocation;
    }


}
