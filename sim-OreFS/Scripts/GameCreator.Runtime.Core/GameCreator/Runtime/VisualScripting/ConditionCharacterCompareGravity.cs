using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Gravity")]
	[Description("Returns true if the comparison between a number and the Character's gravity is satisfied")]
	[Category("Characters/Properties/Compare Gravity")]
	[Keywords(new string[] { "Force", "Vertical" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareGravity : TConditionCharacter
	{
		private enum Mode
		{
			Average = 0,
			GravityUpwards = 1,
			GravityDownwards = 2
		}

		[SerializeField]
		private Mode m_Mode;

		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(2.0);

		protected override string Summary => string.Format("{0}Gravity of {1} {2}", m_Mode switch
		{
			Mode.Average => string.Empty, 
			Mode.GravityUpwards => "Upwards ", 
			Mode.GravityDownwards => "Downwards ", 
			_ => throw new ArgumentOutOfRangeException(), 
		}, m_Character, m_Comparison);

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			float num = m_Mode switch
			{
				Mode.Average => (character.Motion.GravityUpwards + character.Motion.GravityDownwards) / 2f, 
				Mode.GravityUpwards => character.Motion.GravityUpwards, 
				Mode.GravityDownwards => character.Motion.GravityDownwards, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			if (character != null)
			{
				return m_Comparison.Match(num, args);
			}
			return false;
		}
	}
}
