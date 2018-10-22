using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    public GameObject resp;
    public GameObject snake;

    void Start()
    {
        resp = GameObject.FindGameObjectWithTag("Resp");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Instantiate(snake, resp.transform.position, Quaternion.identity);

        }
    }
}
