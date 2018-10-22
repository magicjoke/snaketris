using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseChecker : MonoBehaviour
{
    public Transform posePoint_1;
    public Transform posePoint_2;
    public Transform posePoint_3;
    public Transform posePoint_4;
    public Transform posePoint_5;
    public Transform posePoint_6;
    public Transform posePoint_7;
    public Transform posePoint_8;
    public Transform posePoint_9;
    public Transform posePoint_10;
    public Transform posePoint_11;
    public Transform posePoint_12;
    public float poseCheckRadius;
    public LayerMask whatIsBlock;
    public bool point_1;
    public bool point_2;
    public bool point_3;
    public bool point_4;
    public bool point_5;
    public bool point_6;
    public bool point_7;
    public bool point_8;
    public bool point_9;
    public bool point_10;
    public bool point_11;
    public bool point_12;


    void FixedUpdate()
    {
        point_1 = Physics2D.OverlapCircle(posePoint_1.position, poseCheckRadius, whatIsBlock);
        point_2 = Physics2D.OverlapCircle(posePoint_2.position, poseCheckRadius, whatIsBlock);
        point_3 = Physics2D.OverlapCircle(posePoint_3.position, poseCheckRadius, whatIsBlock);
        point_4 = Physics2D.OverlapCircle(posePoint_4.position, poseCheckRadius, whatIsBlock);
        point_5 = Physics2D.OverlapCircle(posePoint_5.position, poseCheckRadius, whatIsBlock);
        point_6 = Physics2D.OverlapCircle(posePoint_6.position, poseCheckRadius, whatIsBlock);
        point_7 = Physics2D.OverlapCircle(posePoint_7.position, poseCheckRadius, whatIsBlock);
        point_8 = Physics2D.OverlapCircle(posePoint_8.position, poseCheckRadius, whatIsBlock);
        point_9 = Physics2D.OverlapCircle(posePoint_9.position, poseCheckRadius, whatIsBlock);
        point_10 = Physics2D.OverlapCircle(posePoint_10.position, poseCheckRadius, whatIsBlock);
        point_11 = Physics2D.OverlapCircle(posePoint_11.position, poseCheckRadius, whatIsBlock);
        point_12 = Physics2D.OverlapCircle(posePoint_12.position, poseCheckRadius, whatIsBlock);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
