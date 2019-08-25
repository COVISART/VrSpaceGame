using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class VrCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        InputTracking.Recenter();
        InputTracking.disablePositionalTracking = true;
    }
}
