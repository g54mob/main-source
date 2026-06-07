using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Keyboard Timeout")]
	[Category("Keyboard/Keyboard Timeout")]
	[Description("When a keyboard key is pressed and held for a certain amount of seconds")]
	[Image(typeof(IconKey), ColorTheme.Type.Yellow, typeof(OverlayDot))]
	[Keywords(new string[] { "Key", "Button", "Timeout", "Delay", "Duration", "Hold" })]
	public class InputButtonKeyboardTimeout : TInputButton
	{
		private enum Mode
		{
			OnReleaseKey = 0,
			OnTimeout = 1
		}

		[SerializeField]
		private Key m_Key = Key.Space;

		[SerializeField]
		private Mode m_Mode;

		[SerializeField]
		private float m_Duration = 0.5f;

		private bool IsFired { get; set; }

		private float PressTime { get; set; } = -999f;

		public static InputPropertyButton Create(Key key = Key.Space)
		{
			return new InputPropertyButton(new InputButtonKeyboardTimeout
			{
				m_Key = key
			});
		}

		public override void OnUpdate()
		{
			if (Keyboard.current == null)
			{
				return;
			}
			if (Keyboard.current[m_Key].wasPressedThisFrame)
			{
				IsFired = false;
				PressTime = Time.unscaledTime;
				ExecuteEventStart();
			}
			if (m_Mode == Mode.OnTimeout && !IsFired && Keyboard.current[m_Key].isPressed && IsTimeout())
			{
				IsFired = true;
				ExecuteEventPerform();
			}
			if (!Keyboard.current[m_Key].wasReleasedThisFrame || IsFired)
			{
				return;
			}
			switch (m_Mode)
			{
			case Mode.OnReleaseKey:
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
