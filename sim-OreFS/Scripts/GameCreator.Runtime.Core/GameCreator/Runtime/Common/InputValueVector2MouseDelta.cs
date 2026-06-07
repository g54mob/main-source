using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Delta")]
	[Category("Mouse/Mouse Delta")]
	[Description("The delta position from the last cursor position")]
	[Image(typeof(IconCursor), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Cursor", "Move", "Pan" })]
	public class InputValueVector2MouseDelta : TInputValueVector2
	{
		private enum MouseButton
		{
			Always = 0,
			PressingLeftButton = 1,
			PressingMiddleButton = 2,
			PressingRightButton = 3
		}

		[NonSerialized]
		private InputAction m_InputAction;

		[SerializeField]
		private MouseButton m_WhilePressing;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Mouse Delta", InputActionType.Value, "<Mouse>/delta");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2MouseDelta());
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
			Vector2 vector = InputAction?.ReadValue<Vector2>() ?? Vector2.zero;
			return m_WhilePressing switch
			{
				MouseButton.PressingLeftButton => Mouse.current.leftButton.isPressed ? vector : Vector2.zero, 
				MouseButton.PressingMiddleButton => Mouse.current.middleButton.isPressed ? vector : Vector2.zero, 
				MouseButton.PressingRightButton => Mouse.current.rightButton.isPressed ? vector : Vector2.zero, 
				_ => vector, 
			};
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
