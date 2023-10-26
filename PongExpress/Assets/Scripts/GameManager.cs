using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject goal1;
    public GameObject goal2;
    public GameObject player1;
    public GameObject player2;
    public TextMeshProUGUI marcadorP1;
    public TextMeshProUGUI marcadorP2;

    public TextMeshProUGUI winPlayer;

    public static int score1 = 0;
    public static int score2 = 0;

    void Start()
    {
        winPlayer.gameObject.SetActive(false);
    }

    public void Reset(){
        ball.transform.position = new Vector3(0,0,0);
        ball.GetComponent<Ball>().Launch();
        player1.transform.position = new Vector3(-7.73f,-0.08f,0);
        player2.transform.position = new Vector3(7.73f,-0.1f,0);
    }

    public void PointForP1(){
        score2++;
        marcadorP2.text = ""+score2;
        player2.transform.localScale += new Vector3(0f, -0.5f, 0F);
        player1.transform.localScale += new Vector3(0f, 0.5f, 0F);
        Debug.Log("Puntuación: "+score1+":"+score2);
    }

    public void PointForP2(){
        score1++;
        marcadorP1.text = ""+score1;
        player1.transform.localScale += new Vector3(0f, -0.5f, 0F);
        player2.transform.localScale += new Vector3(0f, 0.5f, 0F);
        Debug.Log("Puntuación: "+score1+":"+score2);
    }
    
    void Update()
    {
        Winner();
        LaunchBall();
        ResetScore();
    }

    void LaunchBall(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var go = GameObject.Find("GameManager").GetComponent<GameManager>();
            go.Reset();
        }
    }

    void ResetScore(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            score1 = 0;
            score2 = 0;
            marcadorP1.text = ""+score1;
            marcadorP2.text = ""+score2;
        }
    }

    void Winner(){
        if (score1>=2){
            winPlayer.text = "Player 1 WINS!!!";
            winPlayer.gameObject.SetActive(true);
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }else if (score2>=2){
            winPlayer.text = "Player 2 WINS!!!";
            winPlayer.gameObject.SetActive(true);
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }
    }
}
