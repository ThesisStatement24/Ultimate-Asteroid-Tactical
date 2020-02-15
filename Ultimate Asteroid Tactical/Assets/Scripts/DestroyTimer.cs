using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour 
{
	public float lifespan;

	// Destroy object after X designer defined seconds
	void Start () 
	{
		Destroy (gameObject, lifespan);
	}
}
