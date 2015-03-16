using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float speed;

	void Start()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		
		r.velocity = transform.forward * speed;
	}
}
