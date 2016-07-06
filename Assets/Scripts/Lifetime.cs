using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {

    public float secondsToLive = 3;
	void Awake() {
        Destroy(gameObject, 1);
    }
}
