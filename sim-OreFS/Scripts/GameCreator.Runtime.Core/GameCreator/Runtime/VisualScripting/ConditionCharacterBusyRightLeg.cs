using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Right Leg Available")]
	[Description("Returns true if the Character's right leg is available to start a new action")]
	[Category("Characters/Busy/Is Right Leg Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing", "Foot", "Feet" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterBusyRightLeg : TConditionCharacter
	{
		protected override string Summary => $"is Right Leg Available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.IsLegRightBusy;
			}
			return false;
		}
	}
}
