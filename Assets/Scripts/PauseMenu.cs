using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool IsPaused = false;
	public GameObject PauseMenuUI;
    public Button bResume;
    public Button bRestart;
    public Button bExit;

    // Start is called before the first frame update
    void Start()
    {
        bResume.GetComponent<Button>().onClick.AddListener(Resume);
        bRestart.GetComponent<Button>().onClick.AddListener(RestartLevel);
        bExit.GetComponent<Button>().onClick.AddListener(ExitToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESX");
        	if (IsPaused)
        	{
        		Resume();
        	}
        	else
        	{
        		Pause();
        	}
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
    
    void Resume()
    {
    	PauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	IsPaused = false;
    }

    void RestartLevel()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
    }

    void ExitToMenu()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
