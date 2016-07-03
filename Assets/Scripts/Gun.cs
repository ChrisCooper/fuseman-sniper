using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public SteamVR_TrackedObject rightController;

    SteamVR_Controller.Device device;

    /**
    * Shooting
    */
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 200;

    // Update is called once per frame
    void Update () {
        device = SteamVR_Controller.Input((int)rightController.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            fire();
        }
	}

    private void fire()
    {
        device.TriggerHapticPulse(1000);
        var bulletRotation = bulletSpawnPoint.rotation * Quaternion.Euler(new Vector3(90, 0, 0));
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletRotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = -(bulletSpeed) * bulletSpawnPoint.transform.forward;
    }
}
