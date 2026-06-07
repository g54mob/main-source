using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("WASD")]
	[Category("Keyboard/WASD")]
	[Description("Detects when the W, A, S and D keys are pressed")]
	[Image(typeof(IconWASD), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Move" })]
	public class InputValueVector2KeyboardWASD : TInputValueVector2
	{
		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("WASD");
					m_InputAction.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s")
						.With("Left", "<Keyboard>/a")
						.With("Right", "<Keyboard>/d");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2KeyboardWASD());
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
