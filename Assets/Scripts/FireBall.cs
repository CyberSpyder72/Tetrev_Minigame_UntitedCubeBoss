using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int direction = 0;
    public float speed = 20.0f;
    private float xRange = 28;
    void Start()
    {
        //sets direction based on side
        if(transform.position.x > 0)
        {
            direction = -1;
        }
        else if (transform.position.x < 0)
        {
            direction = 1;
        }
     
    }

    // Update is called once per frame
    void Update()
    {
        //Moves to the other side of the screen
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        //Destroys object if out of scene
        if(transform.position.x > xRange || transform.position.x <-xRange)
        {
            Destroy(gameObject);
        }
    }
}
