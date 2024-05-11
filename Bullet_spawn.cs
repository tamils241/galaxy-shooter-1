using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_spawn : MonoBehaviour
{
    Rigidbody2D rb;
    Player player;
    private float bulletSpeed=15f;
    UI_Script UI_Manager;
    public GameObject Explosion;
   
   
    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.Find("Spaceship Shoot").GetComponent<Player>();
        UI_Manager = GameObject.Find("Canvas").GetComponent<UI_Script>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,bulletSpeed);
        Destroy(gameObject,0.8f); 
        
      
    }

    // Update is called once per frame
    void Update()
    {
         
    }
     void OnCollisionEnter2D(Collision2D other)
    { 
    if(other.gameObject.tag=="Enemy" || other.gameObject.tag=="Stone")
    {
        Instantiate(Explosion,transform.position,Quaternion.identity);
        Destroy(this.gameObject,0.10f);
        Destroy(other.gameObject);
        Destroy(gameObject);
        UI_Manager.score_display();
          
    }
    }  
    }

