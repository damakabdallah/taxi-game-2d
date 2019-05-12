using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taxiController : MonoBehaviour {
    public float x, y;
    public  float speed = 5f;
    public  float torque = 100f;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = forwardVelocity();
        y = Input.GetAxis("Vertical");
        x = Input.GetAxis("Horizontal");
        rb.AddForce(transform.up * y * speed);
        float tf = Mathf.Lerp(0, torque, rb.velocity.magnitude / 700);
        if(y>0)
            rb.angularVelocity=-x * torque*tf;
        else
            if(y<0)
            rb.angularVelocity=x * torque*tf;

    }
    Vector2 forwardVelocity()
    {
        return transform.up * Vector2.Dot(rb.velocity, transform.up);
    }
}
