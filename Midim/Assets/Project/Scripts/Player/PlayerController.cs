using UnityEngine;
using Midim.Universal;
using Midim.Management;

namespace Midim.Player {

	public class PlayerController : MonoBehaviour {

		[Header("Movement")]
		[SerializeField] private float strafeSpeed;
		public float forwardForce;
		
		private Rigidbody rb;

		[Header("Movement/Speed-Acceleration")]
		[SerializeField] private float peakSpeed;
		[SerializeField, Range(0.1f, 3f)] private float accelerationSpeed;

		[Header("Game/Fail")]
		[SerializeField] private float fallHeightToFail; // If the rigidbody's position goes below a certain amount, then what amount should that be to fail the game.

		[Header("Other")] 
		[SerializeField] private GameObject compUI;
		
		private void Awake() {
			rb = GetComponent<Rigidbody>();
		}

		private void FixedUpdate() {
			HandleMovement();
			HandleFall();
		}

		private void HandleFall () {
			if (rb.position.y < fallHeightToFail && !compUI.activeInHierarchy) {
				GameManager.instance.GameOver(); // If rb.position goes below fallHeightToFail, then we end the game
			}
		}

		private void HandleMovement () {

			float horizontal = Input.GetAxisRaw("Horizontal") * strafeSpeed;

			// Horizontal Movement
			rb.AddForce(horizontal * Time.deltaTime, 0f, 0f);

			// Push Forward
			rb.AddForce(0, 0, forwardForce * Time.deltaTime);

			// Gradually increase forwardForce overtime and stop after the speed has reached its limit
			if (forwardForce != peakSpeed)
				forwardForce += accelerationSpeed;
		}

		private void OnCollisionEnter(Collision col) {

			if (col.gameObject.CompareTag("Obstacle")) {
				GameManager.instance.GameOver();
				// Freeze Position of the Rigidbody so as to not deviate the position of the player after colliding with an obstacle or falling off
				rb.constraints = RigidbodyConstraints.FreezePosition;
			}

		}

		private void OnTriggerEnter(Collider col) {
			if (col.CompareTag("End Trigger")) {
				GameManager.instance.LevelComplete();
			}
		}

	}

}