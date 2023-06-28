using UnityEngine;

namespace Midim.Obstacles {

    public class Randomize : MonoBehaviour {
        
		// Rotation
        private float randomNumber;
		Quaternion randomRot;

		// Scale
		private float randomScale;


		private void Start() {
			// Setting random number
			randomNumber = Random.Range(30f, 270f);
			randomScale = Random.Range(0.5f, 2f);

			// Set Quaternion for rotations
			randomRot = Quaternion.Euler(0f, randomNumber, 0f);

			// Set Rotations to Specified Game Objects
			transform.rotation = randomRot;

			// Set Scale to Specified Game Objects
			transform.localScale = new Vector3(randomScale, randomScale, randomScale);
		}
	}

}
