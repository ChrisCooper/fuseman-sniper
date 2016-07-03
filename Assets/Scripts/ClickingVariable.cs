using UnityEngine;
using System.Collections;

/**
* A varialbe that should trigger vibration or other effects only when it has changed by a certain amount
*/
public class ClickingVariable : MonoBehaviour {

    float lastClickValue;
    public float interval;

    public static ClickingVariable CreateComponentOn(GameObject whereToAdd, float interval, float initialValue)
    {
        ClickingVariable myC = whereToAdd.AddComponent<ClickingVariable>();
        myC.interval = interval;
        myC.lastClickValue = initialValue;
        return myC;
    }

    public bool UpdateValIsClick(float currentValue)
    {
        if (Mathf.Abs(currentValue - lastClickValue) >= interval)
        {
            lastClickValue = currentValue;
            return true;
        }
        return false;
    }
}
