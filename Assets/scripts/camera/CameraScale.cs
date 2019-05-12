using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScale : MonoBehaviour {

    public taxiController Taxi;
    public Rigidbody2D rb;
    public Camera miniMapCam;
    float defaultCamSize;

	// Use this for initialization
	void Start () {
        defaultCamSize = miniMapCam.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        if (Taxi.y!=0 && miniMapCam.orthographicSize<45)
            miniMapCam.orthographicSize += 0.1f;
        else
            if(Taxi.y==0 && miniMapCam.orthographicSize > defaultCamSize)
            miniMapCam.orthographicSize -= 0.1f;

    }
}
