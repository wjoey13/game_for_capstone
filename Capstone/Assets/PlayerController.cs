using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float gravity;
    [SerializeField] float jumpSpeed;

    Vector3 moveDirection;
    CharacterController characterController;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        moveDirection = moveInput;
        moveDirection *= moveSpeed;

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
	}
}
