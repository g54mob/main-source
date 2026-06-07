using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Height")]
	[Category("Characters/Properties/Character Height")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Description("The Character's Height value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Up", "Size" })]
	public class GetDecimalCharacterHeight : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCharacterHeight());

		public override string String => $"{m_Character} Height";

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
			return character.Motion.Height;
		}
	}
}
