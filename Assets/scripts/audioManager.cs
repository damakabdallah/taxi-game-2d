using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour {

    public taxiController txC;
    GameObject idle;
    GameObject maxRPM;
    GameObject acceleration;
    GameObject deacceleration;
    private void Start()
    {
        idle = transform.GetChild(0).gameObject;
        maxRPM = transform.GetChild(1).gameObject;
        acceleration = transform.GetChild(2).gameObject;
         deacceleration = transform.GetChild(3).gameObject;
    }
    // Update is called once per frame
    void Update () {
        if (txC.rb.velocity.magnitude <=1)
        {
            idle.SetActive(true);
            maxRPM.SetActive(false);
            acceleration.SetActive(false);
            deacceleration.SetActive(false);
            StopAllCoroutines();
        }
        if (txC.rb.velocity.magnitude <=15 &&txC.y==0 && txC.rb.velocity.magnitude>1)
        {
            idle.SetActive(false);
            maxRPM.SetActive(false);
            acceleration.SetActive(false);
            deacceleration.SetActive(true);
            StopAllCoroutines();
        }
        if (txC.rb.velocity.magnitude <= 15 && txC.y != 0 && txC.rb.velocity.magnitude > 1)
        {
            idle.SetActive(false);
            maxRPM.SetActive(false);
            acceleration.SetActive(true);
            deacceleration.SetActive(false);
            StartCoroutine(waitForRPM());
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        txC.rb.velocity = Vector2.zero;
    }

    IEnumerator waitForRPM()
    {
        yield return new WaitForSeconds(5);
        idle.SetActive(false);
        maxRPM.SetActive(true);
        acceleration.SetActive(false);
        deacceleration.SetActive(false);
    }
}
