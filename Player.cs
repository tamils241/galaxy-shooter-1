using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject playerBulletPrefab; // Bullet prefab //
    public Transform playerBulletSpawnPoint; // Bullet Spawn Point //
    public Transform playerBulletSpawnPoint1; // Bullet Spawn Point //
    public Transform playerBulletSpawnPoint3; // Bullet Spawn Point //
    public float playerSpeed = 8.0f; // Player moving speed //
    public float multipl_speed=2f; // Player moving speed with in mutiple speed //
    public float fireRate = 0.25f; // Fire bullet Rest time // 
    private float nextFireTime = 0f; // Fire bullet time // 
    public float bulletSpeed = 10f; // fire bullet speed //
    float minX,maxX; //xAxis mani and max //
    float minY,maxY;  //yAxis mini and max //
    public Animator ain; // Animator //
    public bool du_bullet=false; // double Bullet bool //
    public bool palyer_speed=false; // Player speed bool //
    public bool sef_move=false; // sef_move bool //
    public int maxHealth = 4; // Maximum health of the player
    private int currentHealth; // Current health of the player
    public Image[] heartImages; // Array of heart images to display health visually
    public Sprite fullHeart; // Sprite for a full heart
    public Sprite emptyHeart; // Sprite for an empty heart
    UI_Script  UI_Manager; // UI script called methoed //
    Enemy_spawn Enemy_Manager; // Enemy spawn script called //
    public GameObject Explosion; //  Explosion prefab // 
    public AudioSource _audioSource;
    public GameObject Shield;
   

    // Start is called before the first frame update
    void Start()
    {
        minX = -7.50f; // xAxis mini value //
        maxX = 7.50f; // xAxis max value //
        minY = -3.50f; // yAxis mini value //
        maxY = 3.50f; // yAxis max value //
        ain =GetComponent<Animator>();
        UI_Manager = GameObject.Find("Canvas").GetComponent<UI_Script>();
        Enemy_Manager = GameObject.Find("Enemy_spawn_point").GetComponent<Enemy_spawn >();
        _audioSource = GetComponent<AudioSource>(); 
        currentHealth = maxHealth;
        UpdateHealth(); 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FireBullet();
    }
    // Player moving function //
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal")* playerSpeed * Time.deltaTime;;
        float verticalInput = Input.GetAxis("Vertical")* playerSpeed * Time.deltaTime;;
        float newXpos = Mathf.Clamp(transform.position.x + horizontalInput,minX,maxX);
        float newYpos = Mathf.Clamp(transform.position.y + verticalInput,minY,maxY);
        transform.position = new Vector2(newXpos,transform.position.y);
        transform.position = new Vector2(transform.position.x,newYpos);
    } 
    // fire Bullet function // 
    void FireBullet()
    {
         if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        { 
            nextFireTime = Time.time + fireRate;
            if(du_bullet == true)
            {
               Instantiate(playerBulletPrefab, playerBulletSpawnPoint.position, Quaternion.identity);
               Instantiate(playerBulletPrefab, playerBulletSpawnPoint1.position, Quaternion.identity);
            }
            else
            {
              Instantiate(playerBulletPrefab,playerBulletSpawnPoint3.position, Quaternion.identity);
            }
            ain.Play("Player_shoot");
            _audioSource.Play(); 
                
        }
    } 
    //Player colliding function //
     //private void OnCollisionEnter2D(Collision2D other)
     private void OnTriggerEnter2D(Collider2D other)
    {
    // double Bullet collision //    
     if(other.gameObject.tag =="du_bullet")
     {
      Debug.Log("bullet is trigger");
       Destroy(other.gameObject);
       triple_bullet_spawn();
     }
     // sef_move collision //
     if(other.gameObject.tag =="Sef")
     {
      Debug.Log("sef is trigger");
       Destroy(other.gameObject);
       SefMove();
     }
     // speed move collision //
     if(other.gameObject.tag =="Move")
     {
       Debug.Log("move is trigger");
       Destroy(other.gameObject);
       fastMove();
     } 
     // life Heart increase collision //
     if(other.gameObject.tag =="Heart")
     {
      Debug.Log("heart is trigger");
       Destroy(other.gameObject);
       increaseHealt();
     }
    }
     // Damage player collision Enemy and stone //
     private void OnCollisionEnter2D(Collision2D other1)
     {
     if(other1.gameObject.tag == "Enemy" || other1.gameObject.tag == "Stone")
     {
      Destroy(other1.gameObject);
      TakeDamage();

     }
    }
    // triple bullet spwan function // 
    public void triple_bullet_spawn()
    {
      du_bullet=true;
      StartCoroutine(_triple_bullet());
    }
    IEnumerator _triple_bullet()
    {
        yield return new WaitForSeconds(5.0f);
        du_bullet=false;
    } 

    // fasts move player script //
    public void fastMove()
    {
     palyer_speed=true;
     playerSpeed = playerSpeed*multipl_speed;
     StartCoroutine(_fastMove());
    }
    IEnumerator _fastMove()
    {
        yield return new WaitForSeconds(5.0f);
        playerSpeed = playerSpeed/multipl_speed;
        palyer_speed = false;
    }
    // Sef move script //
     public void SefMove()
     {
        sef_move=true;
        Shield.SetActive(true);
        StartCoroutine(_sefMove());
     }
     IEnumerator _sefMove()
     {
        yield return new WaitForSeconds(5.0f);
        sef_move=false;
        Shield.SetActive(false);
     }
    //  palyer health increase //
     public void increaseHealt()
     {
        Heal();
     }

    // palyer health script //
      void UpdateHealth()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHealth)
                heartImages[i].sprite = fullHeart;
            else
                heartImages[i].sprite = emptyHeart;
        }
    }

    // Inflict damage to the player
    public void TakeDamage()
    {
      if(sef_move==false)
      {
        currentHealth --;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(Explosion,transform.position,Quaternion.identity);
            Enemy_Manager.death();
            Destroy(gameObject);
            UI_Manager.Reset.gameObject.SetActive(true);  
        }
         UpdateHealth();
      }
       
    }

    // Heal the player
    public void Heal()
    {
        currentHealth ++;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
            UpdateHealth();
    }
   
}
   
    

