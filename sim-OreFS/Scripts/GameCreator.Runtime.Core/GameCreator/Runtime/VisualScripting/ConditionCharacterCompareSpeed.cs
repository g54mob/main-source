using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Speed")]
	[Description("Returns true if the comparison between a number and the Character's speed is satisfied")]
	[Category("Characters/Properties/Compare Speed")]
	[Keywords(new string[] { "Velocity", "Travel", "Movement", "Walk", "Run", "Step" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareSpeed : TConditionCharacter
	{
		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(4.0);

		protected override string Summary => $"Speed of {m_Character} {m_Comparison}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return m_Comparison.Match(character.Motion.LinearSpeed, args);
			}
			return false;
		}
	}
}
