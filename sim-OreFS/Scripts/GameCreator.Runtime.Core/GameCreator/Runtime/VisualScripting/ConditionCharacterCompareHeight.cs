using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Height")]
	[Description("Returns true if the comparison between a number and the Character's height is satisfied")]
	[Category("Characters/Properties/Compare Height")]
	[Keywords(new string[] { "Length", "Long" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareHeight : TConditionCharacter
	{
		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(-9.8100004196167);

		protected override string Summary => $"Height of {m_Character} {m_Comparison}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return m_Comparison.Match(character.Motion.Height, args);
			}
			return false;
		}
	}
}
