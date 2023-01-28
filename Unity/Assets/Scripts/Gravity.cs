using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] float gravityForce = 1.0f;


    void Start()
    {
        float initialGravity = Physics.gravity.y;
        Physics.gravity = new Vector3(0, initialGravity * gravityForce, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
