using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float speed;

    public GameObject G;
    public float z;
    public Vector3 target;

    public void FixedUpdate()
    {
        target = G.transform.position;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
