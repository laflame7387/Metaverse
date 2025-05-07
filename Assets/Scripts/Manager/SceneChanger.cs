using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    UIManager uiManager;
    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void GoMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }
}
