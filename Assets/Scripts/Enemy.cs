using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
   
    public float speed;
    public float attackzon;
    
    public GameObject bullet;
    public Transform firepoint;
    public float Hp;
    
    private bool attackon = true;
    public ParticleSystem Effect;
    public ParticleSystem enemyDie;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 v2 = player.position - transform.position;
        enemy.rotation = Quaternion.Euler(0,0,Mathf.Atan2(v2.y,v2.x)*Mathf.Rad2Deg);
        
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= attackzon && attackon)
        {
            
            StartCoroutine(attack());
               // Debug.Log("This is attackzone");

            
        }
        if(distance >= attackzon)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, attackzon);
    // }

    IEnumerator attack()
    {
        attackon = false;
        Instantiate(bullet, firepoint.position, firepoint.rotation);
        //for coroutine return 
        yield return new WaitForSeconds(1); // waiting for second
       
        attackon = true;
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
        GameManager.instance.Score++;
        // GameObject gmObject = GameObject.Find("GameManager");
        // GameManager gm = gmObject.GetComponent<GameManager>();


        Instantiate(enemyDie,transform.position, enemyDie.transform.rotation);

    }
}
