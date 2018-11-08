using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] float gravity;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallControl;

    public enum State
    {
        Idle,
        Run,
        Jump,
        Fall,
        Death
    }
    [SerializeField] public State state;

    public Rigidbody playerRigidbody;
    public int floorMask;
    public float camRayLength = 100f;

    Vector3 moveDirection;
    CharacterController characterController;
    AnimationController animationController;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        animationController = FindObjectOfType<AnimationController>();
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementHandling();
        AnimationHandling();
    }

    private void MovementHandling()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (characterController.isGrounded)
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                state = State.Idle;
                moveDirection = new Vector3(0, 0.0f, 0);
            }
            else
            {
                moveDirection = moveInput;
                moveDirection *= moveSpeed;
                state = State.Run;
            }
            if (Input.GetButton("Jump"))
            {
                state = State.Fall;
                moveDirection.y = jumpSpeed;
            }
        }
        else
        {
            moveDirection = new Vector3(moveInput.x * fallControl, moveDirection.y, moveInput.z * fallControl);
        }
        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        if (!characterController.isGrounded)
        {
            state = State.Fall;
        }
    }

    private void AnimationHandling()
    {
        if (state == State.Idle)
        {
            animationController.stateUpdate("Idle");
        }
        else if (state == State.Run)
        {
            animationController.stateUpdate("Run");
        }
        else if (state == State.Jump)
        {
            animationController.stateUpdate("Jump");
        }
        else if (state == State.Fall)
        {
            animationController.stateUpdate("Fall");
        }
        else if (characterController.isGrounded)
        {
            animationController.StopFalling();
            animationController.AnimStop();
        }
        else if (state == State.Death)
        {
            animationController.stateUpdate("Death");
        }
    }
}
