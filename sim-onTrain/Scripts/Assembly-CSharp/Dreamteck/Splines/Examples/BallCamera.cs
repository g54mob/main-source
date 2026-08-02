using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class BallCamera : MonoBehaviour
	{
		public Rigidbody rb;

		public SplineProjector projector;

		public float positionSpeed = 10f;

		public Vector3 offset = Vector3.zero;

		public float rotationSpeed = 0.5f;

		public Vector3 rotationOffset = Vector3.zero;

		private Transform trs;

		private void Awake()
		{
			trs = base.transform;
			trs.position = rb.position + projector.result.rotation * offset;
			trs.rotation = projector.result.rotation * Quaternion.Euler(rotationOffset);
		}

		private void FixedUpdate()
		{
			Vector3 b = rb.position + trs.rotation * offset;
			Quaternion b2 = projector.result.rotation * Quaternion.Euler(rotationOffset);
			trs.position = Vector3.Lerp(trs.position, b, Time.deltaTime * positionSpeed);
			trs.rotation = Quaternion.Slerp(trs.rotation, b2, Time.deltaTime * rotationSpeed);
		}
	}
}
