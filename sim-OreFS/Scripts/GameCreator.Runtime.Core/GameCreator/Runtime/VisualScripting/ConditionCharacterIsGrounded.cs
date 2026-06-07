using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Grounded")]
	[Description("Returns true if the Character touching the floor")]
	[Category("Characters/Navigation/Is Grounded")]
	[Keywords(new string[] { "Floor", "Stand", "Land" })]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Yellow, typeof(OverlayBar))]
	public class ConditionCharacterIsGrounded : TConditionCharacter
	{
		protected override string Summary => $"is Grounded {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return character.Driver.IsGrounded;
			}
			return false;
		}
	}
}
