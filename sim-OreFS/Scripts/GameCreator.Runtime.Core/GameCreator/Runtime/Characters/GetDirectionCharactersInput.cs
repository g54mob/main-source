using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Input Direction")]
	[Category("Characters/Input Direction")]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("The desired input direction of the Character in world space")]
	public class GetDirectionCharactersInput : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionCharactersInput());

		public override string String => $"{m_Character} Input";

		public override Vector3 Get(Args args)
		{
			return GetDirection(args);
		}

		private Vector3 GetDirection(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return default(Vector3);
			}
			return character.Player.InputDirection;
		}
	}
}
