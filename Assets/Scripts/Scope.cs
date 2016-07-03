using UnityEngine;
using System.Collections;

public class Scope : MonoBehaviour {

    public SteamVR_TrackedObject rightController;
    SteamVR_Controller.Device device;

    public Camera scopeCamera;
    [Range(0.1f, 30f)]
    public float widestFieldOfView = 10;

    [Range(0.1f, 30f)]
    public float narrowestFieldOfView = 3;

    [Range(1,3999)]
    public ushort zoomVibrationAmount = 250;

    [Range(0.01f, 0.5f)]
    public float zoomVibrationInterval = 0.05f;

    ClickingVariable zoomClicker;

    void Start()
    {
        zoomClicker = ClickingVariable.CreateComponentOn(gameObject, zoomVibrationInterval, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        device = SteamVR_Controller.Input((int)rightController.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            var trackpadTouchPosition = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            // Position is a -1 to 1 value, so normalize to 0 to 1
            var zoomAmount = (trackpadTouchPosition.y + 1) / 2;

            // Update field of view
            scopeCamera.fieldOfView = Mathf.Lerp(widestFieldOfView, narrowestFieldOfView, zoomAmount);

            // Clicking vibration
            if (zoomClicker.UpdateValIsClick(zoomAmount))
            {
                device.TriggerHapticPulse(zoomVibrationAmount);
            }
            // Update the clicker so modificaitons are incorporated
            zoomClicker.interval = zoomVibrationInterval;
        }
    }
}
