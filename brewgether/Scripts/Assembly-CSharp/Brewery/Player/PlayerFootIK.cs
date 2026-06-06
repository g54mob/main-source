using Brewery.Vehicle;
using UnityEngine;

namespace Brewery.Player
{
	public class PlayerFootIK : MonoBehaviour
	{
		[Header("Foot IK Settings")]
		[Range(0f, 1f)]
		[SerializeField]
		private float footIkWeight;

		[Tooltip("How far above the foot to start the raycast")]
		[SerializeField]
		private float raycastOriginHeight;

		[Tooltip("How far below the foot to raycast")]
		[SerializeField]
		private float raycastDistance;

		[Tooltip("Layer mask for ground detection")]
		[SerializeField]
		private LayerMask groundLayerMask;

		[Header("Movement Detection")]
		[Tooltip("MoveSpeed at or above this value = fully blended out (no IK)")]
		[SerializeField]
		private float moveSpeedFullOff;

		[Tooltip("MoveSpeed at or below this value = fully blended in (full IK)")]
		[SerializeField]
		private float moveSpeedFullOn;

		[Header("Blend Smoothing")]
		[Tooltip("How fast the IK weight blends toward its target (lower = smoother)")]
		[SerializeField]
		private float weightBlendSpeed;

		[Header("Foot Smoothing")]
		[Tooltip("How fast foot Y delta blends to target (higher = snappier)")]
		[SerializeField]
		private float footDeltaSmoothSpeed;

		[Tooltip("How fast foot rotations blend to target")]
		[SerializeField]
		private float footRotationSmoothSpeed;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugGizmos;

		[SerializeField]
		private float debugCalibratedAnkleHeight;

		private Animator animator;

		private static readonly int MoveSpeedHash;

		private MopedRiderIK mopedRiderIK;

		private MopedPassengerIK mopedPassengerIK;

		private VehicleDriverIK vehicleDriverIK;

		private float ankleHeight;

		private bool calibrated;

		private int calibrationFrameDelay;

		private float currentBlendWeight;

		private float smoothedLeftDeltaY;

		private float smoothedRightDeltaY;

		private Quaternion smoothedLeftFootRot;

		private Quaternion smoothedRightFootRot;

		private bool leftFootHit;

		private bool rightFootHit;

		private RaycastHit leftHit;

		private RaycastHit rightHit;

		private void OnEnable()
		{
		}

		private void CacheVehicleIK()
		{
		}

		private bool IsVehicleIKActive()
		{
			return false;
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		private Quaternion RotateFootToSurface(Quaternion currentRotation, Vector3 surfaceNormal)
		{
			return default(Quaternion);
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
