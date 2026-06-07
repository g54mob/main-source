using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Are Legs Available")]
	[Description("Returns true if the Character's legs are available to start a new action")]
	[Category("Characters/Busy/Are Legs Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing", "Foot", "Feet" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterBusyLegs : TConditionCharacter
	{
		protected override string Summary => $"Legs Available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.AreLegsBusy;
			}
			return false;
		}
	}
}
