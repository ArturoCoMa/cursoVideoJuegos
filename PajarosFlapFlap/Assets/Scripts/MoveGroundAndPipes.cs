using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGroundAnsPipes : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-0.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
