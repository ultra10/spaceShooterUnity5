using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpwan;
	
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
}
