using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
	public struct RotateTransformGrabAttachEventArgs
	{
		public GameObject interactingObject;

		public float currentAngle;

		public float normalizedAngle;

		public Vector3 rotationSpeed;
	}
}
