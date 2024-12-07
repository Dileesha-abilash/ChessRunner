
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamera : MonoBehaviour
{
    // Reference to the RotateAround script
    public RotateAround rot;
    [SerializeField] private GameObject cam;
    private float upwardSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (rot != null) // Check if rot is assigned
        {
            // Initialize upwardSpeed from rot
            upwardSpeed = rot.upwardSpeed;
        }
        else
        {
            Debug.LogError("RotateAround script is not assigned in BasicCamera!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rot != null) // Ensure rot is not null
        {
            transform.position += Vector3.up * upwardSpeed * Time.deltaTime;
        }
    }
}
