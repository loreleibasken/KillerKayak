using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float upForce;                   //Upward force of the "flap".

    private Rigidbody2D rb2d;               

    void Start()
    {       
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
    }

   
}
