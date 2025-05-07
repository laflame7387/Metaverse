using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;    
    public static GameManager Instance { get { return gameManager; } }
    
    int currentScore = 0;
    public int bestscore = 0;

    private const string BestScoreKey = "BestScore";

    SceneChanger sceneChanger;
    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }
    private void Awake()
    {
        gameManager = this;  
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateBestScore(bestscore);
        bestscore = PlayerPrefs.GetInt(BestScoreKey, 0 );
    }
    public void GameOver()
    {
        uiManager.SetRestart(true);
        AddBestScore();
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        uiManager.SetRestart(false);
        sceneChanger.GoMiniGame();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log("Score: " +  currentScore);
        uiManager.UpdateScore(currentScore);
    }

    public void AddBestScore()
    {
        if(bestscore <= currentScore)
        {
            bestscore = currentScore;
            PlayerPrefs.SetInt(BestScoreKey, bestscore);
            PlayerPrefs.Save();
            uiManager.UpdateBestScore(bestscore);
        }
        else
        {
            uiManager.UpdateBestScore(bestscore);
        }
    }
}
