using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int damagePerSwing = 25;
    public float timeBetweenSwings = 0.15f;
    public float range = 100f;


    private float timer;
    Ray swingRay;
    RaycastHit swingHit;
    LineRenderer hammerLine;
    int hitableMask;
    float effectsDisplayTime = 0.2f;

    // Use this for initialization
    void Awake()
    {
        hitableMask = LayerMask.GetMask("Hitable");


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") /*&& timer >= timeBetweenSwings*/)
        {
            Swing();
        }

        //if (timer >= timeBetweenSwings * effectsDisplayTime)
        //{
        //    DisableEffects();
        //}
    }

    //public void DisableEffects ()
    //{

    //}

    void Swing ()
    {
        timer = 0f;

        if(Physics.Raycast (swingRay, out swingHit, range, hitableMask))
        {
            EnemyHealth enemyHealth = swingHit.collider.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerSwing /*, swingHit.point*/);
            }
            hammerLine.SetPosition(1, swingHit.point);
            
        }
        else
        {
            hammerLine.SetPosition(1, swingRay.origin + swingRay.direction * range);
        }
    }
}
