using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{

	private Color originalColor;

	// Use this for initialization
	void Start ()
	{
		originalColor = GetComponent<Renderer> ().material.color;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnMouseOver() {
		GetComponent<Renderer> ().material.SetColor ("_Color", Color.yellow);
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.SetColor ("_Color", originalColor);
	}
}

