using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class AddForceAlongPath : MonoBehaviour
	{
		public float force = 10f;

		private Rigidbody rb;

		private SplineProjector projector;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			projector = GetComponent<SplineProjector>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rb.AddForce(projector.result.forward * force, ForceMode.Impulse);
			}
		}
	}
}
