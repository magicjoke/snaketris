using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementz : MonoBehaviour
{

    public Vector3 target;
    public Vector3 go;

    public float speed = 10f;

    public bool inputLeft;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        go = Vector3.MoveTowards(go, target, speed * Time.deltaTime);
        gameObject.transform.position = go;

        if (Input.GetKeyDown("up")) {

            target.y = Mathf.Round(transform.position.y) + 1;

        }
        if (Input.GetKeyDown("down")) { target.y = Mathf.Round(transform.position.y) - 1; }
        if (Input.GetKeyDown("right")) { target.x = Mathf.Round(transform.position.x) + 1; }
        if (Input.GetKeyDown("left")) {

            inputLeft = true;
            target.x = Mathf.Round(transform.position.x) - 1;

        }
    }
}
