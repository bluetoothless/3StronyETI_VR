using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool isComputerOn = true;
    public static VM_Image SelectedImage;
    public static VM_Socket SelectedSocket;
    public static VM_Ram SelectedRam;
    public static bool codedLocker1Opened = false;
    public static bool codedLocker2Opened = false;
    public static string code1 = "2195";
    public static string code2 = "59138";
    public static string currentCombination1 = "";
    public static string currentCombination2 = "";
    public static bool resettingLockerColor1 = false;
    public static bool resettingLockerColor2 = false;

    public static float MainTimerLength = 900; // in seconds; 900 s = 15 min
    public static bool GameEnded = false;
    public static float[] PuzzleSolveTimes = { 0.0f, 0.0f, 0.0f };

    public static bool FirstPuzzleSolved = false;
    public static bool SecondPuzzleSolved = false;
    public static bool ThirdPuzzleSolved = false;
    public static bool GameWon = false;

    void Awake()
    {
        SelectedImage = VM_Image.Ubuntu;
        SelectedRam = VM_Ram.Ram_2048MB;
        Instance = this;
    }

    public enum Locker
    {
        Red,
        Coded1,
        Coded2
    }

    public enum VM_Image
    {
        Debian,
        LinuxMint,
        Redhat,
        Ubuntu,
        Empty
    }

    public enum VM_Socket
    {
        Image1, 
        Image2, 
        Image3, 
        Image4
    }

    public enum VM_Ram
    {
        Ram_512MB, 
        Ram_1024MB, 
        Ram_2048MB, 
        Ram_4096MB, 
        Ram_8192MB
    }
}