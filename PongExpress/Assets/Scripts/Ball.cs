using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    public AudioSource audioPalas;
    public AudioSource audioMuros;

    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(){
        float x = UnityEngine.Random.Range(0,2) == 0?-1:1;
        float y = UnityEngine.Random.Range(0,2) == 0?-1:1;
        rb.velocity = new Vector2(x*speed, y*speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            audioPalas.Play();
            //Aquí tiene que aumentar la velocidad de la bola
        }

        if(collision.gameObject.CompareTag("Wall"))
        {
            audioMuros.Play();
        }
    }
}
