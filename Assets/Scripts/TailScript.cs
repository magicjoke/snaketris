using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TailScript : MonoBehaviour
{

    public float speed = 0.3f;

    Vector2 vector = Vector2.down;
    Vector2 moveVector;
    private GameObject completeSnake;
    //-- GroundCheck --//

    public Transform LeftSideCheck;
    public Transform RightSideCheck;
    public float sideCheckRadius;
    public LayerMask whatIsSide;
    public bool leftSide;
    public bool rightSide;

    public bool canMove;

    //public bool isActive = false;

    public bool freeze;

    void FixedUpdate()
    {

        leftSide = Physics2D.OverlapCircle(LeftSideCheck.position, sideCheckRadius, whatIsSide);
        rightSide = Physics2D.OverlapCircle(RightSideCheck.position, sideCheckRadius, whatIsSide);

    }

    void Start()
    {

            InvokeRepeating("Movement", speed, speed);
            completeSnake = GameObject.FindGameObjectWithTag("SnakeHead");
            //completeSnake.GetComponent<Snake>().testBool = false;

    }

    void Update()
    {

            if(canMove == true)
            {

                if (Input.GetKeyDown(KeyCode.RightArrow) && rightSide == false)
                {

                    transform.position = (new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && leftSide == false)
                {

                    transform.position = (new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
                }
            }

        moveVector = Vector2.down / 1f;

        //if(completeSnake.GetComponent<Snake>().testBool == true)
        //{
        //    Destroy(this);
        //}

        if (Input.GetKeyDown(KeyCode.S))
        {
            completeSnake.gameObject.tag = "Untagged";
            CancelInvoke("Movement");
            canMove = false;
            completeSnake.GetComponent<Snake>().testBool = true;
        }

        if (freeze == true)
        {
            completeSnake.GetComponent<Snake>().testBool = true;
            completeSnake.gameObject.tag = "Untagged";
            CancelInvoke("Movement");
            canMove = false;
        }


    }


    void Movement()
    {

        Vector2 ta = transform.position;
        transform.Translate(moveVector);
    }

}
