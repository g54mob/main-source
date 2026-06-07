using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action (Vector2)")]
	[Category("Input System/Input Action (Vector2)")]
	[Description("When an Input Action asset with a Vector2 Value behavior changes")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Unity", "Asset", "Map" })]
	public class InputValueVector2InputAction : TInputValueVector2
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		public InputAction InputAction => m_Input.InputAction;

		public override Vector2 Read()
		{
			return InputAction?.ReadValue<Vector2>() ?? Vector2.zero;
		}
	}
}
