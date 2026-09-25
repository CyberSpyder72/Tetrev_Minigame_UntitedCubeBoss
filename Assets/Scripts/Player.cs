using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Movement
    public InputAction moveAction;
    public Vector2 moveInput;
    public float speed = 10.0f;

    //Limits where player can move
    public float xRange = 13;
    public float yRange = 4;

    //Player health and iframes
    public int health = 5;
    public float iFrameDuration = 3;
    public float iFrames = 3;
    public bool isInvincible = false;

    //Player Materials
    public Material normal;
    public Material iframes;
    public GameObject player;

    //Collectables and score
    public GameObject collectable;
    public int score = 0;

    void Start()
    {
        moveAction.Enable();
        float collectableX = Random.Range(-xRange + 1, xRange);
        float collectableY = Random.Range(-yRange + 1, yRange-2);
        Vector3 coinPosition = new Vector3(collectableX, collectableY, 0);
        Instantiate(collectable, coinPosition, collectable.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        moveInput = moveAction.ReadValue<Vector2>();

        transform.Translate(Vector3.right * moveInput.x * Time.deltaTime * speed);
        transform.Translate(Vector3.up * moveInput.y * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }


        //ticks down iFrames
        if (iFrames > 0)
        {
            iFrames -= 1 * Time.deltaTime;

        }
        else if (isInvincible == true)
        {
            player.GetComponent<MeshRenderer>().material = normal;
            isInvincible = false;
        }

    }

    //Taking damage
    private void OnTriggerStay(Collider other)
    {
        //For hands and the boss itself
        if (iFrames <= 0)
        {
            if (other.tag == "Boss")
            {
                health -= 1;
                iFrames = iFrameDuration;
                Debug.Log("Health: " + health);
                player.GetComponent<MeshRenderer>().material = iframes;
                isInvincible = true;
            }
            //For projectiles
            else if (other.tag == "Projectile")
            {
                health -= 1;
                iFrames = iFrameDuration;
                Destroy(other.gameObject);
                Debug.Log("Health: " + health);
                player.GetComponent<MeshRenderer>().material = iframes;
                isInvincible = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            float collectableX = Random.Range(-xRange + 1, xRange);
            float collectableY = Random.Range(-yRange + 1, yRange - 2);
            Vector3 coinPosition = new Vector3(collectableX, collectableY, 0);
            Instantiate(collectable, coinPosition, collectable.transform.rotation);
            score += 1;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }
    }
}
