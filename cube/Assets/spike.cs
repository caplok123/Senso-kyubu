﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour {
    public float Speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, Speed * Time.deltaTime, Space.Self);

		
	}
}
