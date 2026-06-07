using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_TouchpadControl")]
	public class VRTK_TouchpadControl : VRTK_ObjectControl
	{
		[Header("Touchpad Control Settings")]
		[Tooltip("The axis to use for the direction coordinates.")]
		public VRTK_ControllerEvents.Vector2AxisAlias coordinateAxis = VRTK_ControllerEvents.Vector2AxisAlias.Touchpad;

		[Tooltip("An optional button that has to be engaged to allow the touchpad control to activate.")]
		public VRTK_ControllerEvents.ButtonAlias primaryActivationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadTouch;

		[Tooltip("An optional button that when engaged will activate the modifier on the touchpad control action.")]
		public VRTK_ControllerEvents.ButtonAlias actionModifierButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;

		[Tooltip("A deadzone threshold on the touchpad that will ignore input if the touch position is within the specified deadzone. Between `0f` and `1f`.")]
		public Vector2 axisDeadzone = new Vector2(0.2f, 0.2f);

		protected bool touchpadFirstChange;

		protected bool otherTouchpadControlEnabledState;

		protected bool otherTouchpadControlEnabledStateSet;

		protected VRTK_ControllerEvents.ButtonAlias coordniateButtonAlias;

		protected override void OnEnable()
		{
			base.OnEnable();
			touchpadFirstChange = true;
			otherTouchpadControlEnabledStateSet = false;
			coordniateButtonAlias = ((coordinateAxis == VRTK_ControllerEvents.Vector2AxisAlias.Touchpad) ? VRTK_ControllerEvents.ButtonAlias.TouchpadTouch : VRTK_ControllerEvents.ButtonAlias.TouchpadTwoTouch);
		}

		protected override void ControlFixedUpdate()
		{
			ModifierButtonActive();
			if (OutsideDeadzone(currentAxis.x, axisDeadzone.x) || currentAxis.x == 0f)
			{
				OnXAxisChanged(SetEventArguements(directionDevice.right, currentAxis.x, axisDeadzone.x));
			}
			if (OutsideDeadzone(currentAxis.y, axisDeadzone.y) || currentAxis.y == 0f)
			{
				OnYAxisChanged(SetEventArguements(directionDevice.forward, currentAxis.y, axisDeadzone.y));
			}
		}

		protected override VRTK_ObjectControl GetOtherControl()
		{
			GameObject gameObject = (VRTK_DeviceFinder.IsControllerLeftHand(base.gameObject) ? VRTK_DeviceFinder.GetControllerRightHand() : VRTK_DeviceFinder.GetControllerLeftHand());
			if (gameObject != null)
			{
				return gameObject.GetComponentInChildren<VRTK_TouchpadControl>();
			}
			return null;
		}

		protected override void SetListeners(bool state)
		{
			if (!(controllerEvents != null))
			{
				return;
			}
			if (state)
			{
				switch (coordinateAxis)
				{
				case VRTK_ControllerEvents.Vector2AxisAlias.Touchpad:
					controllerEvents.TouchpadAxisChanged += TouchpadAxisChanged;
					controllerEvents.TouchpadTouchEnd += TouchpadTouchEnd;
					break;
				case VRTK_ControllerEvents.Vector2AxisAlias.TouchpadTwo:
					controllerEvents.TouchpadTwoAxisChanged += TouchpadAxisChanged;
					controllerEvents.TouchpadTwoTouchEnd += TouchpadTouchEnd;
					break;
				}
			}
			else
			{
				switch (coordinateAxis)
				{
				case VRTK_ControllerEvents.Vector2AxisAlias.Touchpad:
					controllerEvents.TouchpadAxisChanged -= TouchpadAxisChanged;
					controllerEvents.TouchpadTouchEnd -= TouchpadTouchEnd;
					break;
				case VRTK_ControllerEvents.Vector2AxisAlias.TouchpadTwo:
					controllerEvents.TouchpadTwoAxisChanged -= TouchpadAxisChanged;
					controllerEvents.TouchpadTwoTouchEnd -= TouchpadTouchEnd;
					break;
				}
			}
		}

		protected override bool IsInAction()
		{
			if (ValidPrimaryButton())
			{
				return TouchpadTouched();
			}
			return false;
		}

		protected virtual bool OutsideDeadzone(float axisValue, float deadzoneThreshold)
		{
			if (!(axisValue > deadzoneThreshold))
			{
				return axisValue < 0f - deadzoneThreshold;
			}
			return true;
		}

		protected virtual bool ValidPrimaryButton()
		{
			if (controllerEvents != null)
			{
				if (primaryActivationButton != VRTK_ControllerEvents.ButtonAlias.Undefined)
				{
					return controllerEvents.IsButtonPressed(primaryActivationButton);
				}
				return true;
			}
			return false;
		}

		protected virtual void ModifierButtonActive()
		{
			modifierActive = controllerEvents != null && actionModifierButton != VRTK_ControllerEvents.ButtonAlias.Undefined && controllerEvents.IsButtonPressed(actionModifierButton);
		}

		protected virtual bool TouchpadTouched()
		{
			if (controllerEvents != null)
			{
				return controllerEvents.IsButtonPressed(coordniateButtonAlias);
			}
			return false;
		}

		protected virtual void TouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
		{
			Vector2 vector = ((coordinateAxis == VRTK_ControllerEvents.Vector2AxisAlias.Touchpad) ? e.touchpadAxis : e.touchpadTwoAxis);
			if (touchpadFirstChange && otherObjectControl != null && disableOtherControlsOnActive && vector != Vector2.zero)
			{
				otherTouchpadControlEnabledState = otherObjectControl.enabled;
				otherTouchpadControlEnabledStateSet = true;
				otherObjectControl.enabled = false;
			}
			currentAxis = (ValidPrimaryButton() ? vector : Vector2.zero);
			if (currentAxis != Vector2.zero)
			{
				touchpadFirstChange = false;
			}
		}

		protected virtual void TouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
		{
			if (otherTouchpadControlEnabledStateSet && otherObjectControl != null && disableOtherControlsOnActive)
			{
				otherObjectControl.enabled = otherTouchpadControlEnabledState;
			}
			currentAxis = Vector2.zero;
			touchpadFirstChange = true;
		}
	}
}
