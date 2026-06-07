using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Busy")]
	[Description("Returns true if the Character doing an action that prevents from starting another one")]
	[Category("Characters/Busy/Is Busy")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterIsBusy : TConditionCharacter
	{
		protected override string Summary => $"is Busy {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Busy.IsBusy;
			}
			return false;
		}
	}
}
