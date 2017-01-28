using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map {
	int width;
	int height;
	float terrain_ratio;
	GameObject TilePrefab;
	List<List<Tile>> map;

	public List<List<Tile>> GenerateMap(GameObject TilePrefab, int width, int height, float terrain_ratio) {
		this.width = width;
		this.height = height;
		this.terrain_ratio = terrain_ratio;
		this.TilePrefab = TilePrefab;
		CreateMap ();
		SetupMapTerrain ();
		GetRandomTileType ();
		return map;
	}

	private void CreateMap() {
		// Initialize the map and add Instantiated Tiles to it
		map = new List<List<Tile>>();
		for (int x = 0; x < width; x++) {
			List<Tile> row = new List<Tile> ();
			for (int z = 0; z < height; z++) {
				Tile tile = ((GameObject) MonoBehaviour.Instantiate( TilePrefab, new Vector3(x - Mathf.Floor(width/2), 0, -z + Mathf.Floor(height/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.tilePosition = new Vector2 (x, z);
				row.Add (tile);
			}
			map.Add (row);
		}
	}
		
	private void SetupMapTerrain() {
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

	public void RemoveTileHighlights() {
		// remove any emission color
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				map [i] [j].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.black);
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
		
}
