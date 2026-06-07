using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Jump Force")]
	[Category("Characters/Navigation/Jump Force")]
	[Image(typeof(IconCharacterJump), ColorTheme.Type.Yellow)]
	[Description("The Character's Jump Force value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Hop", "Elevate", "Impulse" })]
	public class GetDecimalCharactersJumpForce : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCharactersJumpForce());

		public override string String => $"{m_Character} Jump Force";

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
			return character.Motion.JumpForce;
		}
	}
}
