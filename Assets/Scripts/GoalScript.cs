using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GoalScript : MonoBehaviour
{
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) //if something enters the trigger
    {
        GameManager.instance.GetComponent<ASCIILevelLoaders>().CurrentLevel++;
        //Increase the Score Property in the ASCIILevelLoader
        //that we reference through the GameManager Singleton

    }
}
