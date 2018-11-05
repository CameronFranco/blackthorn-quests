using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControl : MonoBehaviour {

    private Rigidbody rb;

    public float speed;

    public Text WinText;

    private bool Q1;

    private int qCount;

    public float time;

    void Start()
    { 
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical * 0.1f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Q"))
        {
            qCount++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject. CompareTag("Finish"))
        {
            if (qCount == 3)
            {
                WinText.text = "You have finished! You completed the maze, crossed the sphere, and did not fly off the the ramp into neverending oblivion!!!";
            }
               
        }


    }
}
