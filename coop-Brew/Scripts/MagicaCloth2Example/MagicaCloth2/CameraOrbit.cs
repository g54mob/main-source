using UnityEngine;

namespace MagicaCloth2
{
	public class CameraOrbit : MonoBehaviour
	{
		public enum MoveMode
		{
			None = 0,
			UpDown = 1,
			Free = 2
		}

		[SerializeField]
		private Transform cameraTransform;

		[Header("Camera Target")]
		public Transform cameraTarget;

		public Vector3 cameraTargetPos;

		public Vector3 cameraTargetOffset;

		[Header("Now Position")]
		[SerializeField]
		private float cameraDist;

		[SerializeField]
		private float cameraPitch;

		[SerializeField]
		private float cameraYaw;

		[Header("Parameter")]
		[SerializeField]
		private float cameraDistHokanTime;

		[SerializeField]
		private float cameraAngleHokanTime;

		[SerializeField]
		private float cameraDistSpeed;

		[SerializeField]
		private float cameraDistMax;

		[SerializeField]
		private float cameraDistMin;

		[SerializeField]
		private float cameraYawSpeed;

		[SerializeField]
		private float cameraPitchSpeed;

		[SerializeField]
		private float cameraMaxAngleSpeed;

		[SerializeField]
		private float cameraPitchMax;

		[SerializeField]
		private float cameraPitchMin;

		[SerializeField]
		private MoveMode moveMode;

		[SerializeField]
		private float moveSpeed;

		[Header("Auto Rotation")]
		[SerializeField]
		private bool useAutoRotation;

		[SerializeField]
		private float autoRotationSpeed;

		private float setCameraDist;

		private float setCameraPitch;

		private float setCameraYaw;

		private float cameraDistVelocity;

		private float cameraPitchVelocity;

		private float cameraYawVelocity;

		private float offsetYaw;

		protected void Start()
		{
		}

		protected void OnEnable()
		{
		}

		protected void OnDisable()
		{
		}

		protected void LateUpdate()
		{
		}

		private void updateCamera()
		{
		}

		private void updatePitchYaw(Vector2 speed)
		{
		}

		private void updateOffset(Vector2 speed)
		{
		}

		private void updateZoom(float speed)
		{
		}

		private void OnTouchMove(int fid, Vector2 screenPos, Vector2 screenVelocity, Vector2 cmVelocity)
		{
		}

		private void OnDoubleTouchMove(int fid, Vector2 screenPos, Vector2 screenVelocity, Vector2 cmVelocity)
		{
		}

		private void OnTouchPinch(float speedscr, float speedcm)
		{
		}

		private float SpeedAdjustment()
		{
			return 0f;
		}
	}
}
