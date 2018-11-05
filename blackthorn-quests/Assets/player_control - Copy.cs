using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_control : MonoBehaviour
{

    private Rigidbody rb;

    public float speed;

    public Text CountText;

    int count;

    public Text WinText;

    void Start()
    {
        count = 0;
        SetCountText();
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
        if (other.gameObject.CompareTag("Pick Up"))
        {
            count = count + 1;
            other.gameObject.SetActive(false);
            SetCountText();
            if (count >= 14)
            {
                WinText.text = "You are victorious!";
            }
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
    }
   
}