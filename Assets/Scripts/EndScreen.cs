using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject EndGamePanel;
    public TMP_Text GameWonOrTimeUpLabel;
    public TMP_Text GameFinishedTimeLabel;
    public TMP_Text FirstPuzzleFinishedTimeLabel;
    public TMP_Text SecondPuzzleFinishedTimeLabel;
    public TMP_Text ThirdPuzzleFinishedTimeLabel;
    public TMP_Text RecommendedFieldLabel;
    private bool fieldDetermined = false;

    void Update()
    {
        if (GameManager.GameEnded & !fieldDetermined)
        {
            EndGamePanel.SetActive(true);
            if (GameManager.GameWon)
            {
                GameWonOrTimeUpLabel.text = "You escaped!";
            }
            else
            {
                GameWonOrTimeUpLabel.text = "Time's up!";
            }

            float totalTime = 0;
            foreach (float time in GameManager.PuzzleSolveTimes)
            {
                totalTime += time;
            }
            GameFinishedTimeLabel.text = SecondsToFormattedTime(totalTime).ToString();
            FirstPuzzleFinishedTimeLabel.text = SecondsToFormattedTime(GameManager.PuzzleSolveTimes[0]).ToString();
            SecondPuzzleFinishedTimeLabel.text = SecondsToFormattedTime(GameManager.PuzzleSolveTimes[1]).ToString();
            ThirdPuzzleFinishedTimeLabel.text = SecondsToFormattedTime(GameManager.PuzzleSolveTimes[2]).ToString();
            RecommendedFieldLabel.text = DetermineFieldOfStudy();
            fieldDetermined = true;
        }
    }

    string SecondsToFormattedTime(float timeInSeconds)
    {
        float minutes = Mathf.FloorToInt(timeInSeconds / 60);
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    string DetermineFieldOfStudy()
    {
        if (!GameManager.FirstPuzzleSolved && !GameManager.SecondPuzzleSolved && !GameManager.ThirdPuzzleSolved)
        {
            return "Jêzyk polski na UG";
        }

        float minSolveTime = float.MaxValue;
        int puzzleIndex = -1;

        for (int i = 0; i < GameManager.PuzzleSolveTimes.Length; i++)
        {
            float time = GameManager.PuzzleSolveTimes[i];
            if (time < minSolveTime && time != 0)
            {
                
                minSolveTime = time;
                puzzleIndex = i;
            }
        }

        switch(puzzleIndex)
        {
            case 0: // first puzzle solved the fastest
                return "Elektronika i telekomunikacja";
            case 1: // second puzzle solved the fastest
                return "Informatyka";
            case 2: // third puzzle solved the fastest
                return "Automatyka, cybernetyka i robotyka";
        }

        return "Jêzyk polski na UG";
    }
}
