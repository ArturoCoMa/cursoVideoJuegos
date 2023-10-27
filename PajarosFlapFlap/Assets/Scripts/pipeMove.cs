using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-1.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position.x < -10){
            GameObject.Destroy(gameObject);
        }
    }
}
