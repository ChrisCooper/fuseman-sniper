using UnityEngine;
using System.Collections;

public class VulnerableActor : MonoBehaviour {

    public float startingHealth = 100f;
    float currentHealth;

    public void Start()
    {
        currentHealth = startingHealth;
    }

    // Use this for initialization
    public void TakeDamage (float amount) {
        currentHealth -= amount;
        Debug.Log("TakeDamage. Health is now " + currentHealth);
    }
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0f)
        {
            Debug.Log("VulnerableActor is dead");
            Destroy(gameObject);
        }
	}
}
