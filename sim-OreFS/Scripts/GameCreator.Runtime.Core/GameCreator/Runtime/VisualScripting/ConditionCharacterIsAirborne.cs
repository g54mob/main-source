using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Airborne")]
	[Description("Returns true if the Character not touching the ground")]
	[Category("Characters/Navigation/Is Airborne")]
	[Keywords(new string[] { "Fly", "Fall", "Flail", "Jump", "Float", "Suspend" })]
	[Image(typeof(IconFall), ColorTheme.Type.Yellow, typeof(OverlayArrowDown))]
	public class ConditionCharacterIsAirborne : TConditionCharacter
	{
		protected override string Summary => $"is On Air {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Driver.IsGrounded;
			}
			return false;
		}
	}
}
