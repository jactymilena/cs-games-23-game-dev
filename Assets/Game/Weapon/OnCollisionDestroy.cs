using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Dummy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
