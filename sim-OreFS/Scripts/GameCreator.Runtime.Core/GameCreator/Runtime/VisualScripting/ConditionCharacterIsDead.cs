using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Dead")]
	[Description("Returns true if the character has been killed")]
	[Category("Characters/Properties/Is Dead")]
	[Keywords(new string[] { "Kill", "Kaput" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterIsDead : TConditionCharacter
	{
		protected override string Summary => $"is Dead {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.IsDead;
			}
			return false;
		}
	}
}
