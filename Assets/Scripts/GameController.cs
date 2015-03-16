using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spownValues;
	public int hazardCount;
	public float spownWait;
	public float startWait;
	public float waveWait;

	void Start()
	{
		StartCoroutine(spawnWaves());
	}

	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spownPosition = new Vector3 (Random.Range (-spownValues.x, spownValues.x), spownValues.y, spownValues.z);
				Quaternion spownRotation = Quaternion.identity;
				Instantiate (hazard, spownPosition, spownRotation);

				yield return new WaitForSeconds(spownWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
