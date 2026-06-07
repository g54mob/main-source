using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Are Arms Available")]
	[Description("Returns true if the Character's arms are available to start a new action")]
	[Category("Characters/Busy/Are Arms Available")]
	[Keywords(new string[] { "Occupied", "Available", "Free", "Doing", "Hand", "Finger" })]
	[Image(typeof(IconCharacter), ColorTheme.Type.Red)]
	public class ConditionCharacterBusyArms : TConditionCharacter
	{
		protected override string Summary => $"Arms available {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return !character.Busy.AreArmsBusy;
			}
			return false;
		}
	}
}
