using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AntennaPieceItem : PuzzleItem
{
    public GameObject kod1;

    void Update()
    {
        bool allPiecesCorrect = true;
        foreach (bool correctPosition in GameManager.correctAntennaPiecePositions)
        {
            if (!correctPosition)
            {
                allPiecesCorrect = false;
            }
        }

        if (allPiecesCorrect)
        {
            GameManager.FirstPuzzleSolved = true;
            kod1.SetActive(true);
        }
    }

}
