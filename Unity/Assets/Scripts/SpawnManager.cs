using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject meteor;

    float startTime = 2f;
    float repeatTime = 5f;
    float xPos = 25f;
    float yPos = 40f;

    void Start()
    {
        InvokeRepeating("SpawnMeteor", startTime, repeatTime);
    }        

    
    void Update()
    {

    }

    void SpawnMeteor()
    {
        Instantiate(meteor, SpawnRandomPosition(), Quaternion.identity);
    }



    Vector3 SpawnRandomPosition()
    {
        float xRandomPos = Random.Range(-xPos, xPos);
        return new Vector3(xRandomPos, yPos);
    }
}
