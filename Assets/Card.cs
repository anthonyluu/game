using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.SetColor("_Color", Color.magenta);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
