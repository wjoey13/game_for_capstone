using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


	// Use this for initialization
	void Awake () {
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
	}

    public void TakeDamage (int amount)
    {
        if (isDead)

            return;

        currentHealth -= amount;

        if(currentHealth <=0)
        {
            Death();
        }
    }

    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;
    }

    public void StartSinking () 
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        //ScoreManager.score += scoreValue;

        Destroy(gameObject, 2f);
    }
}
