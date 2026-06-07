using UnityEngine;

namespace UMA.Examples
{
	[AddComponentMenu("Camera-Control/Simple Scene Walker")]
	public class SceneWalker : MonoBehaviour
	{
		public bool flyMode;

		public bool strafeMode;

		public float forwardSpeed;

		public float runMultiplier;

		public float mouseSpeed;

		public float sensitivityX;

		public float sensitivityY;

		public float keyRotationSpeed;

		public float yMinLimit;

		public float yMaxLimit;

		private Vector3 rotation;

		private Quaternion originalRotation;

		private void Update()
		{
		}

		private void ChangePosition(float Speed)
		{
		}

		private void StrafePosition(float Speed)
		{
		}

		private void Start()
		{
		}

		public static float ClampAngle(float angle)
		{
			return 0f;
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}
	}
}
