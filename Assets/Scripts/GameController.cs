using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public GameObject bg;
	public Vector3 spownValues;
	public int hazardCount;
	public float spownWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	private bool pauseGame;

	void Start()
	{
		gameOver = false;
		restart = false;
		pauseGame = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		updateScore ();
		StartCoroutine(spawnWaves());

		bg.GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(1.0f, 0.1f);
	}

	private void warp()
	{
		//yield return new WaitForSeconds (2);
		float warpIn = 0.1f + Time.time * 0.3f;
		if (warpIn > 1.0f) {
			warpIn = 1.0f;
		}

		bg.GetComponent<Renderer>().sharedMaterial.mainTextureScale = new Vector2(1.0f, warpIn );
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

			if(gameOver)
			{
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}
	}

	void Update()
	{
		warp ();

		if (restart) {
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel( Application.loadedLevel);
			}
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			PauseGame();
		}
	}

	public void addScore(int newScoreValue)
	{
		score += newScoreValue;
		updateScore ();
	}

	void updateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOver = true;
		gameOverText.text = "Game Over";
	}

	public void PauseGame()
	{
		pauseGame = !pauseGame;
		if (pauseGame) { // true, pause game
			Time.timeScale = 0.0f; 
		} else {
			Time.timeScale = 1.0f; 
		}

	}
}
