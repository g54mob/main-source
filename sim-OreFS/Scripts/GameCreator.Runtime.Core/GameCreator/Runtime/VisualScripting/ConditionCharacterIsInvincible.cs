using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Invincible")]
	[Description("Returns true if the Character is Invincible")]
	[Category("Characters/Combat/Is Invincible")]
	[Keywords(new string[] { "Invincibility", "Combat" })]
	[Image(typeof(IconDiamondSolid), ColorTheme.Type.Yellow)]
	public class ConditionCharacterIsInvincible : TConditionCharacter
	{
		protected override string Summary => $"is Invincible {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Combat.Invincibility.IsInvincible;
			}
			return false;
		}
	}
}
