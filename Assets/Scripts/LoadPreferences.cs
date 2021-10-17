using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPreferences : MonoBehaviour
{
	int level;
    public Text tlev;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("currentLevel", 0);
    	if (level == 0)
    	{
            level = 1;
    		PlayerPrefs.SetInt("currentLevel", level);
    	}
        tlev.text = level.ToString();
    }
}
