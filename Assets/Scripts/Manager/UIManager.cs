using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject ResultUI;

    [SerializeField] private GameObject eventText;
    [SerializeField] private GameObject eventUI;

    [SerializeField] private TextMeshProUGUI resultScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    private void Start()
    {
        
    }

    public void PressFkey(bool state)
    {
        eventText.SetActive(state);
    }
    public void ShowMiniGameUI_ON()
    {
        eventUI.SetActive(true);
    }
    public void ShowMiniGameUI_OFF()
    {
        eventUI.SetActive(false);
    }
    public void SetRestart(bool state)
    {
        ResultUI.SetActive(state);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
        resultScore.text = score.ToString();
    }

    public void UpdateBestScore(int score)
    {
        bestScore.text = score.ToString();
    }
    
}
