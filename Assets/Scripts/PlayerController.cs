using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isMoving;
    public bool isDead = false;
    public bool levelComplete = false;
    public float rollSpeed;
    public float fSpeed = 0.0f;
    Vector3 gravity = Vector3.down * -9.8f;
    private Vector3 fallSpeed;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().detectCollisions = false;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (isMoving || PauseMenu.IsPaused) return;
        if (levelComplete == true)
        {
            time += Time.deltaTime;
            fallSpeed -= gravity * Time.deltaTime;
            transform.position += Vector3.down * fallSpeed.y * Time.deltaTime;
            
            return;
        }
        if (isDead == true)
        {
            time += Time.deltaTime;
            //this.transform.position.y += fallSpeed * (time * time);

            fallSpeed += gravity * Time.deltaTime;
            transform.position += Vector3.down * fallSpeed.y * Time.deltaTime;
            //this.GetComponent<Rigidbody>().useGravity = true;
            //this.GetComponent<Rigidbody>().isKinematic = false;
            
            return;
        }
        if (Input.GetKeyDown(KeyCode.A)) Assemble(Vector3.left);
        if (Input.GetKeyDown(KeyCode.D)) Assemble(Vector3.right);
        if (Input.GetKeyDown(KeyCode.W)) Assemble(Vector3.forward);
        if (Input.GetKeyDown(KeyCode.S)) Assemble(Vector3.back);

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Death")
        {
            isDead = true;
        }
    }

    void Assemble(Vector3 dir)
    {
        var anchor = transform.position + (Vector3.down + dir) * 0.5f;
        var axis = Vector3.Cross(Vector3.up, dir);

        StartCoroutine(Roll(anchor, axis));
    }

    IEnumerator Roll(Vector3 anchor, Vector3 axis)
    {
        isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        isMoving = false;
    }
}