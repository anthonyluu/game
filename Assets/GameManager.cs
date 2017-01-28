using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance;

	[Range(0,1)]
	public float terrain_ratio = 0.3f; // The lower it is, the less terrain there will be

	public int map_width;
	public int map_height;

	public GameObject TilePrefab;
	public GameObject MonsterPrefab;

	public Map mapObj;
	public List<List<Tile>> map;

	public List<Monster> team1;
	public List<Monster> team2;
	public List<Monster> active_team; // the active team is the team who's turn it currently is
	public int monster_index = 0;

	// if true, its team1's turn, else its team2's turn
	public bool team1_turn = true;


	void Start () {
		instance = this;
		mapObj = new Map ();
		map = mapObj.GenerateMap (TilePrefab, map_width, map_height, terrain_ratio);
		SetupMonsters ();
	}

	void Update () {
		if (active_team [monster_index].health < 0) {
			// if your character is dead, go to the next turn
			NextTurn ();
		}
		
	}

	void OnGUI() {
		active_team [monster_index].TurnOnGUI ();
	}

	// will be called if your monster is dead, or if the current monster has finished its turn
	public void NextTurn() {
		mapObj.RemoveTileHighlights ();

		if (monster_index + 1 < active_team.Count) {
			monster_index++;
		} else {
			// the active team's turn is over. we'll change it
			if (active_team == team1) {
				active_team = team2;
			} else {
				active_team = team1;
			}
			monster_index = 0;
		}
	}
		

	// Temporarily create monsters
	public void SetupMonsters() {
		// set up team 1
		team1.Add(CreateMonster (0, 2, "BlueEyes"));
		team1.Add(CreateMonster (0, 4, "RedEyes"));

		// set up team 2
		team2.Add(CreateMonster (8, 1, "DarkMag"));
		team2.Add(CreateMonster (8, 4, "DarkMagGirl"));

		// set up the active team
		active_team = team1;
	}

	public Monster CreateMonster(int i, int j, string monster_name="monst") {
		Tile startTile = map [i][j];

		Monster monster = ((GameObject)Instantiate( MonsterPrefab, new Vector3(startTile.transform.position.x, 1, startTile.transform.position.z), Quaternion.Euler(new Vector3()))).GetComponent<Monster>();
		monster.currentTile = startTile;
		monster.map = map;
		monster.monster_name = monster_name;
		return monster;
	}
}
