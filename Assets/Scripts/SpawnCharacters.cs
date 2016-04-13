﻿using UnityEngine;
using System.Collections;

//Attach to Object (0,0) 
public class SpawnCharacters : MonoBehaviour {

	GameObject Friendly;
	GameObject Enemies;

	public static BaseCharacter[] friendlyList;
	public static BaseCharacter[] enemyList;

	GameObject[] friendlyPrefab = new GameObject[6];
	GameObject[] enemyPrefab = new GameObject[6];

	Vector3[] friendlyPositions = new Vector3[6];
	Vector3[] enemyPositions = new Vector3[6];


	// Use this for initialization
	void Start () {

		// Find the parents
		Friendly = GameObject.Find ("Friendly");
		Enemies = GameObject.Find ("Enemies");

		friendlyList = new BaseCharacter[6];
		enemyList = new BaseCharacter[6];

		// Get the six friendly chararcter
		friendlyList [0] = GameInformation.PlayerCharacter;
		friendlyList [1] = GameInformation.Char1;
		friendlyList [2] = GameInformation.Char2;
		friendlyList [3] = GameInformation.Char3;
		friendlyList [4] = GameInformation.Char4;
		friendlyList [5] = GameInformation.Char5;

		// Generate some enemies
		for (int i = 0; i < 6; i++) {
			enemyList [i] = CreateEnemy.returnEnemy (GameInformation.PlayerCharacter.PlayerLevel);
		}

		for (int i = 0; i < 6; i++) {

			// Generate some position
			// TODO:testing
			friendlyPositions [i] = convertPosition(12 + i, 14);
			enemyPositions [i] = convertPosition (12 + i, 25);


			// decide friendly prefab and instantiate
			if (friendlyList [i] != null) {

				if ((int)friendlyList [i].PlayerClass % 4 == 0) {
					friendlyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Warrior"), friendlyPositions[i], Quaternion.identity);
				} else if ((int)friendlyList [i].PlayerClass % 4 == 1) {
					friendlyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Mage"), friendlyPositions[i], Quaternion.identity);
				} else if ((int)friendlyList [i].PlayerClass % 4 == 2) {
					friendlyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Thief"), friendlyPositions[i], Quaternion.identity);
				} else {
					friendlyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Archer"), friendlyPositions[i], Quaternion.identity);
				}


				friendlyPrefab [i].transform.SetParent(Friendly.transform);

				//set tag (for the CharController to know which friend it is)
				friendlyPrefab[i].tag = i.ToString();
			}

			// decide enemy prefab and instantiate
			if (enemyList [i] != null && (i == 0 || friendlyList [i-1] != null)) {

				//turn around the enemies
				Quaternion rotation = Quaternion.Euler (0f, 180f, 0f);

				if ((int)enemyList [i].PlayerClass % 4 == 0) {
					enemyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Warrior"), enemyPositions[i], rotation);
				} else if ((int)enemyList [i].PlayerClass % 4 == 1) {
					enemyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Mage"), enemyPositions[i], rotation);
				} else if ((int)enemyList [i].PlayerClass % 4 == 2) {
					enemyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Thief"), enemyPositions[i], rotation);
				} else {
					enemyPrefab[i] = (GameObject)Instantiate (Resources.Load ("Archer"), enemyPositions[i], rotation);
				}

				enemyPrefab[i].transform.SetParent(Enemies.transform);

				//set tag (for the CharController to know which enemy it is)
				enemyPrefab [i].tag = i.ToString();
			}


		}
			

	}




	//helper func: map index to transform position
	public Vector3 convertPosition(int x, int y){

		Cell c = GetComponent<Cell> ();

		Vector2 temp = c.convertIndexToWorldPos (x, y);
		TileDraw.Map.Tile aTile = c.GetTileFromPointInCell (x, y);

		return new Vector3 (temp.x, aTile.GetHeight (), temp.y);
	}


}
