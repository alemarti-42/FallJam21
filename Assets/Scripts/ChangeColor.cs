    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    //public GameObject test;
    //public Color color1 = new Color(1f, 1f, 0f, 1f);
    //public Color color2 = new Color(0f, 1f, 1f, 1f);
   // public GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))    
        //{
    }

    void OnTriggerEnter(Collider collider)
    {
        //mat1 = collider.GetComponent<Renderer>().material;
        //mat2 = this.GetComponent<Renderer>().material;
        //Debug.Log("Collision");
        //if (collider.tag == "Paint")
        //{
            //If the GameObject has the same tag as specified, output this message in the console
        if (collider.tag == "Paint" || collider.tag == "Player")
        {
            Debug.Log("Do something else here");
            this.GetComponent<Renderer> ().material.SetColor("_Color",CombineColors(collider.GetComponent<Renderer>().material.GetColor("_Color"), this.GetComponent<Renderer>().material.GetColor("_Color")));

        }
    }   

    public Color CombineColors(Color color1, Color color2)
     {
        //float r_value;
        //float g_value;
        //float b_value;
        //float a_value;
        float max; 
        Color result = new Color(0f,0f,0f,0f);
    
        result += color1;
        result += color2;
        result /= 2;

        max = result.r;
        if (result.g > max)
            max = result.g;
        if (result.b > max)
            max = result.b;

        if (result.r == max)
            result.r = 1f;
        else result.r = 0;
        if (result.g == max)
            result.g = 1f;
        else result.g = 0;
        if (result.b == max)
            result.b = 1f;
        else result.b = 0;

        return result;
       //return new Color(1f, 1f, 0f, 1f);
     }
}
