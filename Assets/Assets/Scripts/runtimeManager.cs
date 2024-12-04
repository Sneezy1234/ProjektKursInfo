using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runtimeManager : MonoBehaviour

{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioListener.pause = false;
    }

    void Update()
    {
        if (pauseMenu.menuOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (pauseMenu.gamePaused)
        {
            AudioListener.pause = true;
            Time.timeScale = 0f;
        }
        else 
        {
            AudioListener.pause = false;
            Time.timeScale = 1f;
        }
    }
}
