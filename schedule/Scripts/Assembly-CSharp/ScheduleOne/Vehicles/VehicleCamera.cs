using UnityEngine;

namespace ScheduleOne.Vehicles
{
	public class VehicleCamera : MonoBehaviour
	{
		private const float followDelta = 10f;

		private const float yMinLimit = -20f;

		private const float manualOverrideTime = 0.01f;

		private const float manualOverrideReturnTime = 0.6f;

		private const float xSpeed = 60f;

		private const float ySpeed = 40f;

		private const float yMaxLimit = 89f;

		[Header("References")]
		public LandVehicle vehicle;

		[SerializeField]
		[Header("Camera Settings")]
		protected Transform cameraOrigin;

		[SerializeField]
		protected float lateralOffset;

		[SerializeField]
		protected float verticalOffset;

		protected bool cameraReversed;

		protected float timeSinceCameraManuallyAdjusted;

		protected float orbitDistance;

		protected Vector3 lastFrameCameraOffset;

		protected Vector3 lastManualOffset;

		private Transform targetTransform;

		private Transform cameraDolly;

		private float x;

		private float y;

		private float mouseIdleCooldown;

		private float mouseIdleTimer;

		private Transform cam => null;

		private bool NeedSecondaryClick => false;

		protected virtual void Start()
		{
		}

		private void Subscribe()
		{
		}

		protected virtual void Update()
		{
		}

		private void PlayerEnteredVehicle(LandVehicle veh)
		{
		}

		private void CheckForClick()
		{
		}

		private void CheckForMouseMovement()
		{
		}

		protected virtual void LateUpdate()
		{
		}

		private void HandleNonSecondaryClickCameraMovement()
		{
		}

		private void HandleSecondaryClickCameraMovement()
		{
		}

		private void ForceCameraReturn()
		{
		}

		private static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}

		private Vector3 GetTargetCameraPosition()
		{
			return default(Vector3);
		}

		private Vector3 LimitCameraPosition(Vector3 targetPosition)
		{
			return default(Vector3);
		}
	}
}
