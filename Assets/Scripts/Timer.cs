using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    private bool TimerOn = false;
    private float TimeLeft;
    private bool[] PuzzleTimesSaved = { false, false, false };

    void Start()
    {
        TimeLeft = GameManager.MainTimerLength;
        TimerOn = true;   
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
                CheckPuzzleProgres();
            }
            /*  // early ending - for testing
            if (TimeLeft < 840)
            {
                GameManager.GameEnded = true;
            }
            */
        }
        else
        {
            TimeLeft = 0;
            TimerOn = false;
            GameManager.GameEnded = true;
        }
    }

    void UpdateTimer(float currentTime)
    {
        if (!GameManager.GameEnded) 
        {
            currentTime++;
            float minutes = Mathf.FloorToInt(currentTime / 60);
            float seconds = Mathf.FloorToInt(currentTime % 60);

            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }
    }

    void CheckPuzzleProgres()
    {
        if (GameManager.FirstPuzzleSolved && !PuzzleTimesSaved[0])
        {
            GameManager.PuzzleSolveTimes[0] = GameManager.MainTimerLength - TimeLeft;
            PuzzleTimesSaved[0] = true;
        }
        else if (GameManager.SecondPuzzleSolved && !PuzzleTimesSaved[1])
        {
            GameManager.PuzzleSolveTimes[1] = GameManager.MainTimerLength - TimeLeft;
            if (GameManager.FirstPuzzleSolved)
            {
                GameManager.PuzzleSolveTimes[1] -= GameManager.PuzzleSolveTimes[0];
                Debug.Log(GameManager.PuzzleSolveTimes[1]);
                PuzzleTimesSaved[1] = true;
            }
        }
        else if (GameManager.ThirdPuzzleSolved && !PuzzleTimesSaved[2])
        {
            GameManager.PuzzleSolveTimes[2] = GameManager.MainTimerLength - TimeLeft;
            if (GameManager.FirstPuzzleSolved)
            {
                GameManager.PuzzleSolveTimes[2] -= GameManager.PuzzleSolveTimes[0];
            }
            if (GameManager.SecondPuzzleSolved)
            {
                GameManager.PuzzleSolveTimes[2] -= GameManager.PuzzleSolveTimes[1];
            }
            GameManager.GameWon = true;
            PuzzleTimesSaved[2] = true;
        }
    }
}
