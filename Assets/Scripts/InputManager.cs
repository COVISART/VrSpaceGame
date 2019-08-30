using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;



public class InputManager : MonoBehaviour
{
    TrackingSpaceType trackingSpaceType;

    void Start()
    {
        trackingSpaceType = TrackingSpaceType.Stationary;
        XRDevice.SetTrackingSpaceType(trackingSpaceType);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            /*OpenVR.System.ResetSeatedZeroPose();
            OpenVR.Compositor.SetTrackingSpace(ETrackingUniverseOrigin.TrackingUniverseSeated);*/
            InputTracking.Recenter();
            Debug.Log("Must be recentered");
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            InputTracking.disablePositionalTracking = !InputTracking.disablePositionalTracking;
    }
}
