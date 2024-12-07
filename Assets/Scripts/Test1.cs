using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    private CharacterController controller;
    public float GravityScale ;
    private float jumpSpeed =200f; 
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
            
        Debug.Log("jacerj");    
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal")*speed,0f,Input.GetAxis("Vertical"));
        if (controller.isGrounded)
        {
            
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }

        }
        moveDirection.y = moveDirection.y + Physics.gravity.y* Time.deltaTime * GravityScale;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
