using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_MoveInPlace")]
	public class VRTK_MoveInPlace : MonoBehaviour
	{
		public enum ControlOptions
		{
			HeadsetAndControllers = 0,
			ControllersOnly = 1,
			HeadsetOnly = 2
		}

		public enum DirectionalMethod
		{
			Gaze = 0,
			ControllerRotation = 1,
			DumbDecoupling = 2,
			SmartDecoupling = 3,
			EngageControllerRotationOnly = 4,
			LeftControllerRotationOnly = 5,
			RightControllerRotationOnly = 6
		}

		[Header("Control Settings")]
		[Tooltip("If this is checked then the left controller engage button will be enabled to move the play area.")]
		public bool leftController = true;

		[Tooltip("If this is checked then the right controller engage button will be enabled to move the play area.")]
		public bool rightController = true;

		[Tooltip("The button to press to activate the movement.")]
		public VRTK_ControllerEvents.ButtonAlias engageButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

		[Tooltip("The device to determine the movement paramters from.")]
		public ControlOptions controlOptions;

		[Tooltip("The method in which to determine the direction of forward movement.")]
		public DirectionalMethod directionMethod;

		[Header("Speed Settings")]
		[Tooltip("The speed in which to move the play area.")]
		public float speedScale = 1f;

		[Tooltip("The maximun speed in game units. (If 0 or less, max speed is uncapped)")]
		public float maxSpeed = 4f;

		[Tooltip("The speed in which the play area slows down to a complete stop when the engage button is released. This deceleration effect can ease any motion sickness that may be suffered.")]
		public float deceleration = 0.1f;

		[Tooltip("The speed in which the play area slows down to a complete stop when falling is occuring.")]
		public float fallingDeceleration = 0.01f;

		[Header("Advanced Settings")]
		[Tooltip("The degree threshold that all tracked objects (controllers, headset) must be within to change direction when using the Smart Decoupling Direction Method.")]
		public float smartDecoupleThreshold = 30f;

		[Tooltip("The maximum amount of movement required to register in the virtual world.  Decreasing this will increase acceleration, and vice versa.")]
		public float sensitivity = 0.02f;

		[Header("Custom Settings")]
		[Tooltip("An optional Body Physics script to check for potential collisions in the moving direction. If any potential collision is found then the move will not take place. This can help reduce collision tunnelling.")]
		public VRTK_BodyPhysics bodyPhysics;

		protected Transform playArea;

		protected GameObject controllerLeftHand;

		protected GameObject controllerRightHand;

		protected VRTK_ControllerReference engagedController;

		protected Transform headset;

		protected bool leftSubscribed;

		protected bool rightSubscribed;

		protected bool previousLeftControllerState;

		protected bool previousRightControllerState;

		protected VRTK_ControllerEvents.ButtonAlias previousEngageButton;

		protected bool currentlyFalling;

		protected int averagePeriod;

		protected List<Transform> trackedObjects = new List<Transform>();

		protected Dictionary<Transform, List<float>> movementList = new Dictionary<Transform, List<float>>();

		protected Dictionary<Transform, float> previousYPositions = new Dictionary<Transform, float>();

		protected Vector3 initialGaze;

		protected float currentSpeed;

		protected Vector3 currentDirection;

		protected Vector3 previousDirection;

		protected bool movementEngaged;

		public virtual void SetControlOptions(ControlOptions givenControlOptions)
		{
			controlOptions = givenControlOptions;
			trackedObjects.Clear();
			if (controllerLeftHand != null && controllerRightHand != null && (controlOptions == ControlOptions.HeadsetAndControllers || controlOptions == ControlOptions.ControllersOnly))
			{
				VRTK_SharedMethods.AddListValue(trackedObjects, VRTK_DeviceFinder.GetActualController(controllerLeftHand).transform, preventDuplicates: true);
				VRTK_SharedMethods.AddListValue(trackedObjects, VRTK_DeviceFinder.GetActualController(controllerRightHand).transform, preventDuplicates: true);
			}
			if (headset != null && (controlOptions == ControlOptions.HeadsetAndControllers || controlOptions == ControlOptions.HeadsetOnly))
			{
				VRTK_SharedMethods.AddListValue(trackedObjects, headset.transform, preventDuplicates: true);
			}
		}

		public virtual Vector3 GetMovementDirection()
		{
			return currentDirection;
		}

		public virtual float GetSpeed()
		{
			return currentSpeed;
		}

		protected virtual void Awake()
		{
			VRTK_SDKManager.AttemptAddBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void OnEnable()
		{
			trackedObjects.Clear();
			movementList.Clear();
			previousYPositions.Clear();
			initialGaze = Vector3.zero;
			currentDirection = Vector3.zero;
			previousDirection = Vector3.zero;
			averagePeriod = 60;
			currentSpeed = 0f;
			movementEngaged = false;
			previousEngageButton = engageButton;
			bodyPhysics = ((bodyPhysics != null) ? bodyPhysics : Object.FindObjectOfType<VRTK_BodyPhysics>());
			controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			SetControllerListeners(controllerLeftHand, leftController, ref leftSubscribed);
			SetControllerListeners(controllerRightHand, rightController, ref rightSubscribed);
			headset = VRTK_DeviceFinder.HeadsetTransform();
			SetControlOptions(controlOptions);
			playArea = VRTK_DeviceFinder.PlayAreaTransform();
			for (int i = 0; i < trackedObjects.Count; i++)
			{
				Transform transform = trackedObjects[i];
				VRTK_SharedMethods.AddDictionaryValue(movementList, transform, new List<float>(), overwriteExisting: true);
				VRTK_SharedMethods.AddDictionaryValue(previousYPositions, transform, transform.transform.localPosition.y, overwriteExisting: true);
			}
		}

		protected virtual void OnDisable()
		{
			SetControllerListeners(controllerLeftHand, leftController, ref leftSubscribed, forceDisabled: true);
			SetControllerListeners(controllerRightHand, rightController, ref rightSubscribed, forceDisabled: true);
			controllerLeftHand = null;
			controllerRightHand = null;
			headset = null;
			playArea = null;
		}

		protected virtual void OnDestroy()
		{
			VRTK_SDKManager.AttemptRemoveBehaviourToToggleOnLoadedSetupChange(this);
		}

		protected virtual void Update()
		{
			CheckControllerState(controllerLeftHand, leftController, ref leftSubscribed, ref previousLeftControllerState);
			CheckControllerState(controllerRightHand, rightController, ref rightSubscribed, ref previousRightControllerState);
			previousEngageButton = engageButton;
		}

		protected virtual void FixedUpdate()
		{
			HandleFalling();
			if (MovementActivated() && !currentlyFalling)
			{
				float num = Mathf.Clamp(speedScale * 350f * (CalculateListAverage() / (float)trackedObjects.Count), 0f, maxSpeed);
				previousDirection = currentDirection;
				currentDirection = SetDirection();
				currentSpeed = num;
			}
			else if (currentSpeed > 0f)
			{
				currentSpeed -= (currentlyFalling ? fallingDeceleration : deceleration);
			}
			else
			{
				currentSpeed = 0f;
				currentDirection = Vector3.zero;
				previousDirection = Vector3.zero;
			}
			SetDeltaTransformData();
			MovePlayArea(currentDirection, currentSpeed);
		}

		protected virtual bool MovementActivated()
		{
			if (!movementEngaged)
			{
				return engageButton == VRTK_ControllerEvents.ButtonAlias.Undefined;
			}
			return true;
		}

		protected virtual void CheckControllerState(GameObject controller, bool controllerState, ref bool subscribedState, ref bool previousState)
		{
			if (controllerState != previousState || engageButton != previousEngageButton)
			{
				SetControllerListeners(controller, controllerState, ref subscribedState);
			}
			previousState = controllerState;
		}

		protected virtual float CalculateListAverage()
		{
			float num = 0f;
			for (int i = 0; i < trackedObjects.Count; i++)
			{
				Transform transform = trackedObjects[i];
				float num2 = Mathf.Abs(VRTK_SharedMethods.GetDictionaryValue(previousYPositions, transform, 0f) - transform.transform.localPosition.y);
				List<float> dictionaryValue = VRTK_SharedMethods.GetDictionaryValue(movementList, transform, new List<float>(), setMissingKey: true);
				if (num2 > sensitivity)
				{
					VRTK_SharedMethods.AddListValue(dictionaryValue, sensitivity);
				}
				else
				{
					VRTK_SharedMethods.AddListValue(dictionaryValue, num2);
				}
				if (dictionaryValue.Count > averagePeriod)
				{
					dictionaryValue.RemoveAt(0);
				}
				float num3 = 0f;
				for (int j = 0; j < dictionaryValue.Count; j++)
				{
					float num4 = dictionaryValue[j];
					num3 += num4;
				}
				float num5 = num3 / (float)averagePeriod;
				num += num5;
			}
			return num;
		}

		protected virtual Vector3 HeadsetPosition()
		{
			if (!(headset != null))
			{
				return Vector3.zero;
			}
			return new Vector3(headset.forward.x, 0f, headset.forward.z);
		}

		protected virtual Vector3 SetDirection()
		{
			switch (directionMethod)
			{
			case DirectionalMethod.DumbDecoupling:
			case DirectionalMethod.SmartDecoupling:
				return CalculateCouplingDirection();
			case DirectionalMethod.ControllerRotation:
				return CalculateControllerRotationDirection(DetermineAverageControllerRotation() * Vector3.forward);
			case DirectionalMethod.LeftControllerRotationOnly:
				return CalculateControllerRotationDirection(((controllerLeftHand != null) ? controllerLeftHand.transform.rotation : Quaternion.identity) * Vector3.forward);
			case DirectionalMethod.RightControllerRotationOnly:
				return CalculateControllerRotationDirection(((controllerRightHand != null) ? controllerRightHand.transform.rotation : Quaternion.identity) * Vector3.forward);
			case DirectionalMethod.EngageControllerRotationOnly:
				return CalculateControllerRotationDirection(((engagedController != null) ? engagedController.scriptAlias.transform.rotation : Quaternion.identity) * Vector3.forward);
			case DirectionalMethod.Gaze:
				return HeadsetPosition();
			default:
				return Vector2.zero;
			}
		}

		protected virtual Vector3 CalculateCouplingDirection()
		{
			if (initialGaze == Vector3.zero)
			{
				initialGaze = HeadsetPosition();
			}
			if (directionMethod == DirectionalMethod.SmartDecoupling)
			{
				float num = ((headset != null) ? headset.rotation.eulerAngles.y : 0f);
				if (num <= smartDecoupleThreshold)
				{
					num += 360f;
				}
				if (true && Mathf.Abs(num - controllerLeftHand.transform.rotation.eulerAngles.y) <= smartDecoupleThreshold && Mathf.Abs(num - controllerRightHand.transform.rotation.eulerAngles.y) <= smartDecoupleThreshold)
				{
					initialGaze = HeadsetPosition();
				}
			}
			return initialGaze;
		}

		protected virtual Vector3 CalculateControllerRotationDirection(Vector3 calculatedControllerDirection)
		{
			if (!(Vector3.Angle(previousDirection, calculatedControllerDirection) <= 90f))
			{
				return previousDirection;
			}
			return calculatedControllerDirection;
		}

		protected virtual void SetDeltaTransformData()
		{
			for (int i = 0; i < trackedObjects.Count; i++)
			{
				Transform transform = trackedObjects[i];
				VRTK_SharedMethods.AddDictionaryValue(previousYPositions, transform, transform.transform.localPosition.y, overwriteExisting: true);
			}
		}

		protected virtual void MovePlayArea(Vector3 moveDirection, float moveSpeed)
		{
			Vector3 vector = moveDirection * moveSpeed * Time.fixedDeltaTime;
			if (playArea != null)
			{
				Vector3 vector2 = new Vector3(vector.x + playArea.position.x, playArea.position.y, vector.z + playArea.position.z);
				if (CanMove(bodyPhysics, playArea.position, vector2))
				{
					playArea.position = vector2;
				}
			}
		}

		protected virtual bool CanMove(VRTK_BodyPhysics givenBodyPhysics, Vector3 currentPosition, Vector3 proposedPosition)
		{
			if (givenBodyPhysics == null)
			{
				return true;
			}
			Vector3 normalized = (proposedPosition - currentPosition).normalized;
			float maxDistance = Vector3.Distance(currentPosition, proposedPosition);
			return !givenBodyPhysics.SweepCollision(normalized, maxDistance);
		}

		protected virtual void HandleFalling()
		{
			if (bodyPhysics != null && bodyPhysics.IsFalling())
			{
				currentlyFalling = true;
			}
			if (bodyPhysics != null && !bodyPhysics.IsFalling() && currentlyFalling)
			{
				currentlyFalling = false;
				currentSpeed = 0f;
			}
		}

		protected virtual void EngageButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			engagedController = e.controllerReference;
			movementEngaged = true;
		}

		protected virtual void EngageButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			for (int i = 0; i < trackedObjects.Count; i++)
			{
				Transform key = trackedObjects[i];
				VRTK_SharedMethods.GetDictionaryValue(movementList, key, new List<float>()).Clear();
			}
			initialGaze = Vector3.zero;
			movementEngaged = false;
			engagedController = null;
		}

		protected virtual Quaternion DetermineAverageControllerRotation()
		{
			if (controllerLeftHand != null && controllerRightHand != null)
			{
				return AverageRotation(controllerLeftHand.transform.rotation, controllerRightHand.transform.rotation);
			}
			if (controllerLeftHand != null && controllerRightHand == null)
			{
				return controllerLeftHand.transform.rotation;
			}
			if (controllerRightHand != null && controllerLeftHand == null)
			{
				return controllerRightHand.transform.rotation;
			}
			return Quaternion.identity;
		}

		protected virtual Quaternion AverageRotation(Quaternion rot1, Quaternion rot2)
		{
			return Quaternion.Slerp(rot1, rot2, 0.5f);
		}

		protected virtual void SetControllerListeners(GameObject controller, bool controllerState, ref bool subscribedState, bool forceDisabled = false)
		{
			if (controller != null)
			{
				bool toggle = !forceDisabled && controllerState;
				ToggleControllerListeners(controller, toggle, ref subscribedState);
			}
		}

		protected virtual void ToggleControllerListeners(GameObject controller, bool toggle, ref bool subscribed)
		{
			VRTK_ControllerEvents componentInChildren = controller.GetComponentInChildren<VRTK_ControllerEvents>();
			if (componentInChildren != null)
			{
				if ((engageButton != previousEngageButton) & subscribed)
				{
					componentInChildren.UnsubscribeToButtonAliasEvent(previousEngageButton, startEvent: true, EngageButtonPressed);
					componentInChildren.UnsubscribeToButtonAliasEvent(previousEngageButton, startEvent: false, EngageButtonReleased);
					subscribed = false;
				}
				if (toggle && !subscribed)
				{
					componentInChildren.SubscribeToButtonAliasEvent(engageButton, startEvent: true, EngageButtonPressed);
					componentInChildren.SubscribeToButtonAliasEvent(engageButton, startEvent: false, EngageButtonReleased);
					subscribed = true;
				}
				else if (!toggle & subscribed)
				{
					componentInChildren.UnsubscribeToButtonAliasEvent(engageButton, startEvent: true, EngageButtonPressed);
					componentInChildren.UnsubscribeToButtonAliasEvent(engageButton, startEvent: false, EngageButtonReleased);
					subscribed = false;
				}
			}
		}
	}
}
