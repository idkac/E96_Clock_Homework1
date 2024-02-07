using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rb;
    [SerializeField] GameObject Bullet;
    float speed = 5f;

    bool onGround;

    int jump_count = 0;
    public int maxBullets = 20; 
    private int currentBullets = 20;
    private UIManager uiManager;
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnFire()
    {
        uiManager.UpdateAmmo(currentBullets);
        if (currentBullets > 0)
        {
            GameObject bulletInstance = Instantiate(Bullet, transform.position + 0.5f * transform.forward, Quaternion.identity);
            Rigidbody bulletRigidbody = bulletInstance.GetComponent<Rigidbody>();

            bulletRigidbody.AddForce(1000f * transform.forward);
            currentBullets--;
        }
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        rb.velocity = v.y * transform.forward + v.x * transform.right;

        rb.velocity *= speed;
    }

    void OnJump(InputValue value)
    {
        if (onGround || jump_count < 2)
        {
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
            onGround = true;
            jump_count = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }


}
