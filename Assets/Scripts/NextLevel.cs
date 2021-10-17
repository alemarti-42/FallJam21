using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
     
    /*public class Example
    {
        public void LoadLevel()
    {
            // load the nextlevel
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
     
        }
    }*/


public class NextLevel : MonoBehaviour
{
    int level;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("currentLevel", 0);
        //Debug.Log(PlayerPrefs.GetInt("currentLevel"));
        //SceneManager.LoadScene(level);
    }

    // Update is called once per frame
    void Update()
    {
    
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
