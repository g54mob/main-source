using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Poise Ratio")]
	[Category("Characters/Combat/Poise Ratio")]
	[Image(typeof(IconShieldOutline), ColorTheme.Type.Yellow)]
	[Description("The Character's Poise ratio between the current value and its maximum")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Poise" })]
	public class GetDecimalCharacterPoiseRatio : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Poise Ratio";

		public override double Get(Args args)
		{
			return GetValue(args);
		}

		private float GetValue(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return 0f;
			}
			return character.Combat.Poise.Ratio;
		}
	}
}
