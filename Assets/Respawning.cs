using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    public GameObject resp;
    public GameObject snake;

    public Transform rBorder;
    public Transform lBorder;
    public Transform tBorder;
    public Transform bBorder;

    public GameObject food;

    public float spawnCount;
    public float targetCount = 4;

    void FixedUpdate()
    {
        if (spawnCount >= targetCount)
        {
            bBorder.position = new Vector3(bBorder.transform.position.x, bBorder.transform.position.y + 1, 10);
            targetCount += 4;
        }
    }


    void Start()
    {
        resp = GameObject.FindGameObjectWithTag("Resp");
        spawnCount++;
        SpawnFood ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            Instantiate(snake, resp.transform.position, Quaternion.identity);
            SpawnFood();
            spawnCount++;
        }

    }

    public void SpawnFood()
    {
        int x = (int)Random.Range(lBorder.position.x, rBorder.position.x);
        int y = (int)Random.Range(bBorder.position.y, tBorder.position.y);

        Instantiate(food, new Vector2(x, y), Quaternion.identity);
    }
}
