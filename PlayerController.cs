using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
 
    public float speed = 20;
    float turnSpeed = 45.0f;
    float horizontalInput;
    float forwardInput;
    float xRange = 50;
    public GameObject projectilePrefab;
    public Transform projectileTransorm;
    public bool gameFlag;
    [SerializeField] GameObject gameText;
    float bulletspeed = 20f;
     public Rigidbody projectile2;
 
    // Start is called before the first frame update
    void Start()
    {
       
    }
 
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided" + other.name);
    }
 
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collided" + other.gameObject.name);
        gameFlag = true;
    }
 
    // Update is called once per frame
    void Update()
    {
 
        if (gameFlag)
        {
            gameText.SetActive(true);
 
        }
 
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
 
        // Move the vehicle forward
        //transform.Translate(0, 0, 1);
        // transform.Translate(Vector3.forward);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);//20
        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
 
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
 
 
        if (transform.position.z <  - xRange)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y, -xRange);
        }
        if (transform.position.z > xRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, xRange);
        }
 
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            // Destroy( Instantiate(projectilePrefab,(projectileTransorm.position),projectileTransorm.rotation),5f);
            // Debug.Log((projectileTransorm.position));
 
            var bullet = Instantiate(projectile2, (projectileTransorm.position), (projectileTransorm.rotation)); //Destroy(, 5f);
            bullet.velocity = (projectileTransorm.rotation * Vector3.forward) * bulletspeed;
            Destroy(bullet.gameObject, 2f);
 
        }
 
 
 
 
 
    }
}
 

