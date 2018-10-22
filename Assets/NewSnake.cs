using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSnake : MonoBehaviour
{

    public float MovementSpeed = 1f;

    private float step = 0.5f;

    Vector2 dir = Vector2.right;

    public float movPause = 1f;
    private Transform startPos;

    public Transform respawn;

    public bool once;
    public bool movingUp;

    public GameObject top;

    public Vector3 target;
    public Vector3 go;

    public float speed = 10f;

    public bool Up;
    //public bool Down;
    public bool Left;
    //public bool Right;


    //float m_distanceTraveled = 0f;

    void Start()
    {
        target = transform.position;
        //   startPos = Vector2(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        ////this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        //if (Input.GetKey(KeyCode.W))
        //{
        //    //StartCoroutine(MovementPause());
        //    //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        //    InvokeRepeating("Move", 1f, 1f);
        //}

        go = Vector3.MoveTowards(go, target, speed * Time.deltaTime);
        gameObject.transform.position = go;

        if (Input.GetKeyDown("up")) {
            //target.y = Mathf.Round(transform.position.y) + 1;
            //InvokeRepeating("Move", 1f, MovementSpeed);
            //transform.Translate(Vector3.up * Time.deltaTime);
            //MoveUp();
            //StartCoroutine(MoveUpwards());
            //target = this.transform.position;
            Up = true;
            InvokeRepeating("Move", 1f, MovementSpeed);
        }
        if (Input.GetKeyDown("down")) {
            //target.y = Mathf.Round(transform.position.y) - 1; 
            //InvokeRepeating("MoveDown", 1f, MovementSpeed);
            //target = this.transform.position;
            Up = false;
            InvokeRepeating("Move", 1f, MovementSpeed);
        }
        if (Input.GetKeyDown("right")) {
            //target.x = Mathf.Round(transform.position.x) + 1;
            //InvokeRepeating("MoveRight", 1f, MovementSpeed);
            Left = false;
            InvokeRepeating("Move", 1f, MovementSpeed);
        }
        if (Input.GetKeyDown("left")) {
            //target.x = Mathf.Round(transform.position.x) - 1;
            //InvokeRepeating("MoveLeft", 1f, MovementSpeed);
            Left = true;
            InvokeRepeating("Move", 1f, MovementSpeed);
        }

        //if (m_distanceTraveled < 100f)
        //{
        //    Vector3 oldPosition = transform.position;
        //    transform.Translate(0, 0, 1 * Time.deltaTime);
        //    m_distanceTraveled += Vector3.Distance(oldPosition, transform.position);
        //}
    }

    void Move()
    {

        if(Up == true && Left == false)
        {
            target.y = Mathf.Round(transform.position.y) + 1;
        }
        if (Up == false)
        {
            target.y = Mathf.Round(transform.position.y) - 1;
        }
        if (Left == true)
        {
            target.x = Mathf.Round(transform.position.x) - 1;
        }
        if (Left == false)
        {
            target.x = Mathf.Round(transform.position.x) + 1;
        }

    }

    void MoveUp()
    {
        //Vector2 v = new Vector2(this.transform.position.x, this.transform.position.y);
        //Vector2 v = transform.position;
        //transform.Translate(dir);
        //transform.Translate(Vector2.right * Time.deltaTime);
        //target.y = Mathf.Round(transform.position.y) + 1;
        this.transform.Translate(Vector3.up * Time.deltaTime);
    }
    void MoveDown()
    {
        target.y = Mathf.Round(transform.position.y) - 1;
    }
    void MoveRight()
    {
        target.x = Mathf.Round(transform.position.x) + 1;
    }
    void MoveLeft()
    {
        target.x = Mathf.Round(transform.position.x) - 1;
    }


    IEnumerator MovementPause()
    {
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        yield return new WaitForSeconds(movPause);
        //once = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            this.transform.position = respawn.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            this.transform.position = respawn.transform.position;
        }
    }


    IEnumerator MoveUpwards()
    {

        yield return new WaitForSeconds(1f);
        target.y = Mathf.Round(transform.position.y) + 1;

    }
}
