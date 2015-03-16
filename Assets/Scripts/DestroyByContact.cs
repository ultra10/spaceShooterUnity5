using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	/** 
	 * @param other wzkazuje na obiekt który wywołuje ten skrypt 
	 */
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		Instantiate (explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			AudioSource[] audios = other.GetComponents<AudioSource>();
			Debug.Log (audios.Length);
			audios[1].Play();
			audios[0].Play();
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
