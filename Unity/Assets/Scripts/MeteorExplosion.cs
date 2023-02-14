using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorExplosion : MonoBehaviour
{
    public bool meteorIsDestroyed = false;
    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            meteorIsDestroyed = true;
            Debug.Log("Hit the ground");
            Destroy(this.gameObject);
          
        }
    }

}
