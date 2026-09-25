using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Boss : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 10.0f;

    //Attacks for the boss to create
    public GameObject fireBreath;
    public GameObject[] hands;


    //Sets the spawn position of hands
    public const float handX = 7.3f;
    public const float handY = 7.46f;
    public const float handZ = 0;
    
    public Vector3 leftHandSpawn = new Vector3(-handX, handY, handZ);
    public Vector3 rightHandSpawn = new Vector3(handX, handY, handZ);

    public InputAction SpawnAction;
    public float delay = 5;


    void Start()
    {
        SpawnAction.Enable();    
    }

    // Update is called once per frame
    void Update()
    {
        if (delay<=0)
        {
            int handType = Random.Range(0, 3);
            if (handType == 0)
            {
                Instantiate(hands[0], leftHandSpawn, hands[0].transform.rotation);
                Instantiate(hands[1], rightHandSpawn, hands[1].transform.rotation);
                Debug.Log("Fireballs");
            }
            else if (handType == 1)
            {
                Instantiate(hands[2], leftHandSpawn, hands[2].transform.rotation);
                Instantiate(hands[3], rightHandSpawn, hands[3].transform.rotation);
                Debug.Log("Slam");
            }
            else if (handType == 2)
            {
                Instantiate(hands[4], leftHandSpawn, hands[4].transform.rotation);
                Instantiate(hands[5], rightHandSpawn, hands[5].transform.rotation);
                Debug.Log("Tear");
            }
            delay = 5;
        }
        delay -= 1 * Time.deltaTime;
    }
}
