using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpwan;
	
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;

	void Update()
	{
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpwan.position, shotSpwan.rotation);
			//AudioSource[] audios = GetComponents<AudioSource>();
			//audios[0].Play();
		}
		
	}
}
