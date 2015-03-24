using UnityEngine;
using System.Collections;

public class DestroyByEnemyShot : MonoBehaviour {
	
	public GameObject playerExplosion;
	private GameController gc; // game Controller handler
	
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

		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gc.GameOver();
		}
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
