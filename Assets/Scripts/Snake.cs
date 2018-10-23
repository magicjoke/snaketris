using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public GameObject completeSnake;

	public GameObject tailPrefab;
	public GameObject food;
	//public Transform rBorder;
	//public Transform lBorder;
	//public Transform tBorder;
	//public Transform bBorder;

	public float speed = 0.3f;

	Vector2 vector = Vector2.up;
	Vector2 moveVector;

	public List<Transform> tail = new List<Transform>();

	bool eat = false;
	bool vertical = false;
	bool horizontal = true;

    //-- Mutating to Block --//

    public bool mutate;

    public GameObject newHead;

    private GameObject respawn;

    public GameObject[] Tails;

    private GameObject completeSnak;


    public bool testBool = false;

    private GameObject snakeBody;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    void Start () {

        testBool = false;

        respawn = GameObject.FindGameObjectWithTag("Resp");

        completeSnak = GameObject.FindGameObjectWithTag("CompleteSnake");

        // -- //
        snakeBody = GameObject.FindGameObjectWithTag("CompleteSnake");
        grounded = false;
        // -- //


        //SpawnFood ();
        InvokeRepeating("Movement", speed, speed);
        StartGrow();

        Tails = GameObject.FindGameObjectsWithTag("Tail");
    }
	
	void Update () {

        if (grounded)
        {
            snakeBody.GetComponent<TailScript>().freeze = true;
            //test.GetComponent<Snake>().testBool = true;
            //Destroy(this);
        }


        if (mutate == false)
        {

            if (Input.GetKey (KeyCode.RightArrow) && horizontal) {
			    horizontal = false;
			    vertical = true;
                vector = Vector2.right;
		    } else if (Input.GetKey (KeyCode.UpArrow) && vertical) {
			    horizontal = true;
			    vertical = false;
			    vector = Vector2.up;
		    } else if (Input.GetKey (KeyCode.DownArrow) && vertical) {
			    horizontal = true;
			    vertical = false;
			    vector = -Vector2.up;
		    } else if (Input.GetKey (KeyCode.LeftArrow) && horizontal) {
			    horizontal = false;
			    vertical = true;
			    vector = -Vector2.right;
		    }

        }

        moveVector = vector / 1f;

        if(mutate == true)
        {
            if (Input.GetKey(KeyCode.RightArrow) && horizontal)
            {
                horizontal = false;
                vertical = true;
                vector = Vector2.right;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && horizontal)
            {
                horizontal = false;
                vertical = true;
                vector = -Vector2.right;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            completeSnak.gameObject.tag = "Untagged";
            CancelInvoke();
            Debug.Log("CutTail");
            //tailOn = true;

            completeSnak.GetComponent<TailScript>().enabled = true;


            //this.gameObject.layer = LayerMask.NameToLayer("Ground");

            //foreach (GameObject oneTail in Tails)
            //{
            //    oneTail.gameObject.layer = LayerMask.NameToLayer("Ground");
            //}

        }

        if(eat == true)
        {
            completeSnak.gameObject.tag = "Untagged";
            CancelInvoke();
            Debug.Log("Nyam");

            completeSnak.GetComponent<TailScript>().enabled = true;
        }

        if (testBool == true)
        {

            this.gameObject.layer = LayerMask.NameToLayer("Ground");

            foreach (GameObject oneTail in Tails)
            {
                oneTail.gameObject.layer = LayerMask.NameToLayer("Ground");
            }

            //StartCoroutine(deleteAfter());

        }
        //} else
        //{
        //    this.gameObject.layer = LayerMask.NameToLayer("Default");

        //    foreach (GameObject oneTail in Tails)
        //    {
        //        oneTail.gameObject.layer = LayerMask.NameToLayer("Default");
        //    }
        //}


        //foreach (GameObject oneTail in Tails)
        //{
        //    oneTail.gameObject.layer = LayerMask.NameToLayer("Ground");
        //}
        //if(testBool == false)
        //{
        //    this.gameObject.layer = LayerMask.NameToLayer("Default");

        //    foreach (GameObject oneTail in Tails)
        //    {
        //        oneTail.gameObject.layer = LayerMask.NameToLayer("Default");
        //    }
        //}

    }

	//public void SpawnFood() {
	//	int x = (int)Random.Range (lBorder.position.x, rBorder.position.x);
	//	int y = (int)Random.Range (bBorder.position.y, tBorder.position.y);
		
	//	Instantiate (food, new Vector2 (x, y), Quaternion.identity);
	//}

    void StartGrow()
    {
        Vector2 ta = transform.position;
        GameObject g = (GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);

        g.transform.parent = completeSnake.transform;

        GameObject g1 = (GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);

        g1.transform.parent = completeSnake.transform;

        GameObject g2 = (GameObject)Instantiate(tailPrefab, ta, Quaternion.identity);

        g2.transform.parent = completeSnake.transform;

        tail.Insert(0, g.transform);
        tail.Insert(0, g1.transform);
        tail.Insert(0, g2.transform);
    }

    //IEnumerator deleteAfter()
    //{
    //    if(testBool == true)
    //    {
    //        yield return new WaitForSeconds(0.3f);
    //        Destroy(this);
    //    }
    //}

	void Movement() {

		Vector2 ta = transform.position;

		 if (tail.Count > 0) {
			tail.Last().position = ta;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
		transform.Translate(moveVector);
	}

	void OnTriggerEnter2D(Collider2D c) {

		if (c.name.StartsWith("food")) {
			eat = true;
			Destroy(c.gameObject);
			//SpawnFood();
		}
		//else {
		//	Application.LoadLevel(1);
		//}
	}
}
