using Midim.Universal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Midim.Management {

	public class GameManager : MonoBehaviour {

		// Singleton
		public static GameManager instance;

		[Header("Variables and Assignables")]
		[SerializeField] private GameObject overUI;
		public GameObject compUI;


		private void Awake() {
			// Setting instance for singleton
			instance = this;

			// Cursor should be locked and not be visible by default
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void Update() {
			QuickRestart();

			if (Input.GetKeyDown(Keybinds.instance.restartGameInstantlyUI) && overUI.activeInHierarchy) {
				RestartSceneUI();
			}

			if (Input.GetKeyDown(Keybinds.instance.proceedTonNextLevel) && compUI.activeInHierarchy) {
				Debug.Log("Loading Next Level..."); // Replace this with a loading bar later on
			}
		}

		public void GameOver () {
			overUI.SetActive(true);

			// Cursor should be visible and not locked during game over event
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public void LevelComplete() {
			compUI.SetActive(true);
			
			// Cursor should be visible and not locked during level complete event
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		public void RestartSceneUI () {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		public void ProceedToNextLevel() {
			// Again.. replace this with a loading screen call after adding one into the game
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		private void QuickRestart () {
			if (Input.GetKeyDown(Keybinds.instance.quickRestart))
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}

}
