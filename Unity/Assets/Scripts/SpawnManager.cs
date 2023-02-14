using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject meteor;
    [SerializeField] ParticleSystem meteorExplosion;
    MeteorExplosion meteorExplosionScript;

    float startTime = 2f;
    float repeatTime = 5f;
    float xPos = 25f;
    float yPos = 40f;

    void Start()
    {
        meteorExplosionScript = GameObject.Find("Meteor").GetComponent<MeteorExplosion>();
        InvokeRepeating("SpawnMeteor", startTime, repeatTime);
    }        

    
    void Update()
    {
        meteorExplosion.transform.position = meteor.transform.position;

        if(meteorExplosionScript.meteorIsDestroyed)
        {
            meteorExplosion.Play();
        }
    }

    void SpawnMeteor()
    {
        Instantiate(meteor, SpawnRandomPosition(), Quaternion.identity);
        Instantiate(meteorExplosion);
    }

    Vector3 SpawnRandomPosition()
    {
        float xRandomPos = Random.Range(-xPos, xPos);
        return new Vector3(xRandomPos, yPos);
    }
}
