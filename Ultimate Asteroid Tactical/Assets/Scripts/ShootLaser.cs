using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour 
{
	public GameObject laserBulletPrefab;
	public float laserFireRate;
	float laserCooldown = 0;

	// Instantiate a laser if cooldown is 0
	public void FireLaser()
	{
		laserCooldown -= Time.deltaTime;
		if (laserCooldown <= 0) 
		{
			laserCooldown = laserFireRate;
			Instantiate (laserBulletPrefab, transform.position, transform.rotation); // Create a new bullet
		}
	}
}
