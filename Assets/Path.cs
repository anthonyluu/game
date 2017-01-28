using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path {
	public static List<Tile> GetTilePath(int max_distance, Tile start_point, List<List<Tile>> map) {
		// TODO: we want a parameter where we have a list of occupied tiles already
		// We could probably make a list from the "team1" and "team2" in GameManager.
		// Djikstras with a max distance

		// map should be at least length of 1
		int max_i = map.Count;
		int max_j = map [0].Count;

		Queue<Tile> open = new Queue<Tile>();
		List<Tile> closed = new List<Tile> ();
		open.Enqueue (start_point);

		int count = 0;

		while (open.Count > 0) {
			count += 1;
			Tile current = open.Dequeue();
//			Debug.Log ("Iteration:"+ count + ", Curr.x:" + current.tilePosition.x + ", Curr.y" + current.tilePosition.y);

			// need to see if this tile is within the max distance
			float distance = Vector2.Distance(current.tilePosition, start_point.tilePosition);
//			Debug.Log ("Iteration:" + count + ", distance:" + distance);
			if (distance > (float)max_distance) {
				// this is not within the max range, so we dont want to add the neighbours
				continue;
			} else {
				if (current.tilePosition.x >= 1) {
					// add the north neighbour
					Tile north = map[(int) current.tilePosition.x - 1][(int) current.tilePosition.y];
					if (!closed.Contains(north)) {
						open.Enqueue (north);
					}
				}
				if (current.tilePosition.x < max_i - 1) {
					// add the south neighbour
					Tile south = map[(int) current.tilePosition.x + 1][(int) current.tilePosition.y];
					if (!closed.Contains(south)) {
						open.Enqueue (south);
					}
				}
				if (current.tilePosition.y >= 1) {
					// add the east neighbour
					Tile east = map[(int) current.tilePosition.x][(int) current.tilePosition.y - 1];
					if (!closed.Contains(east)) {
						open.Enqueue (east);
					}
				}
				if (current.tilePosition.y < max_j - 1) {
					// add the west neighbour
					Tile west = map[(int) current.tilePosition.x][(int) current.tilePosition.y + 1];
					if (!closed.Contains(west)) {
						open.Enqueue (west);
					}
				}

				closed.Add (current);
			}
				
		}
		return closed;

	}

}
