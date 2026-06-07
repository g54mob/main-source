using System;
using DV.CabControls;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class LocomotionInputVr : ILocomotionInputInterpreter, IDisposable
{
	private delegate bool RunInputDelegate();

	private RunInputDelegate RunInputGivenMethod;

	private float movementDeadZone = 0.02f;

	private float axisLerpFactor;

	private float jumpAndCrouchDeadzone = -0.625f;

	private float wmrRunDeadzone = 0.75f;

	private Vector2 vectorPrimary;

	private Vector2 vectorVelocity;

	private bool verticalSecondaryPointingDown;

	private float easing = 0.4f;

	private float jumpToCrouchThreshold = 0.25f;

	private float elapsedCrouchToJumpTime;

	private const float RUN_TOGGLE_THRESHOLD = 0.2f;

	private bool runToggleAllowed;

	private bool hasMovementInput;

	private float runToggleStartTime;

	private bool isRunning;

	private bool runInputPressed;

	private VRTK_ControllerEvents eventsPrimary;

	private VRTK_ControllerEvents eventsSecondary;

	private VRTK_InteractUse_DV usePrimary;

	private VRTK_InteractUse_DV useSecondary;

	private bool isViveWandPrimary;

	private bool isViveWandSecondary;

	private bool wandUseModifierPrimary;

	private bool wandUseModifierSecondary;

	private bool wandPressToMove;

	private VRTK_ControllerEvents.ButtonAlias wandCrouchButtonAlias = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

	private VRTK_ControllerEvents.Vector2AxisAlias axisAlias;

	private VRTK_ControllerEvents.ButtonAlias runButtonAlias;

	private GameObject smoothLocomotionEnabler;

	private bool primaryInitialized;

	private bool secondaryInitialized;

	public Vector2 LocomotionAxis
	{
		get
		{
			if (!primaryInitialized || ((bool)smoothLocomotionEnabler && !smoothLocomotionEnabler.activeInHierarchy))
			{
				return Vector2.zero;
			}
			(float horizontalTarget, float verticalTarget) primaryAxisTargets = GetPrimaryAxisTargets();
			float item = primaryAxisTargets.horizontalTarget;
			float item2 = primaryAxisTargets.verticalTarget;
			vectorPrimary = Vector2.SmoothDamp(vectorPrimary, new Vector2(item, item2), ref vectorVelocity, easing);
			return vectorPrimary;
		}
	}

	public bool SwimRequested { get; private set; }

	public bool JumpRequested { get; private set; }

	public bool CrouchRequested { get; private set; }

	public bool SittingRequested => false;

	public bool RunRequested
	{
		get
		{
			if (RunInputGivenMethod != null)
			{
				return RunInputGivenMethod();
			}
			return false;
		}
	}

	public bool ClimbLadderRequested => LocomotionAxis.sqrMagnitude > 0f;

	public Transform LadderClimbDirectionTransform => eventsPrimary?.gameObject.transform.Find("[telegrab]");

	public LocomotionInputWrapper.LeanDirection LeanValue => LocomotionInputWrapper.LeanDirection.NotLeaning;

	public bool IsLeanPressed => false;

	public VRTK_ControllerEvents.ButtonAlias CrouchButton { get; private set; }

	public LocomotionInputVr()
	{
		axisLerpFactor = 1f / (1f - movementDeadZone);
		if (TransmogrifyControllers.IsControllerReadyLeft)
		{
			OnControlsSet(SDK_BaseController.ControllerHand.Left);
		}
		if (TransmogrifyControllers.IsControllerReadyRight)
		{
			OnControlsSet(SDK_BaseController.ControllerHand.Right);
		}
		if (!TransmogrifyControllers.IsControllerReadyLeft || !TransmogrifyControllers.IsControllerReadyRight)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
		}
		GamePreferences.RegisterToPreferenceUpdated(Preferences.SmoothLocomotionEasing, OnEasingUpdated);
		OnEasingUpdated();
	}

	public void Dispose()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.SmoothLocomotionEasing, OnEasingUpdated);
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.WandPressToMove, OnWandPressToMovePreferenceUpdated);
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		if (!UnloadWatcher.isUnloading && isViveWandPrimary)
		{
			if (eventsPrimary != null)
			{
				eventsPrimary.UnsubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: true, OnWandTriggerClickedPrimary);
				eventsPrimary.UnsubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: false, OnWandTriggerUnclickedPrimary);
			}
			if (eventsSecondary != null)
			{
				eventsSecondary.UnsubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: true, OnWandTriggerClickedSecondary);
				eventsSecondary.UnsubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: false, OnWandTriggerUnclickedSecondary);
			}
		}
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand hand)
	{
		if (hand == SDK_BaseController.ControllerHand.Left)
		{
			if (primaryInitialized)
			{
				return;
			}
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			eventsPrimary = controllerLeftHand.GetComponent<VRTK_ControllerEvents>();
			usePrimary = controllerLeftHand.GetComponent<VRTK_InteractUse_DV>();
			smoothLocomotionEnabler = eventsPrimary.gameObject.GetComponentInChildren<PlayerInputTouchpadControl>(includeInactive: true).gameObject;
			VRTK_ControllerReference controllerReferenceRightHand = VRTK_DeviceFinder.GetControllerReferenceRightHand();
			ControllerType_DV controllerTypeDV = controllerReferenceRightHand.GetControllerTypeDV();
			SetupControllerSpecificInput(controllerTypeDV);
			if (controllerReferenceRightHand.IsWandOrUndefined())
			{
				eventsPrimary.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: true, OnWandTriggerClickedPrimary);
				eventsPrimary.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: false, OnWandTriggerUnclickedPrimary);
			}
			primaryInitialized = true;
		}
		else
		{
			if (secondaryInitialized)
			{
				return;
			}
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			eventsSecondary = controllerRightHand.GetComponent<VRTK_ControllerEvents>();
			useSecondary = controllerRightHand.GetComponent<VRTK_InteractUse_DV>();
			VRTK_ControllerReference controllerReferenceRightHand2 = VRTK_DeviceFinder.GetControllerReferenceRightHand();
			isViveWandSecondary = controllerReferenceRightHand2.IsWandOrUndefined();
			CrouchButton = (isViveWandSecondary ? wandCrouchButtonAlias : VRTK_ControllerEvents.ButtonAlias.Undefined);
			if (isViveWandSecondary)
			{
				eventsSecondary.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: true, OnWandTriggerClickedSecondary);
				eventsSecondary.SubscribeToButtonAliasEvent(VRTK_ControllerEvents.ButtonAlias.TriggerClick, startEvent: false, OnWandTriggerUnclickedSecondary);
				GamePreferences.RegisterToPreferenceUpdated(Preferences.WandPressToMove, OnWandPressToMovePreferenceUpdated);
			}
			secondaryInitialized = true;
		}
		if (TransmogrifyControllers.IsControllerReadyRight && TransmogrifyControllers.IsControllerReadyLeft)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
		}
	}

	private void OnWandPressToMovePreferenceUpdated()
	{
		wandPressToMove = GamePreferences.Get<bool>(Preferences.WandPressToMove);
	}

	private void SetupControllerSpecificInput(ControllerType_DV controllerType)
	{
		switch (controllerType)
		{
		case ControllerType_DV.WMR:
			runButtonAlias = VRTK_ControllerEvents.ButtonAlias.Undefined;
			RunInputGivenMethod = WmrRunInputGiven;
			axisAlias = VRTK_ControllerEvents.Vector2AxisAlias.TouchpadTwo;
			break;
		case ControllerType_DV.Undefined:
		case ControllerType_DV.ViveWand:
			runButtonAlias = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
			RunInputGivenMethod = WandRunInputGiven;
			axisAlias = VRTK_ControllerEvents.Vector2AxisAlias.Touchpad;
			isViveWandPrimary = true;
			OnWandPressToMovePreferenceUpdated();
			break;
		case ControllerType_DV.HPReverbG2:
			runButtonAlias = VRTK_ControllerEvents.ButtonAlias.TouchpadTwoPress;
			RunInputGivenMethod = GeneralRunInputGiven;
			axisAlias = VRTK_ControllerEvents.Vector2AxisAlias.TouchpadTwo;
			break;
		default:
			runButtonAlias = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
			RunInputGivenMethod = GeneralRunInputGiven;
			axisAlias = VRTK_ControllerEvents.Vector2AxisAlias.Touchpad;
			break;
		}
	}

	private void OnWandTriggerClickedPrimary(object _, ControllerInteractionEventArgs __)
	{
		GameObject gameObject = ((usePrimary != null) ? usePrimary.GetObjectFromGrab() : null);
		if (!(gameObject == null) && !(gameObject.GetComponent<ItemBase>() == null))
		{
			wandUseModifierPrimary = true;
		}
	}

	private void OnWandTriggerUnclickedPrimary(object _, ControllerInteractionEventArgs __)
	{
		wandUseModifierPrimary = false;
	}

	private void OnWandTriggerClickedSecondary(object _, ControllerInteractionEventArgs __)
	{
		GameObject gameObject = ((useSecondary != null) ? useSecondary.GetObjectFromGrab() : null);
		if (!(gameObject == null) && !(gameObject.GetComponent<ItemBase>() == null))
		{
			wandUseModifierSecondary = true;
		}
	}

	private void OnWandTriggerUnclickedSecondary(object _, ControllerInteractionEventArgs __)
	{
		wandUseModifierSecondary = false;
	}

	private void OnEasingUpdated()
	{
		easing = GamePreferences.Get<float>(Preferences.SmoothLocomotionEasing);
	}

	private (float horizontalTarget, float verticalTarget) GetPrimaryAxisTargets()
	{
		if (wandPressToMove && !eventsPrimary.IsButtonPressed(runButtonAlias))
		{
			return (horizontalTarget: 0f, verticalTarget: 0f);
		}
		Vector2 axis = eventsPrimary.GetAxis(axisAlias);
		TouchpadInputDirection touchDirectionBasedOnAngle = TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(axis, movementDeadZone);
		bool usable = usePrimary != null && usePrimary.ValidGrabObjectForUse();
		bool scrollable = usePrimary != null && usePrimary.ValidGrabObjectForScrolling();
		float num2;
		if (SideMovementAllowed(touchDirectionBasedOnAngle, usable, scrollable))
		{
			float num = Math.Abs(axis.x);
			num2 = ((num > movementDeadZone) ? ((float)Math.Sign(axis.x) * (num - movementDeadZone) * axisLerpFactor) : 0f);
		}
		else
		{
			num2 = 0f;
		}
		float num3;
		if (!ForwardMovementAllowed(touchDirectionBasedOnAngle, usable, scrollable))
		{
			num3 = 0f;
		}
		else
		{
			float num4 = Math.Abs(axis.y);
			num3 = ((num4 > movementDeadZone) ? ((float)Math.Sign(axis.y) * (num4 - movementDeadZone) * axisLerpFactor) : 0f);
		}
		hasMovementInput = num2 != 0f || num3 != 0f;
		return (horizontalTarget: num2, verticalTarget: num3);
	}

	private bool GetSecondaryAxisVerticalDown()
	{
		if (!secondaryInitialized)
		{
			return false;
		}
		if (CrouchButton != VRTK_ControllerEvents.ButtonAlias.Undefined && !eventsSecondary.IsButtonPressed(CrouchButton))
		{
			return false;
		}
		Vector2 axis = eventsSecondary.GetAxis(axisAlias);
		if (TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(axis) == TouchpadInputDirection.Down)
		{
			return axis.y < jumpAndCrouchDeadzone;
		}
		return false;
	}

	private bool SwimAllowed(bool useModified)
	{
		if (!secondaryInitialized)
		{
			return false;
		}
		if (useModified)
		{
			return false;
		}
		if (CrouchButton != VRTK_ControllerEvents.ButtonAlias.Undefined && !eventsSecondary.IsButtonPressed(CrouchButton))
		{
			return false;
		}
		Vector2 axis = eventsSecondary.GetAxis(axisAlias);
		if (TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(axis) == TouchpadInputDirection.Up)
		{
			return axis.y > jumpAndCrouchDeadzone;
		}
		return false;
	}

	public void UpdateFrame()
	{
		bool num = verticalSecondaryPointingDown;
		verticalSecondaryPointingDown = GetSecondaryAxisVerticalDown();
		bool flag = num != verticalSecondaryPointingDown;
		JumpRequested = false;
		SwimRequested = false;
		if (!secondaryInitialized)
		{
			return;
		}
		bool flag2 = (useSecondary != null && useSecondary.UseModified) || wandUseModifierSecondary;
		SwimRequested = SwimAllowed(flag2);
		if (verticalSecondaryPointingDown)
		{
			CrouchRequested = !flag2;
			elapsedCrouchToJumpTime += Time.deltaTime;
		}
		else if (flag)
		{
			if (elapsedCrouchToJumpTime.IsInRange(0f, jumpToCrouchThreshold))
			{
				JumpRequested = !flag2;
			}
			CrouchRequested = false;
			elapsedCrouchToJumpTime = 0f;
		}
	}

	private bool GeneralRunInputGiven()
	{
		bool wasRunInputPressed = runInputPressed;
		runInputPressed = eventsPrimary != null && eventsPrimary.IsButtonPressed(runButtonAlias);
		return RunToggleCheck(wasRunInputPressed);
	}

	private bool WmrRunInputGiven()
	{
		if (eventsSecondary != null)
		{
			Vector2 axis = eventsSecondary.GetAxis(axisAlias);
			if (TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(axis) == TouchpadInputDirection.Up)
			{
				return axis.y > wmrRunDeadzone;
			}
			return false;
		}
		return false;
	}

	private bool WandRunInputGiven()
	{
		bool wasRunInputPressed = runInputPressed;
		if (wandPressToMove)
		{
			if (wandUseModifierSecondary)
			{
				return false;
			}
			if (eventsSecondary == null || !eventsSecondary.IsButtonPressed(runButtonAlias))
			{
				return false;
			}
			TouchpadInputDirection touchDirectionBasedOnAngle = TouchpadInputInterpreter.GetTouchDirectionBasedOnAngle(eventsSecondary.GetAxis(axisAlias));
			runInputPressed = touchDirectionBasedOnAngle == TouchpadInputDirection.Up;
		}
		else
		{
			runInputPressed = !wandUseModifierPrimary && eventsPrimary != null && eventsPrimary.IsButtonPressed(runButtonAlias);
		}
		return RunToggleCheck(wasRunInputPressed);
	}

	private bool RunToggleCheck(bool wasRunInputPressed)
	{
		if (!runToggleAllowed)
		{
			isRunning = runInputPressed;
			return isRunning;
		}
		bool flag = wasRunInputPressed != runInputPressed;
		if (!isRunning)
		{
			if (!runInputPressed)
			{
				return false;
			}
			isRunning = hasMovementInput;
			runToggleStartTime = Time.timeSinceLevelLoad;
			return isRunning;
		}
		if (!hasMovementInput)
		{
			isRunning = false;
		}
		else if (flag)
		{
			if (runInputPressed)
			{
				isRunning = false;
			}
			else
			{
				isRunning = Time.timeSinceLevelLoad - runToggleStartTime < 0.2f;
			}
		}
		return isRunning;
	}

	private bool ForwardMovementAllowed(TouchpadInputDirection direction, bool usable, bool scrollable)
	{
		if (direction == TouchpadInputDirection.None)
		{
			return false;
		}
		if ((!(usePrimary != null) || !usePrimary.UseModified) && !wandUseModifierPrimary)
		{
			return true;
		}
		if (scrollable)
		{
			return false;
		}
		if (usable)
		{
			return direction != TouchpadInputDirection.Up;
		}
		return true;
	}

	private bool SideMovementAllowed(TouchpadInputDirection direction, bool usable, bool scrollable)
	{
		if (direction == TouchpadInputDirection.None)
		{
			return false;
		}
		if ((!(usePrimary != null) || !usePrimary.UseModified) && !wandUseModifierPrimary)
		{
			return true;
		}
		if (scrollable)
		{
			return false;
		}
		if (usable)
		{
			return direction != TouchpadInputDirection.Up;
		}
		return true;
	}

	public void ResetAxis(bool primary)
	{
		if (primary)
		{
			if (isViveWandPrimary && usePrimary.interactGrab.GetGrabbedObject() == null)
			{
				wandUseModifierPrimary = false;
			}
			return;
		}
		CrouchRequested = false;
		bool flag = (useSecondary != null && useSecondary.UseModified) || wandUseModifierSecondary;
		JumpRequested = !flag && secondaryInitialized && verticalSecondaryPointingDown && elapsedCrouchToJumpTime < jumpToCrouchThreshold;
		verticalSecondaryPointingDown = false;
		elapsedCrouchToJumpTime = 0f;
		if (isViveWandSecondary && useSecondary.interactGrab.GetGrabbedObject() == null)
		{
			wandUseModifierSecondary = false;
		}
	}

	public void SetCrouchToggle(bool on)
	{
	}

	public void SetRunToggle(bool on)
	{
		runToggleAllowed = on;
		isRunning = false;
		runToggleStartTime = 0f;
	}

	public void SetLeanToggle(bool on)
	{
	}

	public bool ResetLean()
	{
		return false;
	}
}
