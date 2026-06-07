using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Defense Maximum")]
	[Category("Characters/Combat/Defense Maximum")]
	[Image(typeof(IconShieldSolid), ColorTheme.Type.Yellow)]
	[Description("The Character's maximum Defense value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Block", "Shield" })]
	public class GetDecimalCharacterDefenseMaximum : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Max Defense";

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
			return character.Combat.MaximumDefense;
		}
	}
}
