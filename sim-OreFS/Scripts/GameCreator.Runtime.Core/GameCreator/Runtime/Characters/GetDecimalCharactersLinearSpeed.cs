using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Linear Speed")]
	[Category("Characters/Navigation/Linear Speed")]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Yellow)]
	[Description("The Character's Linear Speed value")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalCharactersLinearSpeed : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCharactersLinearSpeed());

		public override string String => $"{m_Character} Linear Speed";

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
			return character.Motion.LinearSpeed;
		}
	}
}
