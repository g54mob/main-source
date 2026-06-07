using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Controllable")]
	[Description("Returns true if the Player unit of the Character is controllable")]
	[Category("Characters/Properties/Is Controllable")]
	[Keywords(new string[] { "Control", "Character", "Player" })]
	[Image(typeof(IconBust), ColorTheme.Type.Green)]
	public class ConditionCharacterIsControllable : TConditionCharacter
	{
		protected override string Summary => $"is {m_Character} Controllable";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Player.IsControllable;
			}
			return false;
		}
	}
}
