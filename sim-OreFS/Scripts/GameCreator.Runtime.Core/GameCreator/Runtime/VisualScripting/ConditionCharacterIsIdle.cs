using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Is Idle")]
	[Description("Returns true if the Character is not moving")]
	[Category("Characters/Navigation/Is Idle")]
	[Keywords(new string[] { "Stay", "Quiet", "Still" })]
	[Image(typeof(IconCharacterIdle), ColorTheme.Type.Yellow)]
	public class ConditionCharacterIsIdle : TConditionCharacter
	{
		private const float MOVE_THRESHOLD = 0.1f;

		protected override string Summary => $"is Idle {m_Character}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return false;
			}
			return character.Driver.WorldMoveDirection.magnitude <= 0.1f;
		}
	}
}
