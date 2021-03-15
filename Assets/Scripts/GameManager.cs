using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    
    public Text currentScoreUI;
    private int currentScore;
    public Text bestScoreUI;
    private int bestScore;
    public Text hp;

    private int currentLevel = 0;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int Score
    {
        get
        {   
            return currentScore;
        }

        set
        {
            // hp.text = "Hp : " + Player.instance2.Hp;
            
            currentScore = value;
            currentScoreUI.text = "Score : " + currentScore;
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                bestScoreUI.text = "Best : " + bestScore;
                PlayerPrefs.SetInt("Best Score", bestScore);
            }

        }
    }
}

