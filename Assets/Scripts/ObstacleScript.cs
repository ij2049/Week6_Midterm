using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D other) //if obstacle hit
    {
        if (other.gameObject.name.Contains("Player")) //player hit us
        {
            //Call "ResetPlayer" in the ASCIILevelLoader that we reference through
            //the GameManager Singleton
            GameManager.instance.GetComponent<ASCIILevelLoaders>().ResetPlayer();
        }
    }
}
