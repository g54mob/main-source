using UnityEngine;

namespace Borodar.FarlandSkies.Core.Demo
{
	public class CameraOrbitController : MonoBehaviour
	{
		public Transform Target;

		public float Distance;

		public float DistanceMin;

		public float DistanceMax;

		public Vector3 Speed;

		public Vector2 VerticalRotationLimit;

		private Vector2 _angles;

		private bool _isPointerOverGui;

		protected void Awake()
		{
		}

		protected void LateUpdate()
		{
		}

		private static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}
	}
}
