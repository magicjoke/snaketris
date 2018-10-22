using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    public GameObject target; //the enemy's target
    public float moveSpeed = 5; //move speed
    private Rigidbody rb;
    private Transform mytransform;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mytransform = target.transform;
    }
    void Update()
    {
        //rotate to look at the player
        transform.position = Vector3.Lerp(transform.position, target.transform.position, moveSpeed);
        //move towards the player
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }
}
