﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public float bgSpeed;
    public Renderer bgRend;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bgRend.material.mainTextureOffset += new Vector2(0f, bgSpeed * Time.deltaTime);
	}
}
