using UnityEngine;
using Cinemachine;
using TMPro;

namespace Midim.Debugging {

	public class FOVCounter : MonoBehaviour {

		[Header("Reference(s)")]
		[SerializeField] private CinemachineVirtualCamera vcam;
		[SerializeField] private TextMeshProUGUI fovText;

		private void Update() {
			fovText.text = "Camera FOV : " + vcam.m_Lens.FieldOfView.ToString();
		}

	}

}
