using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Left Leg Available")]
	[Description("Returns true if the Character's left leg is available to start a new action")]
	[Category("Characters/Busy/Is Left Leg Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing", "Foot", "Feet" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterBusyLeftLeg : TConditionCharacter
	{
		protected override string Summary => $"is Left Leg Available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.IsLegLeftBusy;
			}
			return false;
		}
	}
}
