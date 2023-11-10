using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField]
    float jumpSpeed = 3;
    [SerializeField]
    AudioClip jump;
    AudioSource audio;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log(gameManager.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Suelo"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        if(collider.CompareTag("Punto"))
        {
            
            gameManager.PointUp();
        }

        if(collider.gameObject.CompareTag("Pipe"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameManager.gameOver==false)
        {
            rb.velocity = new Vector2(0,jumpSpeed);
            audio.Play();
        }
    }
}
