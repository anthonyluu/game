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
	void Start () {
		GetComponent<Renderer> ().material = GetMaterialType();
		GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
	}
	
	// Update is called once per frame
	void Update () {

	}

	Material GetMaterialType() {
		switch (tileType)
		{
		case TileType.Water:
			return Resources.Load("Materials/Tiles/water_tile", typeof(Material)) as Material;
		case TileType.Forest:
			return Resources.Load("Materials/Tiles/grass_tile", typeof(Material)) as Material;
		case TileType.Rock:
			return Resources.Load("Materials/Tiles/rock_tile", typeof(Material)) as Material;
		case TileType.Ice:
			return Resources.Load("Materials/Tiles/ice_tile", typeof(Material)) as Material;
		case TileType.Normal:
			return Resources.Load("Materials/Tiles/plain_tile_border", typeof(Material)) as Material;
		default:
			// home
			return Resources.Load("Materials/Tiles/home_tile", typeof(Material)) as Material;
		};
	}


	void OnMouseOver() {
		GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.yellow);
		Debug.Log("On Mouse Over");
	}

	void OnMouseExit() {
		GetComponent<Renderer> ().material.SetColor("_EmissionColor", Color.black);
	}
}

