using UnityEngine;
using System.Collections;

public class ExplosiveCollision : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ExplosiveCollision OnCollisionEnter");
        //Destroy(gameObject);
    }
}
