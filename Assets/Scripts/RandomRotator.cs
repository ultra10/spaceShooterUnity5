using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float tumble;

	void Start()
	{
		Rigidbody r = GetComponent<Rigidbody>();
		r.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
