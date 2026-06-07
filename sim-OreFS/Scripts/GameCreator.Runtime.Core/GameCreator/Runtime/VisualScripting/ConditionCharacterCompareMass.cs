using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Mass")]
	[Description("Returns true if the comparison between a number and the Character's mass is satisfied")]
	[Category("Characters/Properties/Compare Mass")]
	[Keywords(new string[] { "Weight" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareMass : TConditionCharacter
	{
		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(75.0);

		protected override string Summary => $"Mass of {m_Character} {m_Comparison}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return m_Comparison.Match(character.Motion.Mass, args);
			}
			return false;
		}
	}
}
