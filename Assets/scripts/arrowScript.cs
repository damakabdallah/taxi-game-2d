using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour {
    public GameObject taxi;
    public GameObject target;
    Vector3 distance;
    // Use this for initialization
    void Start () {
        distance = transform.position - taxi.transform.position;

    }

    // Update is called once per frame
    void Update () {
        transform.position = taxi.transform.position + distance;

        // Quaternion rotation = Quaternion.LookRotation(target.transform.position,target.transform.up);
        //   transform.rotation = ;
        if (target != null)
        {
            transform.LookAt(target.transform);
            this.transform.Rotate(0, -90, 0);
        }
     
    }
   
}
