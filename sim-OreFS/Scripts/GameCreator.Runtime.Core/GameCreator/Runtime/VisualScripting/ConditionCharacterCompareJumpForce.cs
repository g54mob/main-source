using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Compare Jump Force")]
	[Description("Returns true if the comparison between a number and the Character's jump force is satisfied")]
	[Category("Characters/Properties/Jump Force")]
	[Keywords(new string[] { "Hop", "Leap" })]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow)]
	public class ConditionCharacterCompareJumpForce : TConditionCharacter
	{
		[SerializeField]
		private CompareDouble m_Comparison = new CompareDouble(8.0);

		protected override string Summary => $"Jump Force of {m_Character} {m_Comparison}";

		protected override bool Run(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character != null)
			{
				return m_Comparison.Match(character.Motion.JumpForce, args);
			}
			return false;
		}
	}
}
