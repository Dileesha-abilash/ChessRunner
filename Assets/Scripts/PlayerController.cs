using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int laneNumber = 0;
    private CharacterController controller; 
    private float LineWidth = 0.3f;
    public Vector3 direction;
    private Vector3 startingValue = new Vector3(9f, 1, 0);
    public float forceForward;

    private  Vector3 getTheposition(int lanenumber)
    {
        
        startingValue.x =0.9f*laneNumber +9f;
        return startingValue;
    }    
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        transform.position = startingValue;
        Debug.Log(controller);
    }

    private void Update()
    {
        direction.z = forceForward;

        if (laneNumber<-1)
        {
            laneNumber = 1;
        }
        if (laneNumber>1)
        {
            laneNumber = -1;
        }

        transform.position = getTheposition(laneNumber);
        
        
        if (Input.GetButtonDown("Horizontal"))
        {
            //laneNumber += 1;
            //startingValue.x += 0.3f;
            //transform.position= startingValue;
        

            
        if (Input.GetKey(KeyCode.RightArrow))
        {

            laneNumber += 1;
            
            //startingValue.x -= 0.3f;
           // transform.position= startingValue;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            laneNumber += -1;
            
            //startingValue.x -= 0.3f;
           // transform.position= startingValue;
        }
        
            Debug.Log(laneNumber);
    }
}
    // Update is called once per frame
    void FixedUpdate()
    {
 //       controller.Move(direction * Time.fixedTime);
    }
}
