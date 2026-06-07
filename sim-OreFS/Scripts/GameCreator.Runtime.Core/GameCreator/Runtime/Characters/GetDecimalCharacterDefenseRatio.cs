using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Defense Ratio")]
	[Category("Characters/Combat/Defense Ratio")]
	[Image(typeof(IconShieldSolid), ColorTheme.Type.Yellow)]
	[Description("The Character's Defense ratio value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Block", "Shield" })]
	public class GetDecimalCharacterDefenseRatio : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Defense Ratio";

		public override double Get(Args args)
		{
			return GetValue(args);
		}

		private float GetValue(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (character == null || character.Combat.MaximumDefense <= 0f)
			{
				return 0f;
			}
			return Mathf.Clamp01(character.Combat.CurrentDefense / character.Combat.MaximumDefense);
		}
	}
}
