using Brewery.CarryingSystem;
using Brewery.DrinkingSystem;
using Brewery.Vehicle;
using Synty.AnimationBaseLocomotion.Samples;
using UnityEngine;

namespace Brewery.Player
{
	public class PlayerHeadLookIK : MonoBehaviour
	{
		[Header("IK Weights")]
		[Tooltip("How strongly the head tracks the look target")]
		[Range(0f, 1f)]
		[SerializeField]
		private float headWeight;

		[Tooltip("How strongly the body follows the look target")]
		[Range(0f, 1f)]
		[SerializeField]
		private float bodyWeight;

		[Tooltip("How strongly the eyes track the look target")]
		[Range(0f, 1f)]
		[SerializeField]
		private float eyesWeight;

		[Tooltip("Clamp weight to limit extreme head rotations")]
		[Range(0f, 1f)]
		[SerializeField]
		private float clampWeight;

		[Header("Vehicle Overrides")]
		[Tooltip("Body weight when in a vehicle (lower to avoid torso twist)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float vehicleBodyWeight;

		[Tooltip("Head weight when in a vehicle")]
		[Range(0f, 1f)]
		[SerializeField]
		private float vehicleHeadWeight;

		[Header("Blend Settings")]
		[Tooltip("How fast the IK weight blends in/out")]
		[SerializeField]
		private float blendSpeed;

		[Tooltip("How far in front of the character to place the look target")]
		[SerializeField]
		private float lookDistance;

		[Header("Angle Limits")]
		[Tooltip("Horizontal angle beyond which head look starts fading out")]
		[SerializeField]
		private float fadeStartAngle;

		[Tooltip("Horizontal angle at which head look is fully faded out")]
		[SerializeField]
		private float fadeEndAngle;

		private Animator animator;

		private SampleCameraController cameraController;

		private SamplePlayerAnimationController animController;

		private CarryingController carryingController;

		private DrinkingController drinkingController;

		private VehicleDriverIK driverIK;

		private VehiclePassengerIK passengerIK;

		private MopedRiderIK mopedRiderIK;

		private MopedPassengerIK mopedPassengerIK;

		private PlayerHeadLookSync headLookSync;

		private float currentWeight;

		private Vector3 smoothLookTarget;

		private bool initialized;

		private Transform headBone;

		private bool isLocalPlayer;

		private void OnEnable()
		{
		}

		private void TryInitialize()
		{
		}

		private void Update()
		{
		}

		private bool ShouldApplyIK()
		{
			return false;
		}

		private bool IsInVehicle()
		{
			return false;
		}

		private bool TryGetLookDirection(out Vector3 lookForward)
		{
			lookForward = default(Vector3);
			return false;
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}
	}
}
