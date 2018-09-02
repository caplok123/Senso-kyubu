using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health1 : MonoBehaviour {
    public  float health;
    public float healthstatic;
    public Slider slider;
  
    public GameObject healththing;
    public GameObject azer;
    public GameObject aze;
    public GameObject azer1;
    public GameObject azert;
    public GameObject azerty;
    public bool ok;
    public bool ok1;
    public bool ok2;
    public GameObject lk;
    public GameObject hi;
    public GameObject playbutton;
    bool player1;
    bool player2;
    
	// Use this for initialization
	void Start () {
        health = 100f;
        healthstatic = 100f;
        aze.SetActive(false);
        azer.SetActive(true);
        azer1.SetActive(false);
        lk.SetActive(false);
      

	}
	
	// Update is called once per frame
	void Update () {
        slider.value = health / healthstatic;
        
	}
     void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "dmg")
        {
            health -= 2f;
        }
        if(collision.gameObject.name=="spike")
        {
            health -= 10;
        }
        if(collision.gameObject.name=="hh1")
        {
            ok = true;
        }
        if(collision.gameObject.name=="hh2")
        {
            ok1 = true;
        }
        if (collision.gameObject.name == "hh3")
        {
            ok2 = true;
        }
    }
    void chihi()
    {
        if(health <= 0 && ok1 == true)
        {
          
            azer.SetActive(false);
            aze.SetActive(true);
            azert.transform.position = new Vector3(1f, 3f, 0f);
            azerty.transform.position = new Vector3(-1f, 3f, 0f);
            health = 100;
            ok1 = false;


           

        }
        if(health<=0 && ok==true)
        {
            azer1.SetActive(true);
            aze.SetActive(false);
            azer.SetActive(false);
            azert.transform.position = new Vector3(1f, 3f, 0f);
            azerty.transform.position = new Vector3(-1f, 3f, 0f);
            health = 100;
            ok = false;
        }
        if (health <= 0 && ok2 == true){
            {

                azer1.SetActive(false);
                aze.SetActive(false);
                azer.SetActive(false);
                lk.SetActive(true);
                azert.SetActive(false);
                azerty.SetActive(false);
              
            }
        }
        
        if(health <= 0)
        {
            health = 0;
            healththing.SetActive(false);   
        }
        if (health > 0)
        {
            healththing.SetActive(true);
        }
        
       
    }
   
     void FixedUpdate()
    {
        
        chihi();
      
      
       
    }
    void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.gameObject.name == "deathline")
        {
            health -= 5;
        }
      
    }
   
}
