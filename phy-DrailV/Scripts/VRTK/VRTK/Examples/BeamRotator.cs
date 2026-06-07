using UnityEngine;

namespace VRTK.Examples
{
	public class BeamRotator : MonoBehaviour
	{
		[Tooltip("Amount of degrees to rotate around the rotation axis per second.")]
		public float degreesPerSecond = 60f;

		[Tooltip("The rotation axis to rotate the object around.")]
		public Vector3 rotationAxis = Vector3.up;

		protected virtual void OnEnable()
		{
			rotationAxis.Normalize();
		}

		protected virtual void Update()
		{
			base.transform.Rotate(rotationAxis, degreesPerSecond * Time.deltaTime);
		}
	}
}
