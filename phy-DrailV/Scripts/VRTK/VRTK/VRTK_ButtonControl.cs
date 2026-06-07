using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_ButtonControl")]
	public class VRTK_ButtonControl : VRTK_ObjectControl
	{
		[Header("Button Control Settings")]
		[Tooltip("The button to set the y axis to +1.")]
		public VRTK_ControllerEvents.ButtonAlias forwardButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;

		[Tooltip("The button to set the y axis to -1.")]
		public VRTK_ControllerEvents.ButtonAlias backwardButton;

		[Tooltip("The button to set the x axis to -1.")]
		public VRTK_ControllerEvents.ButtonAlias leftButton;

		[Tooltip("The button to set the x axis to +1.")]
		public VRTK_ControllerEvents.ButtonAlias rightButton;

		protected bool forwardPressed;

		protected bool backwardPressed;

		protected bool leftPressed;

		protected bool rightPressed;

		protected VRTK_ControllerEvents.ButtonAlias subscribedForwardButton;

		protected VRTK_ControllerEvents.ButtonAlias subscribedBackwardButton;

		protected VRTK_ControllerEvents.ButtonAlias subscribedLeftButton;

		protected VRTK_ControllerEvents.ButtonAlias subscribedRightButton;

		protected Vector2 axisDeadzone = Vector2.zero;

		protected override void Update()
		{
			base.Update();
			if (forwardButton != subscribedForwardButton || backwardButton != subscribedBackwardButton || leftButton != subscribedLeftButton || rightButton != subscribedRightButton)
			{
				SetListeners(state: true);
			}
		}

		protected override void ControlFixedUpdate()
		{
			float x = (leftPressed ? (-1f) : (rightPressed ? 1f : 0f));
			float y = (forwardPressed ? 1f : (backwardPressed ? (-1f) : 0f));
			currentAxis = new Vector2(x, y);
			if (currentAxis.x != 0f)
			{
				OnXAxisChanged(SetEventArguements(directionDevice.right, currentAxis.x, axisDeadzone.x));
			}
			if (currentAxis.y != 0f)
			{
				OnYAxisChanged(SetEventArguements(directionDevice.forward, currentAxis.y, axisDeadzone.y));
			}
		}

		protected override VRTK_ObjectControl GetOtherControl()
		{
			GameObject gameObject = (VRTK_DeviceFinder.IsControllerLeftHand(base.gameObject) ? VRTK_DeviceFinder.GetControllerRightHand() : VRTK_DeviceFinder.GetControllerLeftHand());
			if ((bool)gameObject)
			{
				return gameObject.GetComponentInChildren<VRTK_ButtonControl>();
			}
			return null;
		}

		protected override void SetListeners(bool state)
		{
			SetDirectionListener(state, forwardButton, ref subscribedForwardButton, ForwardButtonPressed, ForwardButtonReleased);
			SetDirectionListener(state, backwardButton, ref subscribedBackwardButton, BackwardButtonPressed, BackwardButtonReleased);
			SetDirectionListener(state, leftButton, ref subscribedLeftButton, LeftButtonPressed, LeftButtonReleased);
			SetDirectionListener(state, rightButton, ref subscribedRightButton, RightButtonPressed, RightButtonReleased);
		}

		protected override bool IsInAction()
		{
			if (!forwardPressed && !backwardPressed && !leftPressed)
			{
				return rightPressed;
			}
			return true;
		}

		protected virtual void SetDirectionListener(bool state, VRTK_ControllerEvents.ButtonAlias directionButton, ref VRTK_ControllerEvents.ButtonAlias subscribedDirectionButton, ControllerInteractionEventHandler pressCallback, ControllerInteractionEventHandler releaseCallback)
		{
			if ((bool)controllerEvents)
			{
				if (subscribedDirectionButton != VRTK_ControllerEvents.ButtonAlias.Undefined && (!state || directionButton == VRTK_ControllerEvents.ButtonAlias.Undefined || directionButton != subscribedDirectionButton))
				{
					controllerEvents.UnsubscribeToButtonAliasEvent(subscribedDirectionButton, startEvent: true, pressCallback);
					controllerEvents.UnsubscribeToButtonAliasEvent(subscribedDirectionButton, startEvent: false, releaseCallback);
					subscribedDirectionButton = VRTK_ControllerEvents.ButtonAlias.Undefined;
				}
				if (state && directionButton != VRTK_ControllerEvents.ButtonAlias.Undefined && directionButton != subscribedDirectionButton)
				{
					controllerEvents.SubscribeToButtonAliasEvent(directionButton, startEvent: true, pressCallback);
					controllerEvents.SubscribeToButtonAliasEvent(directionButton, startEvent: false, releaseCallback);
					subscribedDirectionButton = directionButton;
				}
			}
		}

		protected virtual void ForwardButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			forwardPressed = true;
			backwardPressed = false;
		}

		protected virtual void ForwardButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			forwardPressed = false;
		}

		protected virtual void BackwardButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			backwardPressed = true;
			forwardPressed = false;
		}

		protected virtual void BackwardButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			backwardPressed = false;
		}

		protected virtual void LeftButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			leftPressed = true;
			rightPressed = false;
		}

		protected virtual void LeftButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			leftPressed = false;
		}

		protected virtual void RightButtonPressed(object sender, ControllerInteractionEventArgs e)
		{
			rightPressed = true;
			leftPressed = false;
		}

		protected virtual void RightButtonReleased(object sender, ControllerInteractionEventArgs e)
		{
			rightPressed = false;
		}
	}
}
