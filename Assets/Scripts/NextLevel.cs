using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevel : MonoBehaviour
{
   int level;

    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("currentLevel");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            PlayerPrefs.SetInt("currentLevel", level + 1);
            SceneManager.LoadScene(PlayerPrefs.GetInt("currentLevel"));
        }
    }
}
