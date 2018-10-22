using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementzFollow : MonoBehaviour
{

    private GameObject snakeHead;
    private Vector3 followThing;
    public float speed = 1f;

    public Vector3 go;

    //public bool active = false;

    void Start()
    {
        //followThing = GameObject.FindGameObjectWithTag("SnakeHead").transform.position;
        snakeHead = GameObject.FindGameObjectWithTag("SnakeHead");
    }

    // Update is called once per frame
    void Update()
    {
        //followThing = GameObject.FindGameObjectWithTag("SnakeHead").transform.position;
        //this.transform.position = followThing;

        followThing = GameObject.FindGameObjectWithTag("SnakeHead").transform.position;
        followThing = new Vector3(followThing.x-1, followThing.y, followThing.z);
        go = Vector3.MoveTowards(go, followThing, speed * Time.deltaTime);
        gameObject.transform.position = go;

        //if (active == true)
        //{
        //    followThing = GameObject.FindGameObjectWithTag("SnakeHead").transform.position;
        //    go = Vector3.MoveTowards(go, followThing, speed * Time.deltaTime);
        //    gameObject.transform.position = go;
        //    //active = false;
        //}

        if(snakeHead.GetComponent<Movementz>().inputLeft == true)
        {
            //target.x = Mathf.Round(transform.position.x) - 1;
            followThing.x = Mathf.Round(transform.position.x) - 1;
        }
    }
}
