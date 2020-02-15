using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float playerMoveSpeed = 5;
	public float playerRotationSpeed = 100;
	public Vector2 playerStartPosition;
	private ShootLaser shootLaser;

	void Start () 
	{
		// When object is constructed set it's position to the designer defined startPosition
		transform.position = playerStartPosition;
		shootLaser = GetComponent<ShootLaser> ();
	}

	void Update () 
	{
		moveForward ();
		rotate ();
		fireLaser ();
	}

	// Remove 1 life from GameManager and destroy all spawned enemies
	void OnDestroy()
	{
		GameManager.instance.playerLives -= 1;
		Destroy (GameManager.instance.enemiesSpawned[0]);
		Destroy (GameManager.instance.enemiesSpawned[1]);
		Destroy (GameManager.instance.enemiesSpawned[2]);
	}

	// This controls player forward movement
	void moveForward()
	{
		transform.Translate (0, Time.deltaTime * playerMoveSpeed * Input.GetAxis ("Vertical"), 0);
	}

	// This controls player rotation
	void rotate()
	{
		transform.Rotate (0, 0, Time.deltaTime * playerRotationSpeed * Input.GetAxis ("Horizontal"), 0);
	}

	// We will fire a laser here
	void fireLaser()
	{
		if (Input.GetButton ("Fire1")) 
		{
			shootLaser.FireLaser ();
		}
	}
}

