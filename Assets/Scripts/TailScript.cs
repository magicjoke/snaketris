using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TailScript : MonoBehaviour
{

    public float speed = 0.3f;

    Vector2 vector = Vector2.down;
    Vector2 moveVector;

    //-- GroundCheck --//

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public bool canMove = true;

    //public bool isActive = false;

    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Start()
    {

            InvokeRepeating("Movement", speed, speed);

    }

    void Update()
    {

            if (grounded == true)
            {
                CancelInvoke();
                canMove = false;
            }

            if (canMove == false)
            {
                this.GetComponent<BoxCollider2D>().enabled = true;
            }


            if (canMove == true)
            {

                this.GetComponent<BoxCollider2D>().enabled = false;

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {

                    transform.position = (new Vector3(transform.position.x + 1, transform.position.y, transform.position.z));
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {

                    transform.position = (new Vector3(transform.position.x - 1, transform.position.y, transform.position.z));
                }
            }
            moveVector = Vector2.down / 1f;

    }


    void Movement()
    {

        Vector2 ta = transform.position;
        transform.Translate(moveVector);
    }

}
