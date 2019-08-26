using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;


public class InputManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            OpenVR.System.ResetSeatedZeroPose();
            OpenVR.Compositor.SetTrackingSpace(ETrackingUniverseOrigin.TrackingUniverseSeated);
            Debug.Log("Must be recentered");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            InputTracking.disablePositionalTracking = !InputTracking.disablePositionalTracking;
    }
}
