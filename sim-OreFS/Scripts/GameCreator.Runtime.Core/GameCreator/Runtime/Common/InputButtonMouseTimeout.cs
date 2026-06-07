using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Timeout")]
	[Category("Mouse/Mouse Timeout")]
	[Description("When a mouse button is pressed and held for a certain amount of seconds")]
	[Image(typeof(IconMouse), ColorTheme.Type.Green, typeof(OverlayDot))]
	[Keywords(new string[] { "Timeout", "Delay", "Duration", "Hold" })]
	public class InputButtonMouseTimeout : TInputButtonMouse
	{
		private enum Mode
		{
			OnReleaseMouse = 0,
			OnTimeout = 1
		}

		[SerializeField]
		private Mode m_Mode;

		[SerializeField]
		private float m_Duration = 0.5f;

		private bool IsFired { get; set; }

		private float PressTime { get; set; } = -999f;

		public static InputPropertyButton Create(MouseButton button = MouseButton.Left)
		{
			return new InputPropertyButton(new InputButtonMouseTimeout
			{
				m_Button = button,
				m_Mode = Mode.OnReleaseMouse,
				m_Duration = 0.5f
			});
		}

		public override void OnUpdate()
		{
			if (base.WasPressedThisFrame)
			{
				IsFired = false;
				PressTime = Time.unscaledTime;
				ExecuteEventStart();
			}
			if (m_Mode == Mode.OnTimeout && !IsFired && base.IsPressed && IsTimeout())
			{
				IsFired = true;
				ExecuteEventPerform();
			}
			if (!base.WasReleasedThisFrame || IsFired)
			{
				return;
			}
			switch (m_Mode)
			{
			case Mode.OnReleaseMouse:
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
