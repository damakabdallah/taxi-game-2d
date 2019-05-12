using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {
    public GameObject taxi;
    Vector3 distance;
	// Use this for initialization
	void Start () {
        distance = transform.position - taxi.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = taxi.transform.position + distance;
	}
}
