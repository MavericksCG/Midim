using Midim.Management;
using UnityEngine;
using TMPro;

namespace Midim.UI {

	public class CountdownToProceed : MonoBehaviour {

		[Header("Assignables")]
		[SerializeField] private GameObject compUI;
		[SerializeField] private float startTime;
		private float curTime;

		[SerializeField] private TextMeshProUGUI countdownText;


		private void Start() {
			curTime = startTime;
		}

		private void Update() {
			if (compUI.activeInHierarchy) {
				curTime -= 1 * Time.deltaTime;
				countdownText.text = curTime.ToString("0");
			}

			if (curTime <= 0) {
				curTime = 0;
				GameManager.instance.ProceedToNextLevel();
			}
		}

	}

}
