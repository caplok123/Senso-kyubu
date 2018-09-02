using UnityEngine;

using System.Collections;



public class fkoff: MonoBehaviour
{    Rigidbody2D b;
     public float speed;
  
     void Start()
    {
         b = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float a = Input.GetAxisRaw("horizontal");
        b.velocity = new Vector2(a, 0) * speed;
    }









}