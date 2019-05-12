using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyScript : MonoBehaviour {
    private int money=100;
    private test player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<test>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            if (player.CurrentClient == null)
            {
                StartCoroutine("loseMoney");
            }

        }
          
    }
    IEnumerator loseMoney()
    {
        yield return new WaitForSeconds(1);
            money--;
            print(money);
       // StartCoroutine(loseMoney());
    }
}
