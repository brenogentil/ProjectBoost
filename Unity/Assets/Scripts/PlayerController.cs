using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    [SerializeField] float impulse = 100;
    [SerializeField] float turnVelocity = 50;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputMovement();
        InputRotation();
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            playerRb.AddRelativeForce(Vector3.up * impulse * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void InputRotation()
    {
        float turnRocket = Input.GetAxis("Horizontal");
        int clockwise = -1;
        playerRb.freezeRotation = true;
        transform.Rotate(Vector3.forward * turnRocket * turnVelocity * Time.deltaTime * clockwise);
        //playerRb.freezeRotation = false;
    }
}
