using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Player")]
	[Description("Returns true if the Character is marked as a Player")]
	[Category("Characters/Properties/Is Player")]
	[Keywords(new string[] { "Control", "Character" })]
	[Image(typeof(IconBust), ColorTheme.Type.Green)]
	public class ConditionCharacterIsPlayer : TConditionCharacter
	{
		protected override string Summary => $"is Player {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.IsPlayer;
			}
			return false;
		}
	}
}
