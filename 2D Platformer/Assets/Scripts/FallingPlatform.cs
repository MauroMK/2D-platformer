using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    
    public float fallingTime;

    private TargetJoint2D targetJ;
    private BoxCollider2D boxColl;

    void Start()
    {
        targetJ = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // invoke é um metodo que chama outro metodo depois de um certo período de tempo
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        targetJ.enabled = false;
        boxColl.isTrigger = true;
    }
}
