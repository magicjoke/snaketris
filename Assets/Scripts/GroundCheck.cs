using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //private GameObject completeSnake;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    //private GameObject test;
    private GameObject tail;

    private bool castOnce = true;

    //--deleteif--//
    public Transform LeftSideCheck;
    public Transform RightSideCheck;
    public float sideCheckRadius;
    public LayerMask whatIsSide;
    public bool leftSide;
    public bool rightSide;
    //--deletif--//


    void FixedUpdate()
    {
        leftSide = Physics2D.OverlapCircle(LeftSideCheck.position, sideCheckRadius, whatIsSide);
        rightSide = Physics2D.OverlapCircle(RightSideCheck.position, sideCheckRadius, whatIsSide);


        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        
    }

    void Start()
    {
        //test = GameObject.FindGameObjectWithTag("SnakeHead");
        tail = GameObject.FindGameObjectWithTag("CompleteSnake");

        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            tail.GetComponent<TailScript>().freeze = true;
            //test.GetComponent<Snake>().testBool = true;
            //Destroy(this);
        }

        if (rightSide == true)
        {
            tail.GetComponent<TailScript>().rightSide = true;
        }

        if (leftSide == true)
        {
            tail.GetComponent<TailScript>().leftSide = true;

        }
    }

}
