using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Keyboard While Pressing")]
	[Category("Keyboard/Keyboard While Pressing")]
	[Description("While the specified keyboard key is being held down")]
	[Image(typeof(IconKey), ColorTheme.Type.Blue, typeof(OverlayDot))]
	[Keywords(new string[] { "Key", "Button", "Down", "Held", "Hold" })]
	public class InputButtonKeyboardWhilePressing : TInputButton
	{
		[SerializeField]
		private Key m_Key = Key.Space;

		public static InputPropertyButton Create(Key key = Key.Space)
		{
			return new InputPropertyButton(new InputButtonKeyboardWhilePressing
			{
				m_Key = key
			});
		}

		public override void OnUpdate()
		{
			if (Keyboard.current != null)
			{
				if (Keyboard.current[m_Key].wasPressedThisFrame)
				{
					ExecuteEventStart();
				}
				if (Keyboard.current[m_Key].IsPressed())
				{
					ExecuteEventPerform();
				}
			}
		}
	}
}
