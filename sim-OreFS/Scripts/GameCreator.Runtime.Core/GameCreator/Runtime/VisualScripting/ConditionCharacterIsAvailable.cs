using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Available")]
	[Description("Returns true if the Character is not doing any action and is free to start one")]
	[Category("Characters/Busy/Is Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterIsAvailable : TConditionCharacter
	{
		protected override string Summary => $"is Available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.IsBusy;
			}
			return false;
		}
	}
}
