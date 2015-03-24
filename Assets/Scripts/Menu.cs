using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private bool pauseGame;

	public GameObject menuHandler;

	public void ExitGame()
	{
		Debug.Log ("NARA ZIOM!!!");
		Application.Quit ();
	}

	public void RestartGame()
	{
		Application.LoadLevel (Application.loadedLevel);
		ContinueGame ();
	}

	public void ContinueGame()
	{
		PauseGame ();
	}

	public void PauseGame()
	{
		pauseGame = !pauseGame;
		menuHandler.SetActive(pauseGame);
		if (pauseGame) { // true, pause game
			Time.timeScale = 0.0f; 
		} else {
			Time.timeScale = 1.0f; 
		}

	}
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			PauseGame();
		}
	}

	void Start()
	{
		pauseGame = false;
		menuHandler.SetActive(false);
	}

}
