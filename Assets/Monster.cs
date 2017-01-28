using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public int movement = 2;
	public int range = 1;
	public float attack = 2.0f;
	public float defense = 2.0f;
	public float health = 10.0f;

	public Tile currentTile;
	public List<List<Tile>> map;

	public string monster_name;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI() {
		// displays health
		// should make it a bar
		Vector3 location = Camera.main.WorldToScreenPoint (transform.position) + Vector3.up * 35;
		GUI.TextArea(new Rect(location.x, Screen.height - location.y, 30, 20), health.ToString());
	}

	// performs djikstras and highlights the appropriate paths
	void HighlightAttackPath() {
		List<Tile> movementPath = Path.GetTilePath(range, currentTile, map);

		for (int i = 0; i < movementPath.Count; i++) {
			// for some reason, this doesnt work.
			movementPath [i].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.red);
			Debug.Log ("i:" + movementPath [i].tilePosition.x + ", y:" + movementPath [i].tilePosition.y);
		}
	}

	void HighlightMovePath() {
		List<Tile> movementPath = Path.GetTilePath(movement, currentTile, map);

		for (int i = 0; i < movementPath.Count; i++) {
			// for some reason, this doesnt work.
			movementPath [i].GetComponent<Renderer> ().material.SetColor ("_EmissionColor", Color.green);
			Debug.Log ("i:" + movementPath [i].tilePosition.x + ", y:" + movementPath [i].tilePosition.y);
		}
	}

	// GUI for monster's during their turn
	public void TurnOnGUI() {
		float buttonHeight = 50;
		float buttonWidth = 150;

		// move button

		Rect nameBox = new Rect(0, Screen.height - buttonHeight * 4, buttonWidth, buttonHeight/2);
		Rect attackButton = new Rect (0, Screen.height - buttonHeight * 3, buttonWidth, buttonHeight);
		Rect moveButton = new Rect (0, Screen.height - buttonHeight * 2, buttonWidth, buttonHeight);
		Rect endButton = new Rect (0, Screen.height - buttonHeight * 1, buttonWidth, buttonHeight);

		GUI.Box (nameBox, monster_name);

		if (GUI.Button (attackButton, "Attack")) {
			// highlight the tiles
			Debug.Log("Attack button clicked");
			HighlightAttackPath ();
		}
		if (GUI.Button (moveButton, "Move")) {
			// highlight the tiles
			Debug.Log("Move button clicked");
			HighlightMovePath ();
		}
		if (GUI.Button (endButton, "End")) {
			// highlight the tiles
			Debug.Log("Move button clicked");
			GameManager.instance.NextTurn ();
		}
	}
}
