using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private Vector3 origin;
    private float time;
    [SerializeField] private float speed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        origin = new Vector3(0,0,0);
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentRotation = transform.eulerAngles;

        // Update the Y-axis rotation
        currentRotation.y += speed * Time.deltaTime;

        // Apply the new rotation
        transform.eulerAngles = currentRotation;
    }
}
