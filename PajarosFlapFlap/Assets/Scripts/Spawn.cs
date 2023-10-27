using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    
    [SerializeField]
    GameObject pipeDownPrefab;
    [SerializeField]
    GameObject pipeUpPrefab;
    float timer;
    float limitTimeSpawn;
    float desviacion;

    // Start is called before the first frame update
    void Start()
    {
        desviacion = UnityEngine.Random.Range(-3,3);
        Instantiate(pipeDownPrefab).transform.position = new Vector3(9.99f,-3.27f+desviacion, 0f);
        Instantiate(pipeUpPrefab).transform.position = new Vector3(9.99f,4.99f+desviacion, 0f);
        timer = 0f;
        limitTimeSpawn = UnityEngine.Random.Range(3,7);
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > limitTimeSpawn){
            desviacion = UnityEngine.Random.Range(-3,3);
            timer = 0f;
            Instantiate(pipeDownPrefab).transform.position = new Vector3(9.99f,-3.27f+desviacion, 0f);
            Instantiate(pipeUpPrefab).transform.position = new Vector3(9.99f,4.99f+desviacion, 0f);
            limitTimeSpawn = UnityEngine.Random.Range(6,8);

        }
        
    } 
}
