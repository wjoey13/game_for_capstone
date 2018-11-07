using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float gravity;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallControl;
    public Rigidbody playerRigidbody;
    public int floorMask;
    public float camRayLength = 100f;

    Vector3 moveDirection;
    CharacterController characterController;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
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
        Turning(); 
	}

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength,floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }
}
