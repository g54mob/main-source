using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Gamepad Timeout")]
	[Category("Gamepad/Gamepad Timeout")]
	[Description("When a gamepad or joystick key is pressed and held for a certain amount of seconds")]
	[Image(typeof(IconGamepad), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	[Keywords(new string[] { "Key", "Button", "Timeout", "Delay", "Duration", "Hold" })]
	public class InputValueButtonGamepadTimeout : TInputButton
	{
		private enum Mode
		{
			OnReleaseButton = 0,
			OnTimeout = 1
		}

		[SerializeField]
		private GamepadButton m_Button = GamepadButton.South;

		[SerializeField]
		private Mode m_Mode;

		[SerializeField]
		private float m_Duration = 0.5f;

		private bool IsFired { get; set; }

		private float PressTime { get; set; } = -999f;

		public static InputPropertyButton Create(GamepadButton button = GamepadButton.South)
		{
			return new InputPropertyButton(new InputValueButtonGamepadTimeout
			{
				m_Button = button
			});
		}

		public override void OnUpdate()
		{
			if (Gamepad.all.Count <= 0)
			{
				return;
			}
			if (Gamepad.current[m_Button].wasPressedThisFrame)
			{
				IsFired = false;
				PressTime = Time.unscaledTime;
				ExecuteEventStart();
			}
			if (m_Mode == Mode.OnTimeout && !IsFired && Gamepad.current[m_Button].isPressed && IsTimeout())
			{
				IsFired = true;
				ExecuteEventPerform();
			}
			if (!Gamepad.current[m_Button].wasReleasedThisFrame || IsFired)
			{
				return;
			}
			switch (m_Mode)
			{
			case Mode.OnReleaseButton:
				if (IsTimeout())
				{
					ExecuteEventPerform();
				}
				else
				{
					ExecuteEventCancel();
				}
				break;
			case Mode.OnTimeout:
				if (!IsFired)
				{
					ExecuteEventCancel();
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private bool IsTimeout()
		{
			return Time.unscaledTime - PressTime > m_Duration;
		}
	}
}
