using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Moving")]
	[Description("Returns true if the Character is currently in an active moving phase")]
	[Category("Characters/Navigation/Is Moving")]
	[Keywords(new string[] { "Translate", "Towards", "Destination", "Target", "Follow", "Walk", "Run" })]
	[Image(typeof(IconCharacterRun), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	public class ConditionCharacterIsMoving : TConditionCharacter
	{
		private const float MOVE_THRESHOLD = 0.1f;

		protected override string Summary => $"is Moving {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return false;
			}
			return character.Driver.WorldMoveDirection.magnitude > 0.1f;
		}
	}
}
