using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;
using UnityEngine.XR;

public class SimulatorControl : MonoBehaviour
{
    public Transform inputObject, outputObject;
    public bool isEnabledSimulatorSyste = false;
    TrackingSpaceType trackingSpaceType;

    void Start()
    {
        trackingSpaceType = TrackingSpaceType.Stationary;
        XRDevice.SetTrackingSpaceType(trackingSpaceType);
    }

    // Start is called before the first frame update
    public void ToggleSimulatorSystem()
    {
        isEnabledSimulatorSyste = !isEnabledSimulatorSyste;
    }
    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetButtonDown("ToggleSimulatorSystem"))
            ToggleSimulatorSystem();
        else
            ResetPos();
        if (isEnabledSimulatorSyste)
            RotationPass();

        if (InputManager.GetButtonDown("ResetPosition"))
            InputTracking.Recenter();
        if (InputManager.GetButtonDown("disablePositionalTracking"))
            InputTracking.disablePositionalTracking = !InputTracking.disablePositionalTracking;
    }
    void ResetPos()
    {
        outputObject.localRotation = new Quaternion();

    }
    void RotationPass()
    {
        outputObject.localRotation = new Quaternion(inputObject.localRotation.x, inputObject.localRotation.y, inputObject.localRotation.z, 1);
    }
}
