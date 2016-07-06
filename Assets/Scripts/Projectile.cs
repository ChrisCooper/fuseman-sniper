using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float damageAmount = 100f;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile OnCollisionEnter");
        VulnerableActor vulnerableActor = collision.gameObject.GetComponent(typeof(VulnerableActor)) as VulnerableActor;
        if (vulnerableActor != null)
        {
            vulnerableActor.TakeDamage(damageAmount);
        }
        Destroy(gameObject);
    }
}
