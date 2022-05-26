using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Basic structure 
    // PARAMETERS - tuning in editor
    // CACHE - e.g. references
    // STATE - private instance variables

    [SerializeField] Rigidbody rb;
    [SerializeField] float trottleSpeed = 1000;
    [SerializeField] float rotateSpeed = 100;

    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftEngineParticles;
    [SerializeField] ParticleSystem rightEngineParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTrottle();
        ProcessRotation();
    }

    // Boost | Throttle
    void ProcessTrottle()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * trottleSpeed * Time.deltaTime);

            if (!mainEngineParticles.isPlaying)
            {
                mainEngineParticles.Play();
            }
        }
        else
        {
            mainEngineParticles.Stop();
        }
    }

    // Rotation
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);

            if (!rightEngineParticles.isPlaying)
            {
                rightEngineParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);

            if (!leftEngineParticles.isPlaying)
            {
                leftEngineParticles.Play();
            }
        }
        else
        {
            if (rightEngineParticles.isPlaying)
            {
                rightEngineParticles.Stop();
            }

            if (leftEngineParticles.isPlaying)
            {
                leftEngineParticles.Stop();
            }
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freeze rotation, so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation, so system physics take over
    }
}
