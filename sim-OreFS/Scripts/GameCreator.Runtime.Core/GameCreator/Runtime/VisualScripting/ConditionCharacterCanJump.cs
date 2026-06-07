using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Mass")]
	[Description("Returns true if the character has the Can Jump property set to true")]
	[Category("Characters/Properties/Can Jump")]
	[Keywords(new string[] { "Active", "Enabled", "Leap", "Hop" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCanJump : TConditionCharacter
	{
		protected override string Summary => $"can Jump {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Motion.CanJump;
			}
			return false;
		}
	}
}
