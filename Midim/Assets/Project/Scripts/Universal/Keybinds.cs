using UnityEngine;

namespace Midim.Universal {

	public class Keybinds : MonoBehaviour {

		#region Singleton

		public static Keybinds instance;

		private void Awake() {
			instance = this;
		}

		#endregion

		[Header("Keybinds")]
		// Player Movement
		public KeyCode strafeLeft = KeyCode.A;
		public KeyCode strafeRight = KeyCode.D;

		// Management
		public KeyCode quickRestart = KeyCode.R;

		// UI
		public KeyCode restartGameInstantlyUI = KeyCode.Mouse0;
		public KeyCode proceedTonNextLevel = KeyCode.Space;

	}

}
