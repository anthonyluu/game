using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	public int something;
	public string value;
	public int width;
	public int height;

	public GameObject TilePrefab;

	private List<List<Tile>> map;

	// Use this for initialization
	void Start () {
		GenerateMap ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void GenerateMap() {
		map = new List<List<Tile>>();
		for (int x = 0; x < width; x++) {
			List<Tile> row = new List<Tile> ();
			for (int z = 0; z < height; z++) {
				Tile tile = ((GameObject)Instantiate( TilePrefab, new Vector3(x - Mathf.Floor(width/2), 0, -z + Mathf.Floor(height/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				row.Add (tile);
			}
			map.Add (row);
		}
	}
}
