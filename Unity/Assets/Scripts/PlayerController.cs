using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public AudioClip rocketBoost;
    public AudioSource audioSource;
    [SerializeField] ParticleSystem jetParticles;
    [SerializeField] ParticleSystem thursterParticlesLeft;
    [SerializeField] ParticleSystem thursterParticlesRight;

    CollisionHandler collisionHandlerScript;
    Rigidbody rb;

    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandlerScript = GetComponent<CollisionHandler>();
    }


    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    public void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime, ForceMode.Impulse);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(rocketBoost);
            jetParticles.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        jetParticles.Stop();
    } 

    private void RotateRight()
    {
        ApplyRotation(-rotationThrust);
        thursterParticlesLeft.Play();
    }

    private void RotateLeft()
    {
        ApplyRotation(rotationThrust);
        thursterParticlesRight.Play();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}