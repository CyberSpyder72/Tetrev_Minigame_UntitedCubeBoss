using System;
using UnityEngine;

public class HandsSlam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 50.0f;
    private Boolean slam = false;
    private float delay = 1.0f;
    public GameObject debris;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Waits for a delay, then slams fist
        if (slam == true)
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * speed / 10 * Time.deltaTime);
        }

        //counts down delay
        delay -= 1*Time.deltaTime;
        if (delay <= 0)
        {
            slam = true;
        }

        //spawns fragments, then destroy's itself
        if(transform.position.y < -8)
        {
            Instantiate(debris, transform.position, debris.transform.rotation);
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, 15));
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, -15));
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, 30));
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, -30));
            Instantiate(debris, transform.position, Quaternion.Euler(0,0,45));
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, -45));
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, 60));
            Instantiate(debris, transform.position, Quaternion.Euler(0, 0, -60));
            Destroy(gameObject);
        }
            
    }
}
