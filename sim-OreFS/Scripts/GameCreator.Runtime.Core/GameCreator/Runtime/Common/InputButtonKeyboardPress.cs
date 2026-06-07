using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Keyboard Press")]
	[Category("Keyboard/Keyboard Press")]
	[Description("When a keyboard key is pressed")]
	[Image(typeof(IconKey), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	[Keywords(new string[] { "Key", "Button", "Down" })]
	public class InputButtonKeyboardPress : TInputButton
	{
		[SerializeField]
		private Key m_Key = Key.Space;

		public static InputPropertyButton Create(Key key = Key.Space)
		{
			return new InputPropertyButton(new InputButtonKeyboardPress
			{
				m_Key = key
			});
		}

		public override void OnUpdate()
		{
			if (Keyboard.current != null && Keyboard.current[m_Key].wasPressedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}
	}
}
