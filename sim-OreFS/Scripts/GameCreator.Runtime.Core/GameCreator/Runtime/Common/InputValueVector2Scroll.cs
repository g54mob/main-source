using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Mouse Scroll")]
	[Category("Mouse/Mouse Scroll")]
	[Description("Every time the scroll wheel is used")]
	[Image(typeof(IconScroll), ColorTheme.Type.Yellow)]
	[Keywords(new string[] { "Cursor", "Button", "Up" })]
	public class InputValueVector2Scroll : TInputValueVector2
	{
		private enum Direction
		{
			Both = 0,
			Up = 1,
			Down = 2
		}

		[SerializeField]
		private Direction m_Direction;

		[NonSerialized]
		private InputAction m_InputAction;

		public InputAction InputAction
		{
			get
			{
				if (m_InputAction == null)
				{
					m_InputAction = new InputAction("Zoom", InputActionType.Value, "<Mouse>/scroll");
				}
				return m_InputAction;
			}
		}

		public static InputPropertyValueVector2 Create()
		{
			return new InputPropertyValueVector2(new InputValueVector2Scroll());
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
			return m_Direction switch
			{
				Direction.Both => vector, 
				Direction.Up => new Vector2(Math.Max(vector.x, 0f), Math.Max(vector.y, 0f)), 
				Direction.Down => new Vector2(Math.Min(vector.x, 0f), Math.Min(vector.y, 0f)), 
				_ => throw new ArgumentOutOfRangeException(), 
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
