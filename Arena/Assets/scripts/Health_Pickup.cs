using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class ItemBehavior : MonoBehaviour
{
    void Health_Pickup(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected!");
        }
    }
}