using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Humanoid")]
	[Description("Returns true if the Character has a humanoid model")]
	[Category("Characters/Busy/Is Humanoid")]
	[Keywords(new string[] { "Human", "Biped" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Green)]
	public class ConditionCharacterIsHumanoid : TConditionCharacter
	{
		protected override string Summary => $"is Humanoid {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Animim.Animator.isHuman;
			}
			return false;
		}
	}
}
