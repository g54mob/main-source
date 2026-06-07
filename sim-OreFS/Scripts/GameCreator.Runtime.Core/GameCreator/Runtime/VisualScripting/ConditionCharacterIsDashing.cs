using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Dashing")]
	[Description("Returns true if the Character is dashing")]
	[Category("Characters/Navigation/Is Dashing")]
	[Keywords(new string[] { "Leap", "Blink", "Roll", "Flash" })]
	[Image(typeof(IconCharacterDash), ColorTheme.Type.Yellow)]
	public class ConditionCharacterIsDashing : TConditionCharacter
	{
		protected override string Summary => $"is Dashing {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Dash.IsDashing;
			}
			return false;
		}
	}
}
