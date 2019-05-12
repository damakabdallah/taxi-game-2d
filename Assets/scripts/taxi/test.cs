using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
    public GameObject gameOver;
    public GameObject stillAlive;
    public GameObject[] clients;
    public GameObject[] availableClients;
    public GameObject CurrentClient;
    public GameObject clientPrefab;
    public arrowScript Arrow;
    public Rigidbody2D rb;
    public  Text moneyTXT;
    public Image fuel;
    public Image health;
    private AudioSource AS;
    private int j;
    private float FullMoney=0;
    private float fixedMoney = 300;
    private float money=100;
    public int maxNBclients=500;
    void Start()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
        clients = GameObject.FindGameObjectsWithTag("client");
        rb = GetComponent<Rigidbody2D>();
        for (int i = 0; i < maxNBclients; i++)
        {
            j = Random.Range(0, clients.Length);
            if (clients[j].transform.childCount == 0)
            {
                Instantiate(clientPrefab, clients[j].transform);
                availableClients[i] = clients[j];
            }
        }
        StartCoroutine(instantiateClients());
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        health.fillAmount -= collision.relativeVelocity.magnitude / 5 * Time.deltaTime;

    }

    private void Update()
    {
        fuel.fillAmount -= rb.velocity.magnitude / 1000*Time.deltaTime;
        if (fuel.fillAmount == 0f || health.fillAmount == 0f)
        {
            Destroy(this.GetComponent<taxiController>());
        }
        moneyTXT.text = FullMoney.ToString();
        if (health.fillAmount == 0 || fuel.fillAmount == 0)
        {
            
            gameOver.SetActive(true);
            stillAlive.SetActive(false);
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "child")
        {
            if (CurrentClient == null)
            {
                if (rb.velocity.magnitude >= 0 && rb.velocity.magnitude <= 1)
                {
                    if (clients[j].transform.childCount == 0)
                    {
                       
                        Arrow.gameObject.SetActive(true);
                        Destroy(col.gameObject);
                        Instantiate(clientPrefab, clients[j].transform);
                        CurrentClient = clients[j].transform.GetChild(0).gameObject;
                        CurrentClient.GetComponent<Renderer>().enabled = false;
                        CurrentClient.transform.GetChild(0).gameObject.SetActive(true);
                        Arrow.target = CurrentClient.transform.GetChild(0).gameObject;
                        j = Random.Range(0, clients.Length);
                        money = fixedMoney;
                        StartCoroutine(looseMoney());
                    }
                    else
                        j = Random.Range(0, clients.Length);
                }
            }
        }
        if (col.gameObject.tag == "Finish")
        {
            if (rb.velocity.magnitude >= 0 && rb.velocity.magnitude <= 1)
            {
                StopCoroutine(looseMoney());
                FullMoney += money;
                
                Destroy(CurrentClient.gameObject);
                Arrow.target = null;
                Arrow.gameObject.SetActive(false);
            }
        }
        if (col.gameObject.tag == "gas")
        {
            if(fuel.fillAmount<1)
            {
                fuel.fillAmount += 0.005f;
                if(fuel.fillAmount<0.99f)
                FullMoney -= 0.005f * (1 / 0.005f);
                
            }
        }
        if (col.gameObject.tag == "mechanic")
        {
            if (health.fillAmount < 1)
            {
                health.fillAmount += 0.005f;
                if (health.fillAmount < 0.99f)
                    FullMoney -= 0.005f * (1 / 0.005f);

            }
        }
    }
    IEnumerator instantiateClients()
    {
        yield return new WaitForSeconds(120);
        for (int i = 0; i < maxNBclients; i++)
        {
            if (availableClients[i]!= null)
            {
                Destroy(availableClients[i].transform.GetChild(0).gameObject);
                availableClients[i] = null;

            }
        }
        for (int i = 0; i < maxNBclients; i++)
        {
            j = Random.Range(0, clients.Length);
            if (clients[j].transform.childCount == 0)
            {
                Instantiate(clientPrefab, clients[j].transform);
                availableClients[i] = clients[j];
            }
        }
        StartCoroutine(instantiateClients());
    }
    IEnumerator looseMoney()
    {
        yield return new WaitForSeconds(1);
            money--;
        StartCoroutine(looseMoney());
    }
   
}
