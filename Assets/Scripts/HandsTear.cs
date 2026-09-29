using UnityEngine;

public class HandsTear : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 5.0f;
    public int direction;

    //Sets up fireball spawning
    public GameObject debris;


    //Sets the phase of the hand motion and timers
    public float handEdge = 24.0f;
    public int phase = 0;
    public float startDelay = 1;
    private float fireDelay = .5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //phase 1, moves to edge of screen
        if (phase == 0)
        {
            transform.Translate(Vector3.right * speed * 1.5f * direction * Time.deltaTime);

            //Checks for the bound of where the hand first goes to
            if (transform.position.x > handEdge || transform.position.x < -handEdge)
            {
                phase = 1;
            }
            
        }
        //phase 2, waits a delay
        else if (phase == 1)
        {
            if (startDelay <= 0)
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
                int offset = Random.Range(45, 86);
                Instantiate(debris, transform.position, Quaternion.Euler(0, 0, offset * direction));
                fireDelay = .4f;
            }
            fireDelay -= 1 * Time.deltaTime;
        }
        //Checks if object is off screen, and then removes it
        if (transform.position.y < -18)
        {
            Destroy(gameObject);
        }
    }
}
