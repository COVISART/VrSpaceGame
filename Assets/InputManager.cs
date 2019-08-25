using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Valve.VR.OpenVR.System.ResetSeatedZeroPose();
            Valve.VR.OpenVR.Compositor.SetTrackingSpace(Valve.VR.ETrackingUniverseOrigin.TrackingUniverseSeated);
            Debug.Log("Must be recentered");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            InputTracking.disablePositionalTracking = !InputTracking.disablePositionalTracking;
    }
}
