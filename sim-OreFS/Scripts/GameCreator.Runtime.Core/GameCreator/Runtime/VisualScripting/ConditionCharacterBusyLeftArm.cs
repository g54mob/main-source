using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Left Arm Available")]
	[Description("Returns true if the Character's left arm is available to start a new action")]
	[Category("Characters/Busy/Is Left Arm Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing", "Hand", "Finger" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterBusyLeftArm : TConditionCharacter
	{
		protected override string Summary => $"is Left Arm Available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.IsArmLeftBusy;
			}
			return false;
		}
	}
}
