using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Angular Speed")]
	[Category("Characters/Navigation/Angular Speed")]
	[Image(typeof(IconRotationYaw), ColorTheme.Type.Yellow)]
	[Description("The Character's Angular Speed value")]
	[Keywords(new string[] { "Float", "Decimal", "Double", "Rotation", "Look" })]
	public class GetDecimalCharactersAngularSpeed : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCharactersAngularSpeed());

		public override string String => $"{m_Character} Angular Speed";

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
			return character.Motion.AngularSpeed;
		}
	}
}
