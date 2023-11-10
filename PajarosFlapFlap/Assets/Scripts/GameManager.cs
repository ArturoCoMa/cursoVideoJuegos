using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int puntos;

    [SerializeField]    
    TextMeshProUGUI textScore;
    [SerializeField]    
    TextMeshProUGUI textGameOver;
    [SerializeField]    
    TextMeshProUGUI textFinalScore;
    [SerializeField]    
    TextMeshProUGUI textStarting1;
    [SerializeField]    
    TextMeshProUGUI textStarting2;
    [SerializeField] 
    GameObject medalla;
    [SerializeField] 
    GameObject gold;
    [SerializeField] 
    GameObject bird;
    [SerializeField] 
    GameObject spawner;
    float nextMiniMedalX;
    float nextMiniMedalY;
    float goldX;
    float goldY;
    int miniMedals;
    public bool gameOver;
    public bool starting;

    [SerializeField] 
    AudioClip musica;
    AudioSource audioSource;

    List<GameObject> miniMedalList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        starting = true;
        gameOver = false;
        puntos = 0;
        miniMedals = 0;
        nextMiniMedalX = -7.17f;
        nextMiniMedalY = 4.36f;
        goldX = -8.11f;
        goldY = 3.27f;
    }

    // Update is called once per frame
    void Update()
    {
        if(starting){
            if(Input.GetKeyDown(KeyCode.Space))
            {
                textStarting1.gameObject.SetActive(false);
                textStarting2.gameObject.SetActive(false);
                Instantiate(bird).transform.position = new Vector3(0f, 0f, 0f);
                Instantiate(spawner);
                starting = false;
            }
        }
 
    }
    public void PointUp()
    {
        puntos++;
        textScore.text = ""+puntos;

        if(puntos%2 == 0)
        {
            var medalinstance = Instantiate(medalla); 
            medalinstance.transform.position = new Vector3(nextMiniMedalX, nextMiniMedalY, 0f);
            miniMedalList.Add(medalinstance);
            nextMiniMedalX += 1f;
            miniMedals++;
            if(miniMedals == 2)
            {
                Instantiate(gold).transform.position = new Vector3(goldX, goldY, 0f);
                goldX += 1f;
                RemoveMiniMedals();
                miniMedals = 0;
            }
        }
        
    }

    public void RemoveMiniMedals()
    {
        foreach(GameObject medal in miniMedalList)
        {
            GameObject.Destroy(medal);
            nextMiniMedalX = -7.17f;
            nextMiniMedalY = 4.36f;
        }
    }
}
