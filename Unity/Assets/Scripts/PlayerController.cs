using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioClip rocketBoost;
    public AudioSource audioSource;

    CollisionHandler collisionHandlerScript;
    Rigidbody rb;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandlerScript = GetComponent<CollisionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime, ForceMode.Impulse);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(rocketBoost);
            }
        }
        else
        {
           audioSource.Stop();
        }
    }

    public void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(-rotationThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}