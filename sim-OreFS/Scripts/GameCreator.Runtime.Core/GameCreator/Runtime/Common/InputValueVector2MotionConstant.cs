using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Constant Motion")]
	[Category("Usage/Constant Motion")]
	[Description("Keeps returning the last value after releasing the input until changed")]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	public class InputValueVector2MotionConstant : TInputValueVector2
	{
		private const float MIN_MAGNITUDE = 0.2f;

		[SerializeField]
		private float m_X;

		[SerializeField]
		private float m_Y = 1f;

		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Constant Motion");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2MotionConstant());
		}

		public override void OnStartup()
		{
			Enable();
		}

		public override void OnDispose()
		{
			Disable();
			InputAction?.Dispose();
		}

		public override Vector2 Read()
		{
			Vector2 result = new Vector2(m_X, m_Y);
			if (!(result.magnitude < 0.2f))
			{
				return result;
			}
			return Vector2.zero;
		}

		private void Enable()
		{
			InputAction?.Enable();
		}

		private void Disable()
		{
			InputAction?.Disable();
		}
	}
}
