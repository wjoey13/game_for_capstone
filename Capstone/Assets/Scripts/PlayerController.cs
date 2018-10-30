using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float gravity;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallControl;

    Vector3 moveDirection;
    CharacterController characterController;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (characterController.isGrounded) 
        {
            moveDirection = moveInput;
            moveDirection *= moveSpeed;
            if(Input.GetButton("Jump")){
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection = new Vector3(moveInput.x * fallControl, moveDirection.y, moveInput.z * fallControl);
        }
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
	}
}
