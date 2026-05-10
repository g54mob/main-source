using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	public class CameraFollow : MonoBehaviour
	{
		public bool shouldRotate;

		public Transform target;

		public float distance;

		public float height;

		public float heightDamping;

		public float rotationDamping;

		private float wantedRotationAngle;

		private float wantedHeight;

		private float currentRotationAngle;

		private float currentHeight;

		private Quaternion currentRotation;

		private void FixedUpdate()
		{
		}
	}
}
