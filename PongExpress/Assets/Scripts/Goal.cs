using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool goal1;
    GameManager go;

    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            if(goal1){
                go.PointForP1();
            }else{
                go.PointForP2();
            }
        }
        
    }
}
