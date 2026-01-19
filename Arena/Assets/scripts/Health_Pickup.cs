using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class ItemBehavior : MonoBehaviour
{    
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            UnityEngine.Debug.Log("Item collected!");
        }
    }
} 