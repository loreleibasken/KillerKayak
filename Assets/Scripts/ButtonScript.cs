﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{

	
	void Start ()
    {
		
	}
	
	
	void Update ()
    {
		
	}

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
