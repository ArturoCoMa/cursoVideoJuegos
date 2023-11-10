using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundAnsPipes : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rbBackground1;

     [SerializeField]
    Rigidbody2D rbBackground2;

    [SerializeField]
    Rigidbody2D rbGround1;

    [SerializeField]
    Rigidbody2D rbGround2;
   
    Vector3 groundInitPos;
    Vector3 backGroundInitPos;


    // Start is called before the first frame update
    void Start()
    {
        //Posiciones
        groundInitPos = new Vector3(21.63f,-4.87f,0f);
        backGroundInitPos = rbBackground2.position;


        //Velocidades
        rbGround1.velocity = new Vector2(-1.5f,0f);
        rbGround2.velocity = new Vector2(-1.5f,0f);
        rbBackground1.velocity = new Vector2(-0.5f,0f);
        rbBackground2.velocity = new Vector2(-0.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        goundMovement();
        backGroundMovement();
    }

    void goundMovement()
    {
        if(rbGround1.position.x < -19)
        {
            rbGround1.transform.position = groundInitPos;
        }
        if(rbGround2.position.x < -19)
        {
            rbGround2.transform.position = groundInitPos;
        }
    }

    void backGroundMovement(){
        if(rbBackground1.position.x < -20)
        {
            rbBackground1.transform.position = backGroundInitPos;        
        }
        if(rbBackground2.position.x < -20)
        {
            rbBackground2.transform.position = backGroundInitPos;
        }
    }
}
