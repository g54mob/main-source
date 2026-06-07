using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Terminal Velocity")]
	[Description("Returns true if the comparison between a number and the Character's terminal velocity is satisfied")]
	[Category("Characters/Properties/Terminal Velocity")]
	[Keywords(new string[] { "Max", "Fall", "Vertical", "Down" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareTerminalVelocity : TConditionCharacter
	{
		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(-52.0);

		protected override string Summary => $"Terminal Velocity of {m_Character} {m_Comparison}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null)
			{
				return false;
			}
			return m_Comparison.Match(character.Motion.TerminalVelocity, args);
		}
	}
}
