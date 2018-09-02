using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjas2 : MonoBehaviour
{

    public float speed3;
    public Rigidbody2D fireballprefab;
    public Transform firespawner;
    public Transform fireballprefab1;
    public float speed = 30;
    [SerializeField]
    private float jumpforce = 100f;
    public bool onground;
    
    int extrajump = 2;
    public float timer;
    

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    void FixedUpdate()
    {

        float a = Input.GetAxisRaw("Horizontal2");
        float b = Input.GetAxisRaw("Vertical2");


        GetComponent<Rigidbody2D>().velocity = new Vector2(a, b) * speed;

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("moving2", true);
            GetComponent<Animator>().SetBool("stop2", false);
            GetComponent<Animator>().SetBool("jump2", false);
            GetComponent<Animator>().SetBool("attack2", false);
            GetComponent<Animator>().SetBool("death2", false);
        }
        if (a < 0)
        {
            transform.localScale = new Vector3(-0.7f, 0.7f, 1);
        }
        if (a > 0)
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
        }
        if (Input.GetKeyDown(KeyCode.W) && extrajump > 0)
        {
           
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpforce);

            GetComponent<Animator>().SetBool("jump2", true);
            GetComponent<Animator>().SetBool("stop2", false);
            GetComponent<Animator>().SetBool("moving2", false);
            GetComponent<Animator>().SetBool("attack2", false);
            extrajump--;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("jump2", false);
            GetComponent<Animator>().SetBool("stop2", true);
            GetComponent<Animator>().SetBool("moving2", false);
            GetComponent<Animator>().SetBool("attack2", false);
        }



        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("stop2", true);
            GetComponent<Animator>().SetBool("moving2", false);
            GetComponent<Animator>().SetBool("jump2", false);
            GetComponent<Animator>().SetBool("attack2", false);
        }

        if (Input.GetKeyDown(KeyCode.C) && timer>0.5f)
        {
            Rigidbody2D fireballinstanc;
            fireballinstanc = Instantiate(fireballprefab, firespawner.transform.position, gameObject.transform.rotation) as Rigidbody2D;
            fireballinstanc.AddForce(firespawner.right * speed3 * Mathf.Sign(transform.localScale.x));

            GetComponent<Animator>().SetBool("attack2", true);
            GetComponent<Animator>().SetBool("stop2", false);
            GetComponent<Animator>().SetBool("jump2", false);
            GetComponent<Animator>().SetBool("moving2", false);
            timer = 0;


        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            GetComponent<Animator>().SetBool("attack2", false);
            GetComponent<Animator>().SetBool("stop2", true);
            GetComponent<Animator>().SetBool("jump2", false);
            GetComponent<Animator>().SetBool("moving2", false);

        }

        if (GetComponent<Animator>().GetBool("jump2") == false && GetComponent<Animator>().GetBool("moving2") == false &&
            GetComponent<Animator>().GetBool("attack2") == false && GetComponent<Animator>().GetBool("stop2") == false)
        {
            GetComponent<Animator>().SetBool("stop2", true);
        }

        if (onground)
        {
            extrajump = 2;
            GetComponent<Rigidbody2D>().gravityScale = 6;
            GetComponent<Animator>().SetBool("jump2", false);
        }

        if (onground == false)
        {
            GetComponent<Animator>().SetBool("jump2", true);
            GetComponent<Animator>().SetBool("stop2", false);
            GetComponent<Animator>().SetBool("moving2", false);
            GetComponent<Animator>().SetBool("attack2", false);
        }

        if (extrajump == 0)
        {
            GetComponent<Rigidbody2D>().gravityScale = 20;
        }






        if (GetComponent<Transform>().localScale.x < 0)
        {


            transform.localScale = new Vector3(-0.7f, 0.7f, 1);
            //Weapon.transform.localscale = new  Vector3 (-0.15f, 0.15f, 1);

        }
        else
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 1);
            //Weapon.transform.localscale = new  Vector3 (0.15f, 0.15f, 1);
        }



    }
    void OnTriggerEnter2D(Collider2D col1)
    {
        if (col1.tag == "ground")
        {
            onground = true;
        }
        if (col1.gameObject.name == "deathline")
        {
            GetComponent<Animator>().SetBool("death2", false);
            GetComponent<Animator>().SetBool("jump2", false);
            GetComponent<Animator>().SetBool("stop2", true);
            GetComponent<Animator>().SetBool("moving2", false);
            GetComponent<Animator>().SetBool("attack2", false);
            
        }
    }
     void OnTriggerExit2D(Collider2D col2)
    {
        if (col2.tag == "ground")
        {
            onground = false;
        }
        if (col2.gameObject.name =="deathline")
        {
            GetComponent<Transform>().position = new Vector2(0, 7);
        }
    }
  


}
