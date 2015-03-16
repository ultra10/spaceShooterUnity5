using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerController : MonoBehaviour {

	public float Speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpwan;

	public float fireRate = 0.5F;
	private float nextFire = 0.0F;

	void Update()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpwan.position, shotSpwan.rotation);
			GetComponent<AudioSource>().Play ();
		}

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); // do pooruszania statkiem

		Rigidbody r = GetComponent<Rigidbody>();

		r.velocity = movement * Speed;
		r.position = new Vector3 (
			Mathf.Clamp(r.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(r.position.z, boundary.zMin, boundary.zMax)
		);

		r.rotation = Quaternion.Euler (0.0f, 0.0f, r.velocity.x * -tilt);
	}
}
