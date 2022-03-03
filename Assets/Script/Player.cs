using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody playerRb;
    public float speed = 0.5f;
    public int brickCount;
    public bool checking;
    public Material color;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        if (checking == true)
        {
            playerRb.AddForce(Vector3.forward * forwardInput * speed, ForceMode.Impulse);
        }
        float rightInput = Input.GetAxis("Horizontal");

       playerRb.AddForce(Vector3.right * rightInput * speed, ForceMode.Impulse);

        if (transform.position.x < -3)
        {
        transform.position = new Vector3(-3, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 3)
        {
            transform.position = new Vector3(3, transform.position.y, transform.position.z);
        }
        if (brickCount > 0)
        {
            checking = true;
        }
        if(transform.position.y < -1)
        {
            Destroy(gameObject);
        }
 }
    private void OnTriggerEnter(Collider collision )
    {
        if (collision.gameObject.CompareTag("Blue Brick"))
        { 
            brickCount++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bridge")
        {
            Debug.Log("collision");
            if (brickCount > 0)
            {
                checking = true;
                brickCount--;
                collision.GetComponent<Renderer>().material = color;
            }
           
    
        }
    }
    
    
    
}
