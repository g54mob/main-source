using System;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Scroll-Wheel")]
	[Category("Mouse/Mouse Scroll-Wheel")]
	[Description("The Mouse scroll-Wheel Y component")]
	[Image(typeof(IconScroll), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Cursor", "Location", "Move", "Pan" })]
	public class InputValueFloatMouseScroll : TInputValueFloat
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Scroll-Wheel", InputActionType.Value, "<Mouse>/scroll/y");
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
