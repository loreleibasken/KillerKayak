using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {
    
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Kayak")
        {
            Destroy(other.gameObject);

            //Application.LoadLevel("End");
        }
    }
}
