using UnityEngine;
using System.Collections;


public enum TileType {
	Water,
	Forest,
	Rock,
	Ice,
	Normal,
	Home,
}

public class Tile : MonoBehaviour
{
	
	public TileType tileType = TileType.Normal;
	public Vector2 tilePosition;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Renderer> ().material.SetColor("_EmissionColor", GetTileColor());
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	Color GetTileColor()
	{
		switch (tileType)
		{
		case TileType.Water:
			return Color.blue;
		case TileType.Forest:
			return Color.green;
		case TileType.Rock:
			return Color.grey;
		case TileType.Ice:
			return Color.cyan;
		case TileType.Normal:
			return Color.clear;
		default:
			// Home color
			return Color.yellow;
		};

	}


	void OnMouseOver() {
//		GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.white);
		Debug.Log("On Mouse Over");
	}

	void OnMouseExit() {
//		GetComponent<Renderer> ().material.SetColor("_EmissionColor", GetTileColor());
	}
}

