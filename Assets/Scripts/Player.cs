using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //public static Player instance2 = null;
    public float Hp;
    public ParticleSystem Effect;
    public ParticleSystem playerDie;
    
    
    // public static PlayerControl instance;
    
    // Start is called before the first frame update
    
    // void Awake()
    // {
    //     if (instance == null)  //instance hasn't been set yet
    //     {
    //         DontDestroyOnLoad(gameObject);  //Dont Destroy this object when you load a new scene
    //         instance = this; //set instance to this object
    //     }
    //     else //if the instance is already set to an object
    //     {
    //         Destroy(gameObject);  //destroy this new object, so there is only ever one
    //     }
    // }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Hp -= 1;
            Destroy(collision.gameObject);
            Instantiate(Effect, collision.transform.position, Effect.transform.rotation);
        }
    }

    private void OnDestroy()
    {
        Instantiate(playerDie,transform.position, playerDie.transform.rotation);
    }
}
