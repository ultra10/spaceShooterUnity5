using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gc;

	void Start(){
		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");
		if (gameControllerObj != null) {
			gc = gameControllerObj.GetComponent<GameController>();
		}
		if (gc == null) {
			Debug.Log("Nie działa :(");
		}
	}

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
		}
		gc.addScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
