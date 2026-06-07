using UnityEngine;

namespace ScheduleOne.Weather
{
	public class BasicEnclosure : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private Vector3 _center;

		[SerializeField]
		private Vector3 _size;

		[SerializeField]
		[Header("Blend Zone Settings")]
		private bool _isBlendZone;

		[SerializeField]
		private float _backRadius;

		[SerializeField]
		private float _frontRadius;

		[SerializeField]
		private AnimationCurve _blendCurve;

		[SerializeField]
		[Header("Debug")]
		private bool _debugMode;

		[SerializeField]
		private bool _debugShowFrontAndBackSeparately;

		[SerializeField]
		private GameObject _debugObject;

		private Vector3 _debugClosestPoint;

		private Vector3 _debugOppositePoint;

		private float _debugBlendValue;

		private float _debugActiveRadius;

		public Vector3 StartPoint => default(Vector3);

		public Vector3 EndPoint => default(Vector3);

		public bool IsBlendZone => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public bool WithinEnclosure(Vector3 targetPosition)
		{
			return false;
		}

		public float GetEnclosureBlend(Vector3 targetPosition)
		{
			return 0f;
		}

		public Vector3 GetClosestPointOnZFaces(Vector3 targetPosition)
		{
			return default(Vector3);
		}

		public Vector3 GetOppositeFacePoint(Vector3 surfacePoint)
		{
			return default(Vector3);
		}

		protected Vector3 GetSize()
		{
			return default(Vector3);
		}

		protected Vector3 GetCenter()
		{
			return default(Vector3);
		}
	}
}
