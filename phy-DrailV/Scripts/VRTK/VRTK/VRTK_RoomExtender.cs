using System;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_RoomExtender")]
	[Obsolete("`VRTK_RoomExtender` has been replaced with `VRTK_StepMultiplier`. This script will be removed in a future version of VRTK.")]
	public class VRTK_RoomExtender : MonoBehaviour
	{
		public enum MovementFunction
		{
			Nonlinear = 0,
			LinearDirect = 1
		}

		[Tooltip("This determines the type of movement used by the extender.")]
		public MovementFunction movementFunction = MovementFunction.LinearDirect;

		[Tooltip("Enables the additional movement.")]
		public bool additionalMovementEnabled = true;

		[Tooltip("If this is checked then the touchpad needs to be pressed to enable it. If this is unchecked then it is disabled by pressing the touchpad.")]
		public bool additionalMovementEnabledOnButtonPress = true;

		[Tooltip("This is the factor by which movement at the edge of the circle is amplified. `0` is no movement of the play area. Higher values simulate a bigger play area but may be too uncomfortable.")]
		[Range(0f, 10f)]
		public float additionalMovementMultiplier = 1f;

		[Tooltip("This is the size of the circle in which the play area is not moved and everything is normal. If it is to low it becomes uncomfortable when crouching.")]
		[Range(0f, 5f)]
		public float headZoneRadius = 0.25f;

		[Tooltip("This transform visualises the circle around the user where the play area is not moved. In the demo scene this is a cylinder at floor level. Remember to turn of collisions.")]
		public Transform debugTransform;

		[HideInInspector]
		public Vector3 relativeMovementOfCameraRig;

		protected Transform movementTransform;

		protected Transform playArea;

		protected Vector3 headCirclePosition;

		protected Vector3 lastPosition;

		protected Vector3 lastMovement;

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			movementTransform = VRTK_DeviceFinder.HeadsetTransform();
			if (movementTransform == null)
			{
				VRTK_Logger.Warn(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_SCENE, "VRTK_RoomExtender", "Headset Transform"));
			}
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			additionalMovementEnabled = !additionalMovementEnabledOnButtonPress;
			if (debugTransform != null)
			{
				debugTransform.localScale = new Vector3(headZoneRadius * 2f, 0.01f, headZoneRadius * 2f);
			}
			MoveHeadCircleNonLinearDrift();
			lastPosition = movementTransform.localPosition;
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			switch (movementFunction)
			{
			case MovementFunction.Nonlinear:
				MoveHeadCircleNonLinearDrift();
				break;
			case MovementFunction.LinearDirect:
				MoveHeadCircle();
				break;
			}
		}

		protected virtual void Move(Vector3 movement)
		{
			headCirclePosition += movement;
			if (debugTransform != null)
			{
				debugTransform.localPosition = new Vector3(headCirclePosition.x, debugTransform.localPosition.y, headCirclePosition.z);
			}
			if (additionalMovementEnabled)
			{
				playArea.localPosition += movement * additionalMovementMultiplier;
				relativeMovementOfCameraRig += movement * additionalMovementMultiplier;
			}
		}

		protected virtual void MoveHeadCircle()
		{
			Vector3 vector = new Vector3(movementTransform.localPosition.x - headCirclePosition.x, 0f, movementTransform.localPosition.z - headCirclePosition.z);
			UpdateLastMovement();
			if (vector.sqrMagnitude > headZoneRadius * headZoneRadius && lastMovement != Vector3.zero)
			{
				Move(lastMovement);
			}
		}

		protected virtual void MoveHeadCircleNonLinearDrift()
		{
			Vector3 vector = new Vector3(movementTransform.localPosition.x - headCirclePosition.x, 0f, movementTransform.localPosition.z - headCirclePosition.z);
			if (vector.sqrMagnitude > headZoneRadius * headZoneRadius)
			{
				Vector3 movement = vector.normalized * (vector.magnitude - headZoneRadius);
				Move(movement);
			}
		}

		protected virtual void UpdateLastMovement()
		{
			lastMovement = movementTransform.localPosition - lastPosition;
			lastMovement.y = 0f;
			lastPosition = movementTransform.localPosition;
		}
	}
}
