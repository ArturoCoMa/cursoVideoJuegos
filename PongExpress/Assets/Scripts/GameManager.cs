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

    public enum PlayerControllerState{
        ready,
        playing,
        gameOver
    }

    private PlayerControllerState state;

    void Start()
    {
        state = PlayerControllerState.ready;
        winPlayer.gameObject.SetActive(false);
    }

    

    public void PointForP(String playerScoring){
        if(playerScoring == "1"){
            score1++;
            marcadorP1.text = ""+score1;
            player2.transform.localScale += new Vector3(0f, -0.5f, 0F);
            player1.transform.localScale += new Vector3(0f, 0.5f, 0F);
        }else{
            score2++;
            marcadorP2.text = ""+score2;
            player1.transform.localScale += new Vector3(0f, -0.5f, 0F);
            player2.transform.localScale += new Vector3(0f, 0.5f, 0F);
        }
        
        Debug.Log("Puntuación: "+score1+":"+score2);
        
        if (score1 >= 2 || score2 >= 2){
            state = PlayerControllerState.gameOver;
        }else{
            state = PlayerControllerState.ready;
        }
        
    }
    
    void Update()
    {

        switch (state){
            case PlayerControllerState.ready:
                UpdateReady();
            break;
            case PlayerControllerState.playing:
                UpdatePlaying();
            break;
            case PlayerControllerState.gameOver:
                UpdateGameOver("");
            break;
        }
    }

    void UpdateReady(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var go = GameObject.Find("GameManager").GetComponent<GameManager>();
            go.Reset();
            state = PlayerControllerState.playing;
        }
    }

    public void Reset(){
        ball.transform.position = new Vector3(0,0,0);
        ball.GetComponent<Ball>().Launch();
        player1.transform.position = new Vector3(-7.73f,-0.08f,0);
        player2.transform.position = new Vector3(7.73f,-0.1f,0);
    }


    void ResetScore(){
        if (Input.GetKeyDown(KeyCode.Tab)){
            score1 = 0;
            score2 = 0;
            marcadorP1.text = ""+score1;
            marcadorP2.text = ""+score2;
        }
    }

    void UpdatePlaying(){
        ResetScore();
    }

    void UpdateGameOver(String winner){
        winPlayer.text = "Player "+winner+" WINS!!!";
        if (Input.GetKeyDown(KeyCode.Space)){
            Reset();
            ResetScore();
        }else if (Input.GetKeyDown(KeyCode.Escape)){
            winPlayer.gameObject.SetActive(true);
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }
}
