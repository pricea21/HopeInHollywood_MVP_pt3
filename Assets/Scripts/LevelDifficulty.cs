using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDifficulty : MonoBehaviour
{
    public GameObject difficultyPanel;
    public void Regular()
    {
        difficultyPanel.SetActive(false);
    }

    public void HardSP()
    {
        SceneManager.LoadScene("SlidingPuzzleHard");
    }
}
