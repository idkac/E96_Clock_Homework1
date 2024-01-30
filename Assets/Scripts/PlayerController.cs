using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    float speed = 5f;

    bool onGround;

    int jump_count = 0;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        
        rb.velocity = v.y * transform.forward + v.x * transform.right;
    
        rb.velocity *= speed;
    }

    void OnJump(InputValue value)
    {
        if (onGround || jump_count < 2){
        Debug.Log(jump_count);
        Vector3 v = new Vector3(0, 0, 1);

        rb.velocity = v.z * Vector3.up;

        rb.velocity *= speed;

        jump_count++;
        }
        if (!onGround)
            return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("this happened enter");
            onGround = true;
            jump_count = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("this happened");
            onGround = false;
        }
    }


}
