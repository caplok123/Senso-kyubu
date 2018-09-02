using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rostomyfz: MonoBehaviour {
    public float timer;
    public GameObject meme;
    bool gaming = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
    }
     void FixedUpdate()
    {
        
      
        amine();
        ahmed();

    }
    public void amine()
    {
        if (timer > 5f && gaming == false)
        {
            meme.SetActive(false);
            gaming = true;
            timer = 0;
            
        }
    }
    
   
    public void ahmed()
    {
        if (timer > 0f && gaming==true)
        {
            meme.SetActive(true);
            gaming = false;
            
           
        }
    }

}
