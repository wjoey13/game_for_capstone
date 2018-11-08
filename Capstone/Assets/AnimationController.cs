using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController animationController;
    private Animator anim;
    string currentState;

    void Start()
    {
        currentState = "Idle";
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        if (currentState.Equals("Idle"))
        {
            anim.SetInteger("state", 0);
        }
        else if (currentState.Equals("Run"))
        {
            anim.SetInteger("state", 1);
        }
        else if (currentState.Equals("Fall"))
        {
            anim.SetInteger("state", 2);
        }
        else if (currentState.Equals("Death"))
        {
            anim.SetBool("isDead", true);
        }
    }


    public void stateUpdate(string state)
    {
        anim.SetInteger("state", 0);
        currentState = state;
    }

    public void AnimStop()
    {
        anim.SetInteger("state", 0);
    }

    public void StartFalling()
    {
        anim.SetBool("isFalling", true);
    }

    public void StopFalling()
    {
        anim.SetBool("isFalling", false);
    }

}