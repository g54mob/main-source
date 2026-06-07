using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Current Velocity")]
	[Category("Characters/Navigation/Current Velocity")]
	[Image(typeof(IconCharacterRun), ColorTheme.Type.Blue, typeof(OverlayArrowRight))]
	[Description("The current velocity at which the Character is moving")]
	[Keywords(new string[] { "Float", "Decimal", "Double" })]
	public class GetDecimalCharactersCurrentVelocity : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalCharactersCurrentVelocity());

		public override string String => $"{m_Character} Velocity";

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
			return character.Driver.WorldMoveDirection.magnitude;
		}
	}
}
