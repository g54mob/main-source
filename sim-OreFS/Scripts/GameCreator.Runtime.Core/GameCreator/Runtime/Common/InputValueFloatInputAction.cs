using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Action (Number)")]
	[Category("Input System/Input Action (Number)")]
	[Description("When an Input Action asset with a numeric Value behavior changes")]
	[Image(typeof(IconBoltOutline), ColorTheme.Type.Blue)]
	[Keywords(new string[] { "Unity", "Asset", "Map" })]
	public class InputValueFloatInputAction : TInputValueFloat
	{
		[SerializeField]
		private InputActionFromAsset m_Input = new InputActionFromAsset();

		public InputAction InputAction => m_Input.InputAction;

		public override float Read()
		{
			return InputAction?.ReadValue<float>() ?? 0f;
		}
	}
}
