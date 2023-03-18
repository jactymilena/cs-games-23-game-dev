using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    private void Awake()
    {
        Physics.IgnoreLayerCollision(7, 7, true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            if (collision.gameObject.tag.Equals("Dummy"))
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }
        else
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
