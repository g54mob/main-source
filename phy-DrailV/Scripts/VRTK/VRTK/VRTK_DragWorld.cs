using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_DragWorld")]
	public class VRTK_DragWorld : MonoBehaviour
	{
		public enum ActivationRequirement
		{
			LeftControllerOnly = 0,
			RightControllerOnly = 1,
			LeftController = 2,
			RightController = 3,
			EitherController = 4,
			BothControllers = 5
		}

		public enum TrackingController
		{
			LeftController = 0,
			RightController = 1,
			EitherController = 2,
			BothControllers = 3
		}

		[Header("Movement Settings")]
		[Tooltip("The controller button to press to activate the movement mechanism.")]
		public VRTK_ControllerEvents.ButtonAlias movementActivationButton = VRTK_ControllerEvents.ButtonAlias.GripPress;

		[Tooltip("The controller(s) on which the activation button is to be pressed to consider the movement mechanism active.")]
		public ActivationRequirement movementActivationRequirement = ActivationRequirement.EitherController;

		[Tooltip("The controller(s) on which to track position of to determine if a valid move has taken place.")]
		public TrackingController movementTrackingController = TrackingController.BothControllers;

		[Tooltip("The amount to multply the movement by.")]
		public float movementMultiplier = 3f;

		[Tooltip("The axes to lock to prevent movement across.")]
		public Vector3State movementPositionLock = new Vector3State(x: false, y: true, z: false);

		[Header("Rotation Settings")]
		[Tooltip("The controller button to press to activate the rotation mechanism.")]
		public VRTK_ControllerEvents.ButtonAlias rotationActivationButton = VRTK_ControllerEvents.ButtonAlias.GripPress;

		[Tooltip("The controller(s) on which the activation button is to be pressed to consider the rotation mechanism active.")]
		public ActivationRequirement rotationActivationRequirement = ActivationRequirement.BothControllers;

		[Tooltip("The controller(s) on which to determine how rotation should occur. `BothControllers` requires both controllers to be pushed/pulled to rotate, whereas any other setting will base rotation on the rotation of the activating controller.")]
		public TrackingController rotationTrackingController = TrackingController.BothControllers;

		[Tooltip("The amount to multply the rotation angle by.")]
		public float rotationMultiplier = 0.75f;

		[Tooltip("The threshold the rotation angle has to be above to consider a valid rotation amount.")]
		public float rotationActivationThreshold = 0.1f;

		[Header("Scale Settings")]
		[Tooltip("The controller button to press to activate the scale mechanism.")]
		public VRTK_ControllerEvents.ButtonAlias scaleActivationButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;

		[Tooltip("The controller(s) on which the activation button is to be pressed to consider the scale mechanism active.")]
		public ActivationRequirement scaleActivationRequirement = ActivationRequirement.BothControllers;

		[Tooltip("The controller(s) on which to determine how scaling should occur.")]
		public TrackingController scaleTrackingController = TrackingController.BothControllers;

		[Tooltip("The amount to multply the scale factor by.")]
		public float scaleMultiplier = 3f;

		[Tooltip("The threshold the distance between the scale objects has to be above to consider a valid scale operation.")]
		public float scaleActivationThreshold = 0.002f;

		[Tooltip("the minimum scale amount that can be applied.")]
		public Vector3 minimumScale = Vector3.one;

		[Tooltip("the maximum scale amount that can be applied.")]
		public Vector3 maximumScale = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

		[Header("Custom Settings")]
		[Tooltip("The transform to apply the control mechanisms to. If this is left blank then the PlayArea will be controlled.")]
		public Transform controllingTransform;

		[Tooltip("Uses the specified `Offset Transform` when dealing with rotational offsets.")]
		public bool useOffsetTransform = true;

		[Tooltip("The transform to use when dealing with rotational offsets. If this is left blank then the Headset will be used as the offset.")]
		public Transform offsetTransform;

		protected VRTK_ControllerReference leftControllerReference;

		protected VRTK_ControllerReference rightControllerReference;

		protected VRTK_ControllerEvents leftControllerEvents;

		protected VRTK_ControllerEvents rightControllerEvents;

		protected Transform playArea;

		protected Transform headset;

		protected VRTK_ControllerEvents.ButtonAlias subscribedMovementActivationButton;

		protected Vector3 previousLeftControllerPosition = Vector3.zero;

		protected Vector3 previousRightControllerPosition = Vector3.zero;

		protected bool movementLeftControllerActivated;

		protected bool movementRightControllerActivated;

		protected bool movementActivated;

		protected VRTK_ControllerEvents.ButtonAlias subscribedRotationActivationButton;

		protected Vector2 previousRotationAngle = Vector2.zero;

		protected bool rotationLeftControllerActivated;

		protected bool rotationRightControllerActivated;

		protected bool rotationActivated;

		protected VRTK_ControllerEvents.ButtonAlias subscribedScaleActivationButton;

		protected float previousControllerDistance;

		protected bool scaleLeftControllerActivated;

		protected bool scaleRightControllerActivated;

		protected bool scaleActivated;

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			headset = VRTK_DeviceFinder.HeadsetTransform();
			controllingTransform = ((controllingTransform != null) ? controllingTransform : playArea);
			offsetTransform = ((offsetTransform != null) ? offsetTransform : headset);
			leftControllerEvents = GetControllerEvents(VRTK_DeviceFinder.GetControllerLeftHand());
			rightControllerEvents = GetControllerEvents(VRTK_DeviceFinder.GetControllerRightHand());
			movementActivated = false;
			rotationActivated = false;
			scaleActivated = false;
			ManageActivationListeners(state: true);
			SetControllerReferences();
		}

		protected virtual void OnDisable()
		{
			ManageActivationListeners(state: false);
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void FixedUpdate()
		{
			Scale();
			Rotate();
			Move();
			ManageActivationListeners(state: true);
		}

		protected virtual VRTK_ControllerEvents GetControllerEvents(GameObject controllerObject)
		{
			if (!(controllerObject != null))
			{
				return null;
			}
			return controllerObject.GetComponentInChildren<VRTK_ControllerEvents>();
		}

		protected virtual void ManageActivationListeners(bool state)
		{
			ManageActivationListener(state, ref movementActivationButton, ref subscribedMovementActivationButton, MovementActivationButtonPressed, MovementActivationButtonReleased);
			ManageActivationListener(state, ref rotationActivationButton, ref subscribedRotationActivationButton, RotationActivationButtonPressed, RotationActivationButtonReleased);
			ManageActivationListener(state, ref scaleActivationButton, ref subscribedScaleActivationButton, ScaleActivationButtonPressed, ScaleActivationButtonReleased);
		}

		protected virtual void ManageActivationListener(bool state, ref VRTK_ControllerEvents.ButtonAlias activationButton, ref VRTK_ControllerEvents.ButtonAlias subscribedActivationButton, ControllerInteractionEventHandler buttonPressedCallback, ControllerInteractionEventHandler buttonReleasedCallback)
		{
			if (subscribedActivationButton == VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || activationButton != subscribedActivationButton))
			{
				if (leftControllerEvents != null)
				{
					leftControllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: true, buttonPressedCallback);
					leftControllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: false, buttonReleasedCallback);
					leftControllerEvents.ControllerModelAvailable -= ControllerModelAvailable;
				}
				if (rightControllerEvents != null)
				{
					rightControllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: true, buttonPressedCallback);
					rightControllerEvents.UnsubscribeToButtonAliasEvent(subscribedActivationButton, startEvent: false, buttonReleasedCallback);
					rightControllerEvents.ControllerModelAvailable -= ControllerModelAvailable;
				}
				subscribedActivationButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			if (state && subscribedActivationButton == VRTK_ControllerEvents.ButtonAlias.Undefined && activationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
			{
				bool flag = false;
				if (leftControllerEvents != null)
				{
					leftControllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: true, buttonPressedCallback);
					leftControllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: false, buttonReleasedCallback);
					leftControllerEvents.ControllerModelAvailable += ControllerModelAvailable;
					flag = true;
				}
				if (rightControllerEvents != null)
				{
					rightControllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: true, buttonPressedCallback);
					rightControllerEvents.SubscribeToButtonAliasEvent(activationButton, startEvent: false, buttonReleasedCallback);
					rightControllerEvents.ControllerModelAvailable += ControllerModelAvailable;
					flag = true;
				}
				if (flag)
				{
					subscribedActivationButton = activationButton;
				}
			}
		}

		protected virtual void ControllerModelAvailable(object sender, ControllerInteractionEventArgs e)
		{
			SetControllerReferences();
		}

		protected virtual void SetControllerReferences()
		{
			leftControllerReference = VRTK_DeviceFinder.GetControllerReferenceLeftHand();
			rightControllerReference = VRTK_DeviceFinder.GetControllerReferenceRightHand();
		}

		protected virtual void ManageActivationState(SDK_BaseController.ControllerHand hand, ActivationRequirement activationRequirement, bool pressedState, ref bool leftActivationState, ref bool rightActivationState, ref bool activated)
		{
			switch (hand)
			{
			case SDK_BaseController.ControllerHand.Left:
				leftActivationState = pressedState;
				break;
			case SDK_BaseController.ControllerHand.Right:
				rightActivationState = pressedState;
				break;
			}
			switch (activationRequirement)
			{
			case ActivationRequirement.LeftControllerOnly:
				activated = !rightActivationState && leftActivationState;
				break;
			case ActivationRequirement.RightControllerOnly:
				activated = !leftActivationState && rightActivationState;
				break;
			case ActivationRequirement.LeftController:
				activated = leftActivationState;
				break;
			case ActivationRequirement.RightController:
				activated = rightActivationState;
				break;
			case ActivationRequirement.EitherController:
				activated = leftActivationState | rightActivationState;
				break;
			case ActivationRequirement.BothControllers:
				activated = leftActivationState & rightActivationState;
				break;
			}
		}

		protected virtual void MovementActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			ManageActivationState(e.controllerReference.hand, movementActivationRequirement, pressedState: true, ref movementLeftControllerActivated, ref movementRightControllerActivated, ref movementActivated);
			SetControllerPositions();
		}

		protected virtual void MovementActivationButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			ManageActivationState(e.controllerReference.hand, movementActivationRequirement, pressedState: false, ref movementLeftControllerActivated, ref movementRightControllerActivated, ref movementActivated);
		}

		protected virtual void RotationActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			ManageActivationState(e.controllerReference.hand, rotationActivationRequirement, pressedState: true, ref rotationLeftControllerActivated, ref rotationRightControllerActivated, ref rotationActivated);
			previousRotationAngle = GetControllerRotation();
		}

		protected virtual void RotationActivationButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			ManageActivationState(e.controllerReference.hand, rotationActivationRequirement, pressedState: false, ref rotationLeftControllerActivated, ref rotationRightControllerActivated, ref rotationActivated);
		}

		protected virtual void ScaleActivationButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			ManageActivationState(e.controllerReference.hand, scaleActivationRequirement, pressedState: true, ref scaleLeftControllerActivated, ref scaleRightControllerActivated, ref scaleActivated);
			previousControllerDistance = GetControllerDistance();
		}

		protected virtual void ScaleActivationButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			ManageActivationState(e.controllerReference.hand, scaleActivationRequirement, pressedState: false, ref scaleLeftControllerActivated, ref scaleRightControllerActivated, ref scaleActivated);
		}

		protected virtual Vector3 GetLeftControllerPosition()
		{
			if (!VRTK_ControllerReference.IsValid(leftControllerReference))
			{
				return Vector3.zero;
			}
			return leftControllerReference.actual.transform.localPosition;
		}

		protected virtual Vector3 GetRightControllerPosition()
		{
			if (!VRTK_ControllerReference.IsValid(rightControllerReference))
			{
				return Vector3.zero;
			}
			return rightControllerReference.actual.transform.localPosition;
		}

		protected virtual void SetControllerPositions()
		{
			previousLeftControllerPosition = GetLeftControllerPosition();
			previousRightControllerPosition = GetRightControllerPosition();
		}

		protected virtual Vector2 GetControllerRotation()
		{
			return new Vector2((GetLeftControllerPosition() - GetRightControllerPosition()).x, (GetLeftControllerPosition() - GetRightControllerPosition()).z);
		}

		protected virtual float GetControllerDistance()
		{
			switch (scaleTrackingController)
			{
			case TrackingController.BothControllers:
				return Vector3.Distance(GetLeftControllerPosition(), GetRightControllerPosition());
			case TrackingController.LeftController:
				return Vector3.Distance(GetLeftControllerPosition(), offsetTransform.localPosition);
			case TrackingController.RightController:
				return Vector3.Distance(GetRightControllerPosition(), offsetTransform.localPosition);
			case TrackingController.EitherController:
				return Vector3.Distance(GetLeftControllerPosition(), offsetTransform.localPosition) + Vector3.Distance(GetRightControllerPosition(), offsetTransform.localPosition);
			default:
				return 0f;
			}
		}

		protected virtual bool TrackingControllerEnabled(TrackingController trackingController, TrackingController hand, bool handActivated)
		{
			if (trackingController != TrackingController.BothControllers && trackingController != hand)
			{
				return trackingController == TrackingController.EitherController && handActivated;
			}
			return true;
		}

		protected virtual void Move()
		{
			if (movementActivated)
			{
				Vector3 vector = (TrackingControllerEnabled(movementTrackingController, TrackingController.LeftController, movementLeftControllerActivated) ? (GetLeftControllerPosition() - previousLeftControllerPosition) : Vector3.zero);
				Vector3 vector2 = (TrackingControllerEnabled(movementTrackingController, TrackingController.RightController, movementRightControllerActivated) ? (GetRightControllerPosition() - previousRightControllerPosition) : Vector3.zero);
				Vector3 vector3 = controllingTransform.localRotation * (vector + vector2);
				Vector3 vector4 = controllingTransform.localPosition - Vector3.Scale(vector3 * movementMultiplier, controllingTransform.localScale);
				controllingTransform.localPosition = new Vector3(movementPositionLock.xState ? controllingTransform.localPosition.x : vector4.x, movementPositionLock.yState ? controllingTransform.localPosition.y : vector4.y, movementPositionLock.zState ? controllingTransform.localPosition.z : vector4.z);
				SetControllerPositions();
			}
		}

		protected virtual void Rotate()
		{
			if (rotationActivated)
			{
				if (rotationTrackingController == TrackingController.BothControllers && VRTK_ControllerReference.IsValid(leftControllerReference) && VRTK_ControllerReference.IsValid(rightControllerReference))
				{
					Vector2 controllerRotation = GetControllerRotation();
					float angle = Vector2.Angle(controllerRotation, previousRotationAngle) * Mathf.Sign(Vector3.Cross(controllerRotation, previousRotationAngle).z);
					RotateByAngle(angle);
					previousRotationAngle = controllerRotation;
				}
				else
				{
					float num = (TrackingControllerEnabled(rotationTrackingController, TrackingController.LeftController, rotationLeftControllerActivated) ? VRTK_DeviceFinder.GetControllerAngularVelocity(leftControllerReference).y : 0f);
					float num2 = (TrackingControllerEnabled(rotationTrackingController, TrackingController.RightController, rotationRightControllerActivated) ? VRTK_DeviceFinder.GetControllerAngularVelocity(rightControllerReference).y : 0f);
					RotateByAngle(num + num2);
				}
			}
		}

		protected virtual void RotateByAngle(float angle)
		{
			if (Mathf.Abs(angle) >= rotationActivationThreshold)
			{
				if (useOffsetTransform)
				{
					controllingTransform.RotateAround(offsetTransform.position, Vector3.up, angle * rotationMultiplier);
				}
				else
				{
					controllingTransform.Rotate(Vector3.up * (angle * rotationMultiplier));
				}
			}
		}

		protected virtual void Scale()
		{
			if (scaleActivated)
			{
				float controllerDistance = GetControllerDistance();
				float f = controllerDistance - previousControllerDistance;
				if (Mathf.Abs(f) >= scaleActivationThreshold)
				{
					controllingTransform.localScale += Vector3.one * Time.deltaTime * Mathf.Sign(f) * scaleMultiplier;
					controllingTransform.localScale = new Vector3(Mathf.Clamp(controllingTransform.localScale.x, minimumScale.x, maximumScale.x), Mathf.Clamp(controllingTransform.localScale.y, minimumScale.y, maximumScale.y), Mathf.Clamp(controllingTransform.localScale.z, minimumScale.z, maximumScale.z));
				}
				previousControllerDistance = controllerDistance;
			}
		}
	}
}
