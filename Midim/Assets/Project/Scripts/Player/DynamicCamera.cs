using UnityEngine;
using Cinemachine;

namespace Midim.Player {

    public class DynamicCamera : MonoBehaviour {
        
        [Header("Reference(s)")]
        [SerializeField] private CinemachineVirtualCamera cam;
        private PlayerController cont;

        [Header("FOVs")]
        [SerializeField] private float normalFOV;
        [SerializeField] private float midFOV;
        [SerializeField] private float peakFOV;

        [Header("Other")]
        [SerializeField] private float smoothing;
        private float curFOV;


		private void Start() {
            // Getting Player Controller and current camera FOV
            cont = GetComponent<PlayerController>();
            curFOV = cam.m_Lens.FieldOfView;
		}

		private void Update() {

		    if (cont.forwardForce <= 1199)
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, normalFOV, smoothing);
            else
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, curFOV, smoothing);

            if (cont.forwardForce >= 1200)
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, midFOV, smoothing);
            else
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, curFOV, smoothing);

            if (cont.forwardForce >= 2101)
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, peakFOV, smoothing);
            else
                cam.m_Lens.FieldOfView = Mathf.Lerp(cam.m_Lens.FieldOfView, curFOV, smoothing);

        }

    }

}
