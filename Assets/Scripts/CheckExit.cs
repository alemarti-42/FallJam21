using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckExit : MonoBehaviour
{
    public GameObject TargetColor;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Renderer>().material.GetColor("_Color") == TargetColor.GetComponent<Renderer>().material.GetColor("_Color"))
        {
            Debug.Log("Congratulations!");
            Player.GetComponent<PlayerController>().levelComplete = true;
        }
        //else Debug.Log("Failure");
    }
}
