using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HandsFire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 5.0f;
    public int direction;

    //Sets up fireball spawning
    public GameObject fireBall;


    //Sets the phase of the hand motion and timers
    public float handEdge = 20.0f;
    public int phase = 0;
    public float startDelay = 1;
    public float fireDelay = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        //Phase 1, moves to the edge of screen
        if(phase == 0)
        {
            transform.Translate(Vector3.right * speed * 1.5f * direction * Time.deltaTime);
            
            //Checks for the bound of where the hand first goes to
            if (transform.position.x > handEdge || transform.position.x < -handEdge)
            {
                phase = 1;
            }
        }
        //phase 2, waits a delay
        else if(phase == 1)
        {
            if(startDelay <= 0)
            {
                phase = 2;
            }
            startDelay -= 1 * Time.deltaTime;
        }
        //phase 3, travels downward, occasionally firing out projectiles
        else if (phase == 2)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
            if (fireDelay <= 0)
            {
                Instantiate(fireBall, transform.position, fireBall.transform.rotation);
                fireDelay = 1f;
            }
            fireDelay -= 1 * Time.deltaTime;
        }

        

        //Checks if object is off screen, and then removes it
        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }
}
