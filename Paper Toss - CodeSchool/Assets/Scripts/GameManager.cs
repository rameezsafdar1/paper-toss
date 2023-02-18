using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Initializing variables to be used 

    // An array of gameobjects which will contain all gameobjects of levels
    public GameObject[] Levels;
    // Variable to call a specific level when game starts
    public int currentLevel;

    private void Start()
    {
        Levels[currentLevel].SetActive(true);
    }
}
