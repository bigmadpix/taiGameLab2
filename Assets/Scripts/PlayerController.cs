using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0f;
    private int count = 0;
    public TextMeshProUGUI score;
    public TextMeshProUGUI increment;
    public TextMeshProUGUI winTextObj;
    private int incrementVal;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
}

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
        Debug.Log("Moving");
        incrementVal += 1;
}

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        setScore();
        if(count >= 8)
        {
            winTextObj.gameObject.SetActive(true);
        }
        else
        {
            winTextObj.gameObject.SetActive(false);
        }

        increment.text = "Increment: " + incrementVal.ToString();
    }

    void setScore()
    {
        score.text = "Score: " + count.ToString();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setScore();
        }
        
    }
}
