﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victoryscreen : MonoBehaviour {
    public float timer;

	// Use this for initialization
	void Start () {
        timer = 3;

    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }


    }
}
