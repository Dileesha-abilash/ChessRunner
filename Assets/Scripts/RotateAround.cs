using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject pivitCylinder;

    // Speed of upward movement
    public float upwardSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Optional initialization
    }

    // Update is called once per frame
    void Update()
    {
        // Move the GameObject upwards continuously
        transform.position += Vector3.up * upwardSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Horizontal"))
        {
            
        // Check for input and rotate around the pivotCylinder if necessary
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(pivitCylinder.transform.position, new Vector3(0, 1, 0), 120f );
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(pivitCylinder.transform.position, new Vector3(0, 1, 0), -120f );
        }
    }
}
        }