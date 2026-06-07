using UnityEngine;

namespace Dustyroom
{
	public class OrbitMotion : MonoBehaviour
	{
		public enum TargetMode
		{
			Transform = 0,
			Position = 1
		}

		public TargetMode targetMode;

		public Transform targetTransform;

		public bool followTargetTransform;

		public Vector3 targetOffset;

		public Vector3 targetPosition;

		[Space]
		public float distanceHorizontal;

		public float distanceVertical;

		public float xSpeed;

		public float ySpeed;

		public float damping;

		[Space]
		public bool clampAngle;

		public float yMinLimit;

		public float yMaxLimit;

		[Space]
		public bool allowZoom;

		public float distanceMin;

		public float distanceMax;

		private float _x;

		private float _y;

		[Space]
		public bool autoMovement;

		public float autoSpeedX;

		public float autoSpeedY;

		public float autoSpeedDistance;

		[Space]
		public bool interactive;

		private float _lastMoveTime;

		[HideInInspector]
		public float timeSinceLastMove;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}
	}
}
