using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ninja : MonoBehaviour {
    
    public float speed3;
     public Rigidbody2D fireballprefab;
    public Transform firespawner;
    public Transform fireballprefab1;
    public float speed = 30;
    [SerializeField]
    private float jumpforce=100f;
    public bool onground;
    int extrajump = 2;
    float directionconstant;
    public float timer;
    
    
   

	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        
    }
     void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        directionconstant = Mathf.Sign(transform.localScale.x);
        float a = Input.GetAxisRaw("Horizontal");
        float b = Input.GetAxisRaw("Vertical");
        
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(a, b) * speed;

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Animator>().SetBool("moving", true);
            GetComponent<Animator>().SetBool("stop", false);
            GetComponent<Animator>().SetBool("jump",false);
            GetComponent<Animator>().SetBool("attack", false);
        }
        if (a <0)
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 1);
            fireballprefab.transform.localScale = new Vector3(-0.15f, 0.15f, 1);
        }
        if (a > 0)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
            fireballprefab.transform.localScale = new Vector3(0.15f, 0.15f, 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)  && extrajump>0)
        {
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpforce);

            GetComponent<Animator>().SetBool("jump", true);
            GetComponent<Animator>().SetBool("stop", false);
            GetComponent<Animator>().SetBool("moving", false);
            GetComponent<Animator>().SetBool("attack", false);
            extrajump--;
        }

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetBool("jump", false);
            GetComponent<Animator>().SetBool("stop", true);
            GetComponent<Animator>().SetBool("moving", false);
            GetComponent<Animator>().SetBool("attack", false);
        }
        
       

        if ( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) )
        {
            GetComponent<Animator>().SetBool("stop", true);
            GetComponent<Animator>().SetBool("moving", false);
            GetComponent<Animator>().SetBool("jump", false);
            GetComponent<Animator>().SetBool("attack", false);
        }

        if (Input.GetKeyDown(KeyCode.N) && timer > 0.5f)
        {
            
            Rigidbody2D fireballinstanc;
            fireballinstanc = Instantiate(fireballprefab, firespawner.transform.position, gameObject.transform.rotation)as Rigidbody2D; 
            fireballinstanc.AddForce(firespawner.right * speed3 * directionconstant);

            GetComponent<Animator>().SetBool("attack", true);
            GetComponent<Animator>().SetBool("stop", false);
            GetComponent<Animator>().SetBool("jump", false);
            GetComponent<Animator>().SetBool("moving", false);
            timer = 0f;
         

           
        
        }

        if(Input.GetKeyUp(KeyCode.N))
        {
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetBool("stop", true);
            GetComponent<Animator>().SetBool("jump", false);
            GetComponent<Animator>().SetBool("moving", false);

        }

        if (GetComponent<Animator>().GetBool("jump") == false && GetComponent<Animator>().GetBool("moving") == false &&
            GetComponent<Animator>().GetBool("attack") == false && GetComponent<Animator>().GetBool("stop")==false)
        {
            GetComponent<Animator>().SetBool("stop", true);
        }

        if (onground)
        {
            extrajump = 2;
            GetComponent<Rigidbody2D>().gravityScale = 6;
            GetComponent<Animator>().SetBool("jump", false);
        }

        if (onground==false)
        {
            GetComponent<Animator>().SetBool("jump", true);
            GetComponent<Animator>().SetBool("stop", false);
            GetComponent<Animator>().SetBool("moving", false);
            GetComponent<Animator>().SetBool("attack", false);
        }

        if (extrajump == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 20;
        }

    }
    void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.tag == "ground"){
            onground = true;
                }
        if (col1.gameObject.name == "deathline" )
        {
            GetComponent<Animator>().SetBool("death", false);
            GetComponent<Animator>().SetBool("jump", false);
            GetComponent<Animator>().SetBool("stop", true);
            GetComponent<Animator>().SetBool("moving", false);
            GetComponent<Animator>().SetBool("attack", false);
            
            
        }
        
    }
    
    private void OnTriggerExit2D(Collider2D col2)
    {
        if (col2.tag == "ground")
        {
            onground = false;
        }
        if ( col2.gameObject.name == "deathline")

        {
            GetComponent<Transform>().position = new Vector2(0, 7);
        }
    }
    public void radhi()
    {
        SceneManager.LoadScene(0);
    }
     
   


}
