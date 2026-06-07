using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Scroll-Wheel Down")]
	[Category("Mouse/Mouse Scroll-Wheel Down")]
	[Description("The Mouse scroll-Wheel Down component")]
	[Image(typeof(IconScroll), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	[Keywords(new string[] { "Cursor", "Location", "Move", "Pan" })]
	public class InputValueFloatMouseScrollDown : TInputValueFloat
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Scroll-Wheel", InputActionType.Value, "<Mouse>/scroll/down");
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
