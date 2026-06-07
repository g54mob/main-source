using Brewery.DrinkingSystem;
using Ezereal;
using UnityEngine;

namespace Brewery.Vehicle
{
	public class VehicleDriverIK : MonoBehaviour
	{
		private enum GearShiftPhase
		{
			None = 0,
			MovingToShifter = 1,
			Holding = 2,
			ReturningToWheel = 3
		}

		private enum RadioReachPhase
		{
			None = 0,
			MovingToRadio = 1,
			Holding = 2,
			ReturningToWheel = 3
		}

		private enum HandbrakeGrabPhase
		{
			None = 0,
			MovingToHandbrake = 1,
			Holding = 2,
			ReturningToWheel = 3
		}

		[Header("IK Weights")]
		[Range(0f, 1f)]
		[SerializeField]
		private float handIkWeight;

		[Range(0f, 1f)]
		[SerializeField]
		private float footIkWeight;

		[SerializeField]
		private float ikBlendSpeed;

		[Header("Gear Shift Animation")]
		[Tooltip("How fast the hand moves to/from the gear shifter (seconds)")]
		[SerializeField]
		private float gearShiftMoveTime;

		[Tooltip("How long the hand stays on the gear shifter (seconds)")]
		[SerializeField]
		private float gearShiftHoldTime;

		[Header("Radio Reach Animation")]
		[Tooltip("How fast the hand moves to/from the radio (seconds)")]
		[SerializeField]
		private float radioReachMoveTime;

		[Tooltip("How long the hand stays on the radio (seconds)")]
		[SerializeField]
		private float radioReachHoldTime;

		[Header("Handbrake Grab Animation")]
		[Tooltip("How fast the hand moves to/from the handbrake (seconds)")]
		[SerializeField]
		private float handbrakeGrabMoveTime;

		private Animator animator;

		private EzerealCarController carController;

		private Transform leftHandTarget;

		private Transform rightHandTarget;

		private Transform gearShifterTarget;

		private Transform radioTarget;

		private Transform handbrakeTarget;

		private Transform leftFootTarget;

		private Transform rightFootTarget;

		private float currentHandWeight;

		private float currentFootWeight;

		private DrinkingController drinkingController;

		private bool savedApplyRootMotion;

		private bool rootMotionSaved;

		private bool isActiveDriver;

		private bool isShiftingGear;

		private float gearShiftTimer;

		private GearShiftPhase gearShiftPhase;

		private float gearShiftBlend;

		private bool isReachingRadio;

		private float radioReachTimer;

		private RadioReachPhase radioReachPhase;

		private float radioReachBlend;

		private bool isGrabbingHandbrake;

		private bool handbrakeHeld;

		private float handbrakeGrabTimer;

		private HandbrakeGrabPhase handbrakeGrabPhase;

		private float handbrakeGrabBlend;

		public bool IsActive => false;

		public void Initialize(EzerealCarController controller, Transform leftHand, Transform rightHand, Transform gearShifter = null, Transform radio = null, Transform handbrake = null, Transform leftFoot = null, Transform rightFoot = null)
		{
		}

		public void ClearTargets()
		{
		}

		public void TriggerGearShift()
		{
		}

		public void TriggerRadioReach()
		{
		}

		public void SetHandbrakeGrab(bool engaged)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void UpdateGearShiftAnimation()
		{
		}

		private void UpdateRadioReachAnimation()
		{
		}

		private void UpdateHandbrakeGrabAnimation()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		private void ApplyFootIK()
		{
		}

		private void ApplyHandIK()
		{
		}

		private float GetHandWeightScale(bool isLeftHand)
		{
			return 0f;
		}
	}
}
