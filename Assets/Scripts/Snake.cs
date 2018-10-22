using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Snake : MonoBehaviour {

    public GameObject completeSnake;

	public GameObject tailPrefab;
	public GameObject food;
	public Transform rBorder;
	public Transform lBorder;
	public Transform tBorder;
	public Transform bBorder;

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
	
	void Start () {

        respawn = GameObject.FindGameObjectWithTag("Resp");

		//SpawnFood ();
		InvokeRepeating("Movement", speed, speed);
        StartGrow();

        Tails = GameObject.FindGameObjectsWithTag("Tail");
    }
	
	void Update () {

        if(mutate == false)
        {

            if (Input.GetKey (KeyCode.RightArrow) && horizontal) {
			    horizontal = false;
			    vertical = true;
                vector = Vector2.right;
                //vector = Vector3.Lerp(this.transform.position, new Vector3(this.transform.position.x+1,this.transform.position.y,this.transform.position.z),speed);
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
            //Instantiate(newHead, new Vector3(respawn.transform.position.x, this.transform.position.y), Quaternion.identity);
            //Destroy(this);
            CancelInvoke();
            Debug.Log("CutTail");
            //tailOn = true;

            //Tail.GetComponent<TailScript>().enabled = true;

            //Tails[LastTail].GetComponent<TailScript>().enabled = true;
            //Instantiate(tailPrefab, transform.position, Quaternion.identity);
            foreach (GameObject oneTail in Tails)
            {
                oneTail.GetComponent<TailScript>().enabled = true;
                //if(oneTail.GetComponent<TailScript>().grounded == true)
                //{
                //    oneTail.GetComponent<TailScript>().grounded = true;
                //}
                //oneTail.GetComponent<TailScript>().grounded = true;
            }

            this.GetComponent<Snake>().enabled = false;

            //tail.Count = 0;
            //this.GetComponent<Snake>().tail.Count = 0;
        }

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
