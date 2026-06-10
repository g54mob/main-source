using UnityEngine;

namespace BrainFailProductions.PolyFewRuntime
{
	public class FlyCamera : MonoBehaviour
	{
		public Transform target;

		public float distance;

		public float xSpeed;

		public float ySpeed;

		public float panSpeed;

		public float yMinLimit;

		public float yMaxLimit;

		public float distanceMin;

		public float distanceMax;

		private Rigidbody rigidbody;

		private float x;

		private float y;

		public static bool deactivated;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}
	}
}
