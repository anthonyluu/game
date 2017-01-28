﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
	[Range(0,1)]
	public float terrain_ratio = 0.3f; // The lower it is, the less terrain there will be

	public int width;
	public int height;

	public GameObject TilePrefab;

	// TODO: Refactor this
	public GameObject MonsterPrefab;

	private List<List<Tile>> map;

	// Use this for initialization
	void Start () {
		GenerateMap ();
		SetupMapTerrain ();
//		CreateMonster ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void GenerateMap() {
		// Initialize the map and add Instantiated Tiles to it
		map = new List<List<Tile>>();
		for (int x = 0; x < width; x++) {
			List<Tile> row = new List<Tile> ();
			for (int z = 0; z < height; z++) {
				Tile tile = ((GameObject)Instantiate( TilePrefab, new Vector3(x - Mathf.Floor(width/2), 0, -z + Mathf.Floor(height/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.tilePosition = new Vector2 (x, z);
				row.Add (tile);
			}
			map.Add (row);
		}
	}

	void SetupMapTerrain() {
		// iterate through map
		// if its the first or last column, set it to "Home". This is where players will start
		// else, randomly generate terrain based on terrain_ratio

		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				// We should only have 9 tiles in the x axis. the left and right most are Home TileTypes.
				if (x == 0 || x == 8) {
					map [x] [z].tileType = TileType.Home;
				} else {
					// get a unif distr to determine which tiles are which
					map[x][z].tileType = GetRandomTileType();


				}
			}
		}
	}

	private TileType GetRandomTileType() {
		// Randomly generate a value, then compare it with the terrain_ratio
		// high terrain ratio will result in a lot of terrain
		// low terrain ratio will result in very little terrain

		// Random value
		float randomVal = Random.Range (0.0f, 1.0f);

		if (terrain_ratio < randomVal) {
			// we'll keep it normal
			return TileType.Normal;
		} else {
			// we wanna pick a random value out of water, forest, rock, ice
			return (TileType)Random.Range(0, 3);
		}
	}

//	// This needs to be moved into a game manager class
//	public void CreateMonster() {
//		Tile startTile = map [0][1];
//
//		Monster monster = ((GameObject)Instantiate( MonsterPrefab, new Vector3(startTile.transform.position.x, 1, startTile.transform.position.z), Quaternion.Euler(new Vector3()))).GetComponent<Monster>();
//
//		List<Tile> movementPath = Path.GetTilePath(monster.movement, startTile, map);
//
//		for (int i = 0; i < movementPath.Count; i++) {
//			// for some reason, this doesnt work.
//			movementPath [i].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.green);
//			Debug.Log ("i:" + movementPath [i].tilePosition.x + ", y:" + movementPath [i].tilePosition.y);
//		}
//	}
}
