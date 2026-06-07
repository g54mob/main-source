using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Keyboard Release")]
	[Category("Keyboard/Keyboard Release")]
	[Description("When a keyboard key is released")]
	[Image(typeof(IconKey), ColorTheme.Type.Yellow, typeof(OverlayArrowUp))]
	[Keywords(new string[] { "Key", "Button", "Up" })]
	public class InputButtonKeyboardRelease : TInputButton
	{
		[SerializeField]
		private Key m_Key = Key.Space;

		public static InputPropertyButton Create(Key key = Key.Space)
		{
			return new InputPropertyButton(new InputButtonKeyboardRelease
			{
				m_Key = key
			});
		}

		public override void OnUpdate()
		{
			if (Keyboard.current != null && Keyboard.current[m_Key].wasReleasedThisFrame)
			{
				ExecuteEventStart();
				ExecuteEventPerform();
			}
		}
	}
}
