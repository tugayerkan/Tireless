using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float impactForce = 10000;
    public Rigidbody rb;
    public float speed = 1f;
    public Vector3 direction = Vector3.forward;
    private bool isCrashed = false;
    private bool inRange;

    public void Crash(Vector3 impactPoint, Vector3 direction)
    {
        isCrashed = true;
        rb.AddForceAtPosition(direction * impactForce, impactPoint);
    }

    private void Update()
    {
        if (!isCrashed)
        {
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            Crash(collision.GetContact(0).point, direction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.transform.position.z < transform.position.z && !isCrashed)
        {
            inRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }


}

