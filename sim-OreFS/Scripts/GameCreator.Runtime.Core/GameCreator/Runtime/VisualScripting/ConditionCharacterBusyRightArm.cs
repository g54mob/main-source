using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Right Arm Available")]
	[Description("Returns true if the Character's right arm is available to start a new action")]
	[Category("Characters/Busy/Is Right Arm Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing", "Hand", "Finger" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterBusyRightArm : TConditionCharacter
	{
		protected override string Summary => $"is Right Arm Available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.IsArmRightBusy;
			}
			return false;
		}
	}
}
