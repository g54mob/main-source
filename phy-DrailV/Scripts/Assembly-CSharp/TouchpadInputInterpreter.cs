using System;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class TouchpadInputInterpreter : MonoBehaviour
{
	public delegate void TouchpadInputDirectionDelegate(TouchpadInputDirection direction, bool swiped, VRTK_ControllerReference controllerReference);

	public delegate void TouchpadPressedChangedDelegate(bool pressed);

	private TouchpadInputDirection previousJoystickDirection;

	private SDK_BaseController.ButtonTypes inputDevice;

	private VRTK_ControllerEvents.ButtonAlias pressButton;

	private VRTK_ControllerEvents controllerEvents;

	private static float deadZone = 0.4f;

	private bool wasJoystickPressed;

	private const float WAND_SWIPE_THRESHOLD = 0.25f;

	private const float WAND_SWIPE_TIME_WINDOW = 0.25f;

	private TouchpadInputDirection wandButtonClickDirection;

	private bool wasWandButtonPressed;

	private bool wasWandButtonTouched;

	private Vector2 touchStartCoords;

	private Vector2 previousTouchCoords;

	private float wandTouchStartTime;

	private VRTK_ControllerEvents.ButtonAlias touchButton;

	public Vector2 AxisValue => VRTK_SDK_Bridge.GetControllerAxis(inputDevice, VRTK_ControllerReference.GetControllerReference(base.gameObject));

	public bool IsTouchpad { get; private set; }

	public event TouchpadPressedChangedDelegate PressedChanged;

	public event TouchpadInputDirectionDelegate DirectionalInputGiven;

	public event TouchpadInputDirectionDelegate DelayedDirectionalInputGiven;

	public event TouchpadInputDirectionDelegate DirectionalInputNeutral;

	private void Awake()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Register(OnControlsSet);
		controllerEvents = GetComponent<VRTK_ControllerEvents>();
		base.enabled = false;
	}

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			if (wasJoystickPressed || wasWandButtonPressed)
			{
				this.PressedChanged?.Invoke(pressed: false);
			}
			if (previousJoystickDirection != TouchpadInputDirection.None)
			{
				this.DirectionalInputNeutral?.Invoke(previousJoystickDirection, swiped: true, VRTK_ControllerReference.GetControllerReference(base.gameObject));
				previousJoystickDirection = TouchpadInputDirection.None;
			}
			if (wandButtonClickDirection != TouchpadInputDirection.None)
			{
				this.DirectionalInputNeutral?.Invoke(wandButtonClickDirection, swiped: false, VRTK_ControllerReference.GetControllerReference(base.gameObject));
				wandButtonClickDirection = TouchpadInputDirection.None;
			}
			touchStartCoords = Vector3.zero;
			wasWandButtonPressed = false;
			wasJoystickPressed = false;
		}
	}

	private void OnDestroy()
	{
		SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
	}

	private void OnControlsSet(SDK_BaseController.ControllerHand hand)
	{
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
		if (controllerReference.hand == hand)
		{
			SetupDeviceSpecificControls.DeviceSpecificControlsSet.Unregister(OnControlsSet);
			switch (controllerReference.GetControllerTypeDV())
			{
			case ControllerType_DV.Undefined:
			case ControllerType_DV.ViveWand:
				IsTouchpad = true;
				inputDevice = SDK_BaseController.ButtonTypes.Touchpad;
				pressButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
				touchButton = VRTK_ControllerEvents.ButtonAlias.TouchpadTouch;
				break;
			case ControllerType_DV.ValveIndex:
			case ControllerType_DV.RiftTouch:
			case ControllerType_DV.QuestTouch:
			case ControllerType_DV.Cosmos:
				IsTouchpad = false;
				inputDevice = SDK_BaseController.ButtonTypes.Touchpad;
				pressButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
				break;
			case ControllerType_DV.WMR:
			case ControllerType_DV.HPReverbG2:
				IsTouchpad = false;
				inputDevice = SDK_BaseController.ButtonTypes.TouchpadTwo;
				pressButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
				break;
			}
			base.enabled = true;
		}
	}

	public static TouchpadInputDirection GetTouchDirectionBasedOnAngle(Vector2 currentAxis, bool ignoreDeadzone = false)
	{
		return GetTouchDirectionBasedOnAngle(currentAxis, ignoreDeadzone ? 0f : deadZone);
	}

	public static TouchpadInputDirection GetTouchDirectionBasedOnAngle(Vector2 currentAxis, float deadZone)
	{
		if (currentAxis.sqrMagnitude <= deadZone * deadZone || currentAxis == Vector2.zero)
		{
			return TouchpadInputDirection.None;
		}
		float num = Mathf.Atan2(currentAxis.y, currentAxis.x) * 57.29578f;
		num = 90f - num;
		if (num < 0f)
		{
			num += 360f;
		}
		if (num > 45f && num <= 135f)
		{
			return TouchpadInputDirection.Right;
		}
		if (num > 135f && num <= 225f)
		{
			return TouchpadInputDirection.Down;
		}
		if (num > 225f && num <= 315f)
		{
			return TouchpadInputDirection.Left;
		}
		return TouchpadInputDirection.Up;
	}

	private void LateUpdate()
	{
		if (IsTouchpad)
		{
			ProcessTouchpadInput();
		}
		else
		{
			ProcessJoystickInput();
		}
	}

	private void ProcessTouchpadInput()
	{
		Vector2 axisValue = AxisValue;
		bool flag = controllerEvents.IsButtonPressed(touchButton);
		bool flag2 = controllerEvents.IsButtonPressed(pressButton);
		bool flag3 = true;
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
		if (flag2 && !wasWandButtonPressed)
		{
			this.PressedChanged?.Invoke(pressed: true);
			wandButtonClickDirection = GetTouchDirectionBasedOnAngle(axisValue);
			if (wandButtonClickDirection != TouchpadInputDirection.None)
			{
				this.DirectionalInputGiven?.Invoke(wandButtonClickDirection, swiped: false, controllerReference);
				this.DelayedDirectionalInputGiven?.Invoke(wandButtonClickDirection, swiped: false, controllerReference);
			}
		}
		else if (wasWandButtonPressed && !flag2)
		{
			this.PressedChanged?.Invoke(pressed: false);
			this.DirectionalInputNeutral?.Invoke(wandButtonClickDirection, swiped: false, controllerReference);
			wandButtonClickDirection = TouchpadInputDirection.None;
			flag3 = false;
		}
		if (flag3)
		{
			if (flag && !wasWandButtonTouched)
			{
				touchStartCoords = axisValue;
				wandTouchStartTime = Time.timeSinceLevelLoad;
			}
			else if (wasWandButtonTouched && !flag)
			{
				Vector2 vector = previousTouchCoords - touchStartCoords;
				float num = Math.Abs(vector.x);
				float num2 = Math.Abs(vector.y);
				TouchpadInputDirection touchpadInputDirection = TouchpadInputDirection.None;
				if (num > 0.25f && num >= num2)
				{
					touchpadInputDirection = ((vector.x < 0f) ? TouchpadInputDirection.Left : TouchpadInputDirection.Right);
				}
				else if (num2 > 0.25f)
				{
					touchpadInputDirection = ((vector.y < 0f) ? TouchpadInputDirection.Down : TouchpadInputDirection.Up);
				}
				if (touchpadInputDirection != TouchpadInputDirection.None && Time.timeSinceLevelLoad - wandTouchStartTime < 0.25f)
				{
					this.DirectionalInputGiven?.Invoke(touchpadInputDirection, swiped: true, controllerReference);
					this.DelayedDirectionalInputGiven?.Invoke(touchpadInputDirection, swiped: true, controllerReference);
					this.DirectionalInputNeutral?.Invoke(touchpadInputDirection, swiped: true, controllerReference);
				}
				touchStartCoords = Vector3.zero;
			}
			wasWandButtonTouched = flag;
			previousTouchCoords = axisValue;
		}
		else
		{
			touchStartCoords = (previousTouchCoords = Vector3.zero);
			wasWandButtonTouched = false;
		}
		wasWandButtonPressed = flag2;
	}

	private void ProcessJoystickInput()
	{
		bool flag = pressButton != VRTK_ControllerEvents.ButtonAlias.Undefined && controllerEvents.IsButtonPressed(pressButton);
		VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(base.gameObject);
		if (flag != wasJoystickPressed)
		{
			this.PressedChanged?.Invoke(flag);
		}
		TouchpadInputDirection touchDirectionBasedOnAngle = GetTouchDirectionBasedOnAngle(AxisValue);
		if (previousJoystickDirection == touchDirectionBasedOnAngle)
		{
			return;
		}
		if (previousJoystickDirection != touchDirectionBasedOnAngle)
		{
			if (previousJoystickDirection == TouchpadInputDirection.None)
			{
				this.DirectionalInputGiven?.Invoke(touchDirectionBasedOnAngle, swiped: true, controllerReference);
				this.DelayedDirectionalInputGiven?.Invoke(touchDirectionBasedOnAngle, swiped: true, controllerReference);
			}
			else if (previousJoystickDirection != TouchpadInputDirection.None && touchDirectionBasedOnAngle == TouchpadInputDirection.None)
			{
				this.DirectionalInputNeutral?.Invoke(previousJoystickDirection, swiped: true, controllerReference);
			}
		}
		previousJoystickDirection = touchDirectionBasedOnAngle;
		wasJoystickPressed = flag;
	}
}
