using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public static PauseUI instance;
    bool isGamePaused = false;
    public GameObject UI;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        UI.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIControl();
        }
    }

    public void UIControl()
    {
        if(!isGamePaused)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        UI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
