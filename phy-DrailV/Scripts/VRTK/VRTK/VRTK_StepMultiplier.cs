using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_StepMultiplier")]
	public class VRTK_StepMultiplier : MonoBehaviour
	{
		public enum MovementFunction
		{
			Nonlinear = 0,
			LinearDirect = 1
		}

		[Header("Step Multiplier Settings")]
		[Tooltip("The controller button to activate the step multiplier effect. If it is `Undefined` then the step multiplier will always be active.")]
		public VRTK_ControllerEvents.ButtonAlias activationButton;

		[Tooltip("This determines the type of movement used by the extender.")]
		public MovementFunction movementFunction = MovementFunction.LinearDirect;

		[Tooltip("This is the factor by which movement at the edge of the circle is amplified. `0` is no movement of the play area. Higher values simulate a bigger play area but may be too uncomfortable.")]
		[Range(0f, 10f)]
		public float additionalMovementMultiplier = 1f;

		[Tooltip("This is the size of the circle in which the play area is not moved and everything is normal. If it is to low it becomes uncomfortable when crouching.")]
		[Range(0f, 5f)]
		public float headZoneRadius = 0.25f;

		[Header("Custom Settings")]
		[Tooltip("The Controller Events to listen for the events on. If the script is being applied onto a controller then this parameter can be left blank as it will be auto populated by the controller the script is on at runtime.")]
		public VRTK_ControllerEvents controllerEvents;

		protected Vector3 relativeMovementOfCameraRig;

		protected Transform movementTransform;

		protected Transform playArea;

		protected Vector3 headCirclePosition;

		protected Vector3 lastPosition;

		protected Vector3 lastMovement;

		protected bool activationEnabled;

		protected VRTK_ControllerEvents.ButtonAlias subscribedActivationButton;

		protected bool buttonSubscribed;

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			activationEnabled = false;
			buttonSubscribed = false;
			movementTransform = VRTK_DeviceFinder.HeadsetTransform();
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			MoveHeadCircleNonLinearDrift();
			if (movementTransform != null)
			{
				lastPosition = movementTransform.localPosition;
			}
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			ManageButtonSubscription();
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

		protected virtual void ManageButtonSubscription()
		{
			controllerEvents = ((controllerEvents != null) ? controllerEvents : GetComponentInParent<VRTK_ControllerEvents>());
			if (controllerEvents != null && buttonSubscribed && subscribedActivationButton != VRTK_ControllerEvents.ButtonAlias.Undefined && activationButton != subscribedActivationButton)
			{
				buttonSubscribed = false;
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: true, ActivationButtonPressed);
				controllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: false, ActivationButtonReleased);
				subscribedActivationButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			if (controllerEvents != null && !buttonSubscribed && activationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: true, ActivationButtonPressed);
				controllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: false, ActivationButtonReleased);
				buttonSubscribed = true;
				subscribedActivationButton = activationButton;
			}
		}

		protected virtual void ActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			activationEnabled = true;
		}

		protected virtual void ActivationButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			activationEnabled = false;
		}

		protected virtual void Move(Vector3 movement)
		{
			headCirclePosition += movement;
			if (playArea != null && (activationEnabled || activationButton == VRTK_ControllerEvents.ButtonAlias.Undefined))
			{
				playArea.localPosition += movement * additionalMovementMultiplier;
				relativeMovementOfCameraRig += movement * additionalMovementMultiplier;
			}
		}

		protected virtual void MoveHeadCircle()
		{
			if (movementTransform != null)
			{
				Vector3 vector = new Vector3(movementTransform.localPosition.x - headCirclePosition.x, 0f, movementTransform.localPosition.z - headCirclePosition.z);
				UpdateLastMovement();
				if (vector.sqrMagnitude > headZoneRadius * headZoneRadius && lastMovement != Vector3.zero)
				{
					Move(lastMovement);
				}
			}
		}

		protected virtual void MoveHeadCircleNonLinearDrift()
		{
			if (movementTransform != null)
			{
				Vector3 vector = new Vector3(movementTransform.localPosition.x - headCirclePosition.x, 0f, movementTransform.localPosition.z - headCirclePosition.z);
				if (vector.sqrMagnitude > headZoneRadius * headZoneRadius)
				{
					Vector3 movement = vector.normalized * (vector.magnitude - headZoneRadius);
					Move(movement);
				}
			}
		}

		protected virtual void UpdateLastMovement()
		{
			if (movementTransform != null)
			{
				lastMovement = movementTransform.localPosition - lastPosition;
				lastMovement.y = 0f;
				lastPosition = movementTransform.localPosition;
			}
		}
	}
}
