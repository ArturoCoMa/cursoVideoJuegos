using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundAnsPipes : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rbGround1;
    [SerializeField]
    Rigidbody2D rbBackground1;

    [SerializeField]
    Rigidbody2D rbGround2;
    [SerializeField]
    Rigidbody2D rbBackground2;
    Vector3 groundInitPos = new Vector3(21.63f,-4.87f,0f);
    
    // Start is called before the first frame update
    void Start()
    {
        groundInitPos = new Vector3(21.63f,-4.87f,0f);
        rbGround1.velocity = new Vector2(-1.5f,0f);
        rbBackground1.velocity = new Vector2(-0.5f,0f);
        rbGround2.velocity = new Vector2(-1.5f,0f);
        rbBackground2.velocity = new Vector2(-0.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rbGround1.position.x < -19){
            rbGround1.transform.position = groundInitPos;
        }
        if(rbGround2.position.x < -19){
            rbGround2.transform.position = groundInitPos;
        }
    }
}
