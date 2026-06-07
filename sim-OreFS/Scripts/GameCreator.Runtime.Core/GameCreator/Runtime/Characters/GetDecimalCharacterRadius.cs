using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Radius")]
	[Category("Characters/Properties/Character Radius")]
	[Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]
	[Description("The Character's Radius value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Width", "Diameter" })]
	public class GetDecimalCharacterRadius : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCharacterRadius());

		public override string String => $"{m_Character} Radius";

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
			return character.Motion.Radius;
		}
	}
}
