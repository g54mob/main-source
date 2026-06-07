using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Scroll-Wheel Up")]
	[Category("Mouse/Mouse Scroll-Wheel Up")]
	[Description("The Mouse scroll-Wheel Up component")]
	[Image(typeof(IconScroll), ColorTheme.Type.Yellow, typeof(OverlayArrowUp))]
	[Keywords(new string[] { "Cursor", "Location", "Move", "Pan" })]
	public class InputValueFloatMouseScrollUp : TInputValueFloat
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Scroll-Wheel", InputActionType.Value, "<Mouse>/scroll/up");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueFloat Create()
		{
			return new InputPropertyValueFloat(new InputValueFloatMouseScroll());
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

		public override float Read()
		{
			return InputAction?.ReadValue<float>() ?? 0f;
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
