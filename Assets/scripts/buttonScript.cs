using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {
    public GameObject PauseMenu;
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Pause(PauseMenu);
	}
    public void Play(int x)
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
        if (Time.timeScale == 1 && AudioListener.volume == 1)
            SceneManager.LoadScene(x);
        
       
        
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause(GameObject pauseMenu)
    {
        
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            AudioListener.volume = 0;
            pauseMenu.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
            pauseMenu.SetActive(false);

        }
    }
}
