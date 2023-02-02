using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float gravityForce = 1.0f;


    void Start()
    {
        float initialGravity = -9.81f;
        Physics.gravity = new Vector3(0, initialGravity * gravityForce, 0);

        Debug.Log("Gravity force: " + Physics.gravity.y);

    }

}
