using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour 
{
	private ShootLaser shootLaser;
	public bool canShoot;

	//Add this object to enemiesSpawned List
	void Start () 
	{
		GameManager.instance.enemiesSpawned.Add (this.gameObject);
		shootLaser = GetComponent<ShootLaser> ();
	}

	// Remove this object from enemiesSpawned List
	void OnDestroy()
	{
		GameManager.instance.enemiesSpawned.Remove (this.gameObject);
	}

	// Make AI shoot a laser
	void Update () 
	{
		if (canShoot == true) 
		{
			shootLaser.FireLaser ();
		}
	}
}
