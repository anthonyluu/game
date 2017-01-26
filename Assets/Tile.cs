using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseOver() {
		GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.white);
		Debug.Log("On Mouse Over");
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
	}
}

