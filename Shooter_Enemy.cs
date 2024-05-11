using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Enemy : MonoBehaviour
{
    public float speed=2f;
    float minX,maxX;
    public GameObject Enemy_shooter;
    //public GameObject shooter_enemy_spawn;
    // Start is called before the first frame update
    void Start()
    {
      minX = -8f;
      maxX = 8f; 
      //StartCoroutine(Enemy_shooter_Spawn());
    }

    // Update is called once per frame
    void Update()
    {
      //transform.Translate(new Vector3(0,speed,0)*Time.deltaTime);
      //transform.Translate(Vector3.down*speed*Time.deltaTime);
    }
    IEnumerator Enemy_shooter_Spawn()
    { 
       var pos = Random.Range(minX,maxX);
       var position = new Vector2(pos,transform.position.y);
        Instantiate(Enemy_shooter,transform.position,Quaternion.identity);
        yield return new WaitForSeconds(10f);
        StartCoroutine(Enemy_shooter_Spawn());
        Destroy(gameObject,2f); 

    }
}
