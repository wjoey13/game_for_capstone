﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    AnimationController animationController;
    PlayerController playerController;
    bool isDead;
    bool damaged;
	// Use this for initialization
	void Awake() {

        animationController = FindObjectOfType<AnimationController>();
        playerController = GetComponent<PlayerController>();


        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        animationController.stateUpdate("Death");
        playerController.enabled = false;
    }
}
