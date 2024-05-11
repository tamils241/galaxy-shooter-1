using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawn : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject Enemy1;
    public GameObject[] Power_up;
    float min,max;
    bool stopSpawning = false;
   
     
   

    // Start is called before the first frame update
    void Start()
    {
      min = -8f;
      max = 8f; 
     StartCoroutine(spawn());
     StartCoroutine(Enemy2());
     StartCoroutine(_isPower_Up());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    IEnumerator spawn()
    {
     while(stopSpawning==false)
     {
      var xpos = Random.Range(min,max);
      var position = new Vector2(xpos,transform.position.y);
      GameObject gameObject = Instantiate(Enemy[Random.Range(0,Enemy.Length)],position,Quaternion.identity);
      yield return new WaitForSeconds(3.0f);
      Destroy(gameObject,0.5f); 
     }
     
    }

     IEnumerator Enemy2()
    {
      while(stopSpawning==false)
      {
      var xpos = Random.Range(min,max);
      var position = new Vector3(xpos,transform.position.y,0);
      GameObject gameObject = Instantiate(Enemy1,position,Quaternion.identity);
      yield return new WaitForSeconds(Random.Range(3.0f,7.50f));
      Destroy(gameObject,1f); 
    }
    }
    IEnumerator _isPower_Up()
    {  
       while(stopSpawning==false)
       {
       float rnd = Random.Range(min,max);
       Vector2 spawnPos = new Vector2(Random.Range(min,max), transform.position.y);
       Instantiate(Power_up[Random.Range(0,Power_up.Length)], spawnPos, Quaternion.identity);
       yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));
       //yield return new WaitForSeconds(3f);
    }
    }
    public void death()
    {
     stopSpawning=true;
    }

}
