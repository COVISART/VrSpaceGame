using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour {

    public GameObject player;        //Public variable to store a reference to the player game object


    public float offset=0.5f;            //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    // LateUpdate is called after Update each frame
    void LateUpdate () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Vector3.Lerp(transform.position, player.transform.position, offset);
        //Vector3.Lerp(_cacheTransform.position, target.position - target.forward * distance + target.up * chaseHeight, Time.deltaTime * followDamping * chaseDistance);
    }
}