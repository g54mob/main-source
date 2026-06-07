using System;
using System.Collections;
using DV;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class RotatePlayer : SingletonBehaviour<RotatePlayer>
{
	private class RotationData
	{
		public bool initialized;

		public bool subscribedToEvents;

		public TouchpadInputInterpreter input;

		public VRTK_InteractGrab grab;

		public VRTK_ControllerEvents controllerEvents;

		public VRTK_InteractUse_DV use;

		public CabItemRigidbody currentlyGrabbed;

		public bool DisableRotationByUseModifier
		{
			get
			{
				if (use != null)
				{
					if (!use.UseModified)
					{
						return use.UsePressed;
					}
					return true;
				}
				return false;
			}
		}

		public bool IsWand { get; }

		public RotationData(GameObject controller, bool rightController, bool isWand)
		{
			subscribedToEvents = false;
			IsWand = isWand;
			string text = (rightController ? "Right" : "Left");
			input = controller.GetComponent<TouchpadInputInterpreter>();
			if (input == null)
			{
				Debug.LogError("Could not find 'TouchpadInputInterpreter' component on " + text + " controller. Initialization of 'RotationData' failed.", controller);
				initialized = false;
				return;
			}
			if (!rightController)
			{
				VRTK_DeviceFinder.GetControllerReferenceLeftHand();
			}
			else
			{
				VRTK_DeviceFinder.GetControllerReferenceRightHand();
			}
			grab = controller.GetComponent<VRTK_InteractGrab>();
			if (grab == null)
			{
				Debug.LogError("Could not find 'VRTK_InteractGrab' component on " + text + " controller. Initialization of 'RotationData' failed.", controller);
				initialized = false;
				return;
			}
			use = controller.GetComponent<VRTK_InteractUse_DV>();
			if (use == null)
			{
				Debug.LogError("Could not find 'VRTK_InteractUse_DV' component on " + text + " controller. Initialization of 'RotationData' failed.", controller);
				initialized = false;
				return;
			}
			currentlyGrabbed = grab.GetGrabbedObject()?.GetComponent<CabItemRigidbody>();
			controllerEvents = controller.GetComponent<VRTK_ControllerEvents>();
			initialized = controllerEvents != null;
			if (!initialized)
			{
				Debug.LogError(text + " controller is not initialized properly. There are missing components.", controller);
			}
		}
	}

	public static readonly float[] SNAP_VALUES = new float[6] { 30f, 45f, 60f, 90f, 120f, 180f };

	private const float SMOOTH_ROTATON_DEAD_ZONE = 0.2f;

	private const float SMOOTH_ROTATION_LERP_FACTOR = 1.25f;

	[Tooltip("The angle to rotate for each snap.")]
	public float anglePerSnap = 60f;

	public float smoothRotationAngularSpeed = 180f;

	[Tooltip("The speed for the headset to fade out and back in. Having a blink between rotations can reduce nausea.")]
	public float blinkTransitionSpeed = 0.3f;

	public bool canRotatePlayer = true;

	[SerializeField]
	private AnimationCurve smoothRotationInputCurve;

	private bool locomotionSetupSubscribed;

	private bool isSmoothLocomotion;

	private RotationData rotationDataLeft;

	private RotationData rotationDataRight;

	public RotationModeValue RotationMode { get; private set; }

	public static event Action AboutToRotatePlayer;

	public static event Action RotatedPlayer;

	public new static string AllowAutoCreate()
	{
		return null;
	}

	protected override void Initialize()
	{
		base.Initialize();
		VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
	}

	private IEnumerator Start()
	{
		yield return null;
		yield return null;
		InitializeRotationParameters();
		SetupListeners(on: true);
	}

	public void InitializeRotationParameters()
	{
		anglePerSnap = SNAP_VALUES[GamePreferences.Get<int>(Preferences.SnapRotationAngle)];
		smoothRotationAngularSpeed = GamePreferences.Get<float>(Preferences.SmoothRotationSpeed);
		RotationMode = (RotationModeValue)GamePreferences.Get<int>(Preferences.RotationMode);
		SetRotationActiveState(RotationMode != RotationModeValue.Off);
		isSmoothLocomotion = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
		if (SetupDeviceSpecificControls.AreControlsSetRight)
		{
			OnControlsSet(SDK_BaseController.ControllerHand.Right);
		}
		if (SetupDeviceSpecificControls.AreControlsSetLeft)
		{
			OnControlsSet(SDK_BaseController.ControllerHand.Left);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			GamePreferences.RegisterToPreferenceUpdated(Preferences.RotationMode, OnSnapRotationUpdated);
			GamePreferences.RegisterToPreferenceUpdated(Preferences.SnapRotationAngle, OnSnapRotationAngleUpdated);
			GamePreferences.RegisterToPreferenceUpdated(Preferences.SmoothRotationSpeed, OnSmoothRotationSpeedUpdated);
			GamePreferences.RegisterToPreferenceUpdated(Preferences.SmoothLocomotion, OnSmoothLocomotionUpdated);
			if (!SetupDeviceSpecificControls.AreControlsSetRight || !SetupDeviceSpecificControls.AreControlsSetLeft)
			{
				SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
			}
			return;
		}
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RotationMode, OnSnapRotationUpdated);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SnapRotationAngle, OnSnapRotationAngleUpdated);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SmoothRotationSpeed, OnSmoothRotationSpeedUpdated);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SmoothLocomotion, OnSmoothLocomotionUpdated);
		if (rotationDataLeft != null)
		{
			rotationDataLeft.grab.ControllerGrabInteractableObject -= OnObjectGrabbed;
			rotationDataLeft.grab.ControllerUngrabInteractableObject -= OnObjectUngrabbed;
		}
		if (rotationDataRight != null)
		{
			rotationDataRight.grab.ControllerGrabInteractableObject -= OnObjectGrabbed;
			rotationDataRight.grab.ControllerUngrabInteractableObject -= OnObjectUngrabbed;
		}
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		SetLocomotionListeners(on: false);
	}

	private void OnSmoothLocomotionUpdated()
	{
		isSmoothLocomotion = GamePreferences.Get<bool>(Preferences.SmoothLocomotion);
	}

	private void SetRotationActiveState(bool active)
	{
		if (active)
		{
			canRotatePlayer = true;
		}
		else
		{
			canRotatePlayer = false;
		}
	}

	private void OnObjectUngrabbed(object sender, ObjectInteractEventArgs e)
	{
		((e.controllerReference == VRTK_DeviceFinder.GetControllerReferenceRightHand()) ? rotationDataRight : rotationDataLeft).currentlyGrabbed = null;
	}

	private void OnObjectGrabbed(object sender, ObjectInteractEventArgs e)
	{
		CabItemRigidbody component = e.target.GetComponent<CabItemRigidbody>();
		((e.controllerReference == VRTK_DeviceFinder.GetControllerReferenceRightHand()) ? rotationDataRight : rotationDataLeft).currentlyGrabbed = component;
	}

	private void OnSnapRotationUpdated()
	{
		RotationMode = (RotationModeValue)GamePreferences.Get<int>(Preferences.RotationMode);
		SetRotationActiveState(RotationMode != RotationModeValue.Off);
	}

	private void OnSnapRotationAngleUpdated()
	{
		anglePerSnap = SNAP_VALUES[GamePreferences.Get<int>(Preferences.SnapRotationAngle)];
	}

	private void OnSmoothRotationSpeedUpdated()
	{
		smoothRotationAngularSpeed = GamePreferences.Get<float>(Preferences.SmoothRotationSpeed);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		SetLocomotionListeners(on: false);
		if (!UnloadWatcher.isUnloading)
		{
			VRTK_SDKManager.instance?.RemoveBehaviourToToggleOnLoadedSetupChange(this);
			SetupListeners(on: false);
		}
	}

	private void OnEnable()
	{
		VRTK_DeviceFinder.GetControllerLeftHand(getActual: true);
		VRTK_DeviceFinder.GetControllerRightHand(getActual: true);
		if (!locomotionSetupSubscribed)
		{
			SetLocomotionListeners(on: true);
		}
	}

	private void Update()
	{
		if (!TimeUtil.IsFlowing || RotationMode != RotationModeValue.Smooth || smoothRotationAngularSpeed == 0f)
		{
			return;
		}
		Vector2 vector = Vector2.zero;
		Vector2 vector2 = Vector2.zero;
		if (rotationDataRight != null && rotationDataRight.initialized && (!rotationDataRight.IsWand || rotationDataRight.controllerEvents.touchpadPressed))
		{
			vector = rotationDataRight.input.AxisValue;
		}
		if (!isSmoothLocomotion && rotationDataLeft != null && rotationDataLeft.initialized && (!rotationDataLeft.IsWand || rotationDataLeft.controllerEvents.touchpadPressed))
		{
			vector2 = rotationDataLeft.input.AxisValue;
		}
		if (vector == Vector2.zero && vector2 == Vector2.zero)
		{
			return;
		}
		float time = 0f;
		TouchpadInputDirection touchpadInputDirection = TouchpadInputDirection.None;
		if (CanUseAxis(vector, rotationDataRight, isRight: true))
		{
			(time, touchpadInputDirection) = GetAdjustedXAndDirection(vector);
		}
		if (touchpadInputDirection == TouchpadInputDirection.None && CanUseAxis(vector2, rotationDataLeft, isRight: false))
		{
			(time, touchpadInputDirection) = GetAdjustedXAndDirection(vector2);
		}
		if (touchpadInputDirection == TouchpadInputDirection.Left || touchpadInputDirection == TouchpadInputDirection.Right)
		{
			float num = smoothRotationInputCurve.Evaluate(time);
			if (!(num <= 0f))
			{
				float num2 = smoothRotationAngularSpeed * num * (float)((touchpadInputDirection != TouchpadInputDirection.Left) ? 1 : (-1));
				DoRotate(num2 * Time.deltaTime);
			}
		}
	}

	private bool CanUseAxis(Vector2 axis, RotationData data, bool isRight)
	{
		if (axis == Vector2.zero)
		{
			return false;
		}
		if (data.DisableRotationByUseModifier)
		{
			return false;
		}
		VRTK_ControllerReference ctrlRef = (isRight ? VRTK_DeviceFinder.GetControllerReferenceRightHand() : VRTK_DeviceFinder.GetControllerReferenceLeftHand());
		return CheckGrabbedObjectRotationRestriction(ctrlRef, horizontal: true);
	}

	private (float adjustedX, TouchpadInputDirection direction) GetAdjustedXAndDirection(Vector2 axis)
	{
		float num = Math.Max(0f, (Math.Abs(axis.x) - 0.2f) * 1.25f);
		TouchpadInputDirection item = ((num > 0f) ? TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(axis, ignoreDeadzone: true) : TouchpadInputDirection.None);
		return (adjustedX: num, direction: item);
	}

	private void SetLocomotionListeners(bool on)
	{
		if (on)
		{
			LocomotionSetup.LocomotionChanged += OnLocomotionTypeChanged;
		}
		else
		{
			LocomotionSetup.LocomotionChanged -= OnLocomotionTypeChanged;
		}
		locomotionSetupSubscribed = on;
	}

	private void OnLocomotionTypeChanged(LocomotionType locomotionType)
	{
		if (locomotionType == LocomotionType.Teleport)
		{
			Setup(rotationDataLeft, listenersOn: true);
			Setup(rotationDataRight, listenersOn: true);
		}
		else
		{
			Setup(rotationDataLeft, listenersOn: false);
			Setup(rotationDataRight, listenersOn: true);
		}
		void Setup(RotationData data, bool listenersOn)
		{
			if (data != null && data.initialized && data.subscribedToEvents != listenersOn)
			{
				SetupControllerListeners(listenersOn, data);
			}
		}
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand hand)
	{
		bool flag = hand == SDK_BaseController.ControllerHand.Right;
		RotationData rotationData = (flag ? rotationDataRight : rotationDataLeft);
		if (rotationData == null || !rotationData.initialized)
		{
			if (flag)
			{
				GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
				rotationData = (rotationDataRight = new RotationData(controllerRightHand, flag, VRTK_DeviceFinder.GetControllerReferenceRightHand().IsWandOrUndefined()));
				SetupControllerListeners(on: true, rotationDataRight);
			}
			else
			{
				GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
				rotationData = (rotationDataLeft = new RotationData(controllerLeftHand, flag, VRTK_DeviceFinder.GetControllerReferenceLeftHand().IsWandOrUndefined()));
				SetupControllerListeners(on: true, rotationDataLeft);
			}
		}
		if (rotationData.initialized)
		{
			OnLocomotionTypeChanged(LocomotionSetup.CurrentLocomotion);
		}
		if (SetupDeviceSpecificControls.AreControlsSetLeft && SetupDeviceSpecificControls.AreControlsSetRight)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}
	}

	private void SetupControllerListeners(bool on, RotationData rotationData)
	{
		if (on)
		{
			rotationData.input.DelayedDirectionalInputGiven += OnSnapRotationInputGiven;
			rotationData.currentlyGrabbed = rotationData.grab.GetGrabbedObject()?.GetComponent<CabItemRigidbody>();
			rotationData.grab.ControllerGrabInteractableObject += OnObjectGrabbed;
			rotationData.grab.ControllerUngrabInteractableObject += OnObjectUngrabbed;
		}
		else
		{
			rotationData.input.DelayedDirectionalInputGiven -= OnSnapRotationInputGiven;
			rotationData.currentlyGrabbed = null;
			rotationData.grab.ControllerGrabInteractableObject -= OnObjectGrabbed;
			rotationData.grab.ControllerUngrabInteractableObject -= OnObjectUngrabbed;
		}
		rotationData.subscribedToEvents = on;
	}

	private void OnSnapRotationInputGiven(TouchpadInputDirection direction, bool swiped, VRTK_ControllerReference ctrlRef)
	{
		if (canRotatePlayer && anglePerSnap > float.Epsilon && TimeUtil.IsFlowing && RotationMode == RotationModeValue.Snap && (direction == TouchpadInputDirection.Left || direction == TouchpadInputDirection.Right) && CheckGrabbedObjectRotationRestriction(ctrlRef, horizontal: true))
		{
			RotationData rotationData = ((ctrlRef.hand == SDK_BaseController.ControllerHand.Right) ? rotationDataRight : rotationDataLeft);
			if (!rotationData.IsWand || swiped || rotationData.controllerEvents.touchpadPressed)
			{
				float angle = ((direction == TouchpadInputDirection.Left) ? (0f - anglePerSnap) : anglePerSnap);
				DoRotate(angle);
			}
		}
	}

	private bool CheckGrabbedObjectRotationRestriction(VRTK_ControllerReference ctrlRef, bool horizontal)
	{
		RotationData rotationData = ((ctrlRef == VRTK_DeviceFinder.GetControllerReferenceRightHand()) ? rotationDataRight : rotationDataLeft);
		CabItemRigidbody cabItemRigidbody = rotationData?.currentlyGrabbed;
		if (cabItemRigidbody == null)
		{
			return true;
		}
		if (horizontal)
		{
			if (rotationData.DisableRotationByUseModifier)
			{
				return cabItemRigidbody.allowPlayerRotationXAxis;
			}
			return true;
		}
		if (rotationData.DisableRotationByUseModifier)
		{
			return cabItemRigidbody.allowPlayerRotationYAxis;
		}
		return true;
	}

	public void DoRotate(float angle)
	{
		RotatePlayer.AboutToRotatePlayer?.Invoke();
		if (RotationMode == RotationModeValue.Snap)
		{
			Blink();
		}
		RotateAroundPlayer(angle);
		RotatePlayer.RotatedPlayer?.Invoke();
	}

	private void Blink()
	{
		if (blinkTransitionSpeed > 0f)
		{
			VRTK_SDK_Bridge.HeadsetFade(Color.black, 0f);
			VRTK_SDK_Bridge.HeadsetFade(Color.clear, blinkTransitionSpeed);
		}
	}

	public void RotateAroundPlayer(float angle)
	{
		Transform transform = VRTK_DeviceFinder.PlayAreaTransform();
		if (GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType))
		{
			StrafeRotate(angle, transform);
			return;
		}
		Transform obj = VRTK_DeviceFinder.HeadsetTransform();
		Vector3 position = obj.position;
		transform.Rotate(Vector3.up, angle);
		Vector3 position2 = obj.position;
		Vector3 vector = position - position2;
		transform.position += vector;
	}

	private void StrafeRotate(float angle, Transform rig)
	{
		Transform obj = VRTK_DeviceFinder.HeadsetCamera();
		Vector3 vector = obj.position - PlayerManager.PlayerTransform.position;
		Vector3 vector2 = Quaternion.Euler(0f, angle, 0f) * vector + PlayerManager.PlayerTransform.position;
		rig.Rotate(Vector3.up, angle);
		Vector3 vector3 = obj.position - vector2;
		rig.transform.position -= vector3;
	}
}
