using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	// If an object collides with the level ignore it, and if objects colliding share a tag ignore them too, otherwise destroy the object that is colliding
	void OnTriggerEnter2D(Collider2D other)
	{
		if ((other.gameObject.tag != "Level") && (other.gameObject.tag != this.tag)) 
		{
			Destroy (other.gameObject);
		}
	}
}
