using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundaries : MonoBehaviour
{

	
	// Use a trigger box as level bounds, if anything with tags player or enemy leave then destroy them
	void OnTriggerExit2D (Collider2D col)
	{
		if(col.gameObject.tag == "Player")
		{
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag == "Enemy") 
		{
			Destroy(col.gameObject);
		}
	}
}
