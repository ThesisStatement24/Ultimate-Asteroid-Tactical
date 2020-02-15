using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	// Static for singleton control pattern
	public static GameManager instance;

	// Lists for spawning
	public GameObject[] enemiesList;
	public Transform[] spawnPoints;
	public List<GameObject> enemiesSpawned;
	public int maxEnemies;

	// Player Class Variables
	public GameObject player;
	public GameObject spawnedPlayer;
	public int playerLives;

	// Ensures there is only 1 of these
	void Awake ()
	{
		if (instance == null) 
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		} 
		else 
		{
			Destroy (this.gameObject);
		}
	}

	void Update () 
	{
		SpawnEnemy();
		SpawnPlayer();
		EndGame ();
	}

	// This will spawn enemies
	void SpawnEnemy()
	{
		// Spawn only 3 enemies
		if (enemiesSpawned.Count < maxEnemies)
		{
			int randomSpawnPoint = Random.Range (0, spawnPoints.Length);
			int randomNum = Random.Range(0,9);
			Vector3 spawnNearby = Random.insideUnitCircle;
			Vector3 spawnLocation = spawnPoints[randomSpawnPoint].position + spawnNearby;
			Instantiate (enemiesList[randomNum], spawnLocation , spawnPoints[randomSpawnPoint].rotation); // Need to use Random.insideUnitCircle
		}
	}

	// This will Spawn Player
	void SpawnPlayer()
	{
		if (spawnedPlayer == null && playerLives > 0)
		{
			spawnedPlayer = Instantiate (player);
		}
	}

	// Ends the Game
	void EndGame()
	{
		if (playerLives <= 0) 
		{
			Application.Quit ();
			Debug.Log("Exit");
		}
	}
}