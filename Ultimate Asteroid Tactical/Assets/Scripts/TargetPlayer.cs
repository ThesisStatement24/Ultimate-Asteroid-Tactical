using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour 
{
	public float enemyRotationSpeed;
	private Transform player;
	public bool tracking;

	// set target to player when this component is created
	void Start () 
	{
		if (GameManager.instance.spawnedPlayer)
		{
			player = GameManager.instance.spawnedPlayer.transform as Transform;
		}
		if (player) 
		{
			TargetInstantly ();
		}
	}
	
	// keep searching for that target every frame
	void Update () 
	{
		if ((tracking == true) && (player))
		{
			TargetDelayed ();
		}
	}

	// Target player instantly on spawn, called from start
	void TargetInstantly()
	{
		Vector3 direction = player.position - transform.position;
		direction.Normalize ();
		float zAngle = (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90);
		transform.rotation = Quaternion.Euler (0, 0, zAngle);
	}

	// Target player on every frame
	void TargetDelayed()
	{
		Vector3 direction = player.position - transform.position;
		direction.Normalize ();
		float zAngle = (Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90);
		Quaternion targetLocation = Quaternion.Euler (0, 0, zAngle);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, targetLocation, enemyRotationSpeed * Time.deltaTime);
	}
}
