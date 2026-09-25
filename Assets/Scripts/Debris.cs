using UnityEngine;

public class Debris : MonoBehaviour
{
    public float force = 50.0f;
    private Rigidbody debrisBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        debrisBody = GetComponent<Rigidbody>();
        debrisBody.AddForce(transform.up * force);
    }

    // Update is called once per frame
    void Update()
    {
        //checks to see if off screen, then deletes self
        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }
}
