using Midim.Management;
using UnityEngine;
using TMPro;

namespace Midim.UI {

	public class CountdownToRestart : MonoBehaviour {

		[Header("Assignables")]
		[SerializeField] private GameObject overUI;
		[SerializeField] private float startTime;
		private float curTime;

		[SerializeField] private TextMeshProUGUI countdownText;


		private void Start() {
			curTime = startTime;
		}

		private void Update() {
			if (overUI.activeInHierarchy) {
				curTime -= 1 * Time.deltaTime;
				countdownText.text = curTime.ToString("0");
			}

			if (curTime <= 0) {
				curTime = 0;
				GameManager.instance.RestartSceneUI();
			}
		}

	}

}
