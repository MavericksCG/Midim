using Midim.Player;
using UnityEngine;
using TMPro;

namespace Midim.Debugging {

	public class SpeedCounter : MonoBehaviour {

		[SerializeField] private TextMeshProUGUI speedText;
		private PlayerController pc;

		private void Start() {
			pc = FindObjectOfType<PlayerController>();
		}

		private void Update() {
			speedText.text = "Speed : " + pc.forwardForce.ToString();
		}
	}

}
