using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForward = 500f;
    public float initialVelocity = 1f;
    public float boostValue = 10f;
    public float maxVelocity;
    public float obstacleSpeedReduce = -5f;
    public HealthBar VelocityBar;
    public float gravityForce = 10000f;
    public float dragOnGround = 0.05f;
    private bool grounded;
    public LayerMask whatisGround;
    public float groundRayLength;
    public Transform groundRayPoint;

    private Vector3 defaultPos;
    Vector3 targetAngleMax = new Vector3(0, 90, 5);
    Vector3 targetAngleMin = new Vector3(0, 90, 0);


    private void Awake()
    {
        defaultPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boost"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime * initialVelocity);
            if (GameManager.gameState == GameState.Playing)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                other.gameObject.SetActive(true);
            }

            if (rb.velocity.z > maxVelocity)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxVelocity);
            }
        }
     
        if (other.CompareTag("EndGame"))
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().EndGame();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            rb.AddForce(0, 0, obstacleSpeedReduce * Time.deltaTime * initialVelocity);
            collision.rigidbody.AddForce(0, 0, -obstacleSpeedReduce * Time.deltaTime * initialVelocity);
            float firstPos = transform.position.z;
            Debug.Log("Hit");

            //Debug.Log(firstPos);
          


        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime * initialVelocity);

        }
    }
    void FixedUpdate()
    {
        if (GameManager.gameState == GameState.Playing)
        {
            grounded = false;
            RaycastHit hit;

            if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatisGround))
            {
                grounded = true;
                rb.drag = dragOnGround;

                Quaternion toRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
                transform.rotation = Quaternion.Lerp(transform.rotation,toRotation ,1f * Time.deltaTime);
               // Debug.Log("transform="+transform.rotation);

               // Debug.Log(transform.eulerAngles);

            }
            if (!grounded || transform.position.y > 8.9f) 
            {
                rb.AddForce(Vector3.up * -gravityForce);
                rb.drag = 0.15f;
            }
            VelocityBar.SetVelocity((int)rb.velocity.z);
            
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForward * (grounded ? 1 : 0.3f) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }
            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForward * (grounded ? 1 : 0.3f) * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            }

            //float newVal = transform.eulerAngles.z;
            //newVal = (newVal > 180) ? newVal - 360 : newVal;

            //if (newVal >= targetAngleMax.z)
            //{

            //    transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngleMax, 1f);
            //}
           
            if (rb.velocity.z <= 0)
            {
                // Debug.Log("Endgame");
                //Debug.Log(rb.velocity.z);

                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().EndGame();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = -transform.up * groundRayLength;
        Gizmos.DrawRay(groundRayPoint.position, direction);
    }

    public void ResetPlayer()
    {
        transform.position = defaultPos;
        transform.eulerAngles = new Vector3(0, 90, 0);
        rb.velocity = new Vector3(0, 0, maxVelocity);
        VelocityBar.SetMaxVelocity(maxVelocity);
        GameManager.gameState = GameState.Playing;

    }
}

