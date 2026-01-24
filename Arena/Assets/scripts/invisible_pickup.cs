using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class invisible_pickup : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            UnityEngine.Debug.Log("invisiblility collected!");
        }
    }
}