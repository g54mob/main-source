using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Radius")]
	[Description("Returns true if the comparison between a number and the Character's radius is satisfied")]
	[Category("Characters/Properties/Compare Radius")]
	[Keywords(new string[] { "Diameter", "Width", "Fat", "Skin", "Space" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareRadius : TConditionCharacter
	{
		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(0.5);

		protected override string Summary => $"Radius of {m_Character} {m_Comparison}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return m_Comparison.Match(character.Motion.Radius, args);
			}
			return false;
		}
	}
}
