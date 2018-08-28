using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject PlayerChar;
    float closeTimer;
    float attackTimer;
	// Use this for initialization
	void Start () {
        PlayerChar = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
