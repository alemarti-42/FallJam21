using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
	public Text tlev;
	int level;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
    	PlayerPrefs.SetInt("currentLevel", 1);
    	level = PlayerPrefs.GetInt("currentLevel");
    	tlev.text = level.ToString();
    }
}
