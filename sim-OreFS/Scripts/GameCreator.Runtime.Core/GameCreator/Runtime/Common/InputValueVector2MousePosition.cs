using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Position")]
	[Category("Mouse/Mouse Position")]
	[Description("Every time the cursor moves")]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Cursor", "Location", "Move", "Pan" })]
	public class InputValueVector2MousePosition : TInputValueVector2
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Mouse Position", InputActionType.Value, "<Mouse>/position");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2MousePosition());
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
			return InputAction?.ReadValue<Vector2>() ?? Vector2.zero;
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
