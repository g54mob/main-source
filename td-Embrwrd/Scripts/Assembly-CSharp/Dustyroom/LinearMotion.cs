using UnityEngine;

namespace Dustyroom
{
	public class LinearMotion : MonoBehaviour
	{
		public enum TranslationMode
		{
			Off = 0,
			XAxis = 1,
			YAxis = 2,
			ZAxis = 3,
			Vector = 4
		}

		public enum RotationMode
		{
			Off = 0,
			XAxis = 1,
			YAxis = 2,
			ZAxis = 3,
			Vector = 4
		}

		public TranslationMode translationMode;

		public Vector3 translationVector;

		public float translationSpeed;

		public RotationMode rotationMode;

		public Vector3 rotationAxis;

		public float rotationSpeed;

		public bool useLocalCoordinate;

		public float translationAcceleration;

		public float rotationAcceleration;

		private Vector3 TranslationVector => default(Vector3);

		private Vector3 RotationVector => default(Vector3);

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
