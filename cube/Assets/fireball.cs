using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
  

	// Use this for initialization
	void Start () {
        

    }

    // Update is called once per frame
    void Update () {
		
	}
     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "background")
        {
            Destroy(gameObject);
        }
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="hh")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name=="spike")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.name =="hh1")
        {
            Destroy(gameObject);
         
        }
        if(collision.gameObject.name=="hh3")
        {
            Destroy(gameObject);
        }
    }
}
