using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject LevelComplete;

    public void CompleteLevel()
    {
        LevelComplete.SetActive(true);
    }
}
