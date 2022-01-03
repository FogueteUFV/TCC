using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extracted from:
// https://unity3d.college/2017/07/03/using-vector3-reflect-to-cheat-ball-bouncing-physics-in-unity/

public class BallBouncer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField] public bool atHome = false;

    [SerializeField]
    private float minVelocity = 1f;

    private Vector3 lastFrameVelocity;
    private Rigidbody rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();

        if (initialVelocity != new Vector3(0f, 0f, 0f))
        {
            rb.velocity = initialVelocity;
        } else if (atHome == true)
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        } else 
        {
            rb.velocity = new Vector3(Random.Range(-1.0f, 1.0f), 0f, Random.Range(-1.0f, 1.0f));
        }        
    }

    private void Update()
    {
        if (atHome == false)
        {
            lastFrameVelocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z);
        } else {
            lastFrameVelocity = new Vector3(0f, 0f, 0f);
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);

        direction.y = 0f;

        //Debug.Log("Out Direction: " + direction);
        rb.velocity = direction * Mathf.Max(speed, minVelocity);
    }
}
