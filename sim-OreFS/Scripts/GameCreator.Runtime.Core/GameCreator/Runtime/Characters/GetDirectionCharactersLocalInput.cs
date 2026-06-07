using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Local Input Direction")]
	[Category("Characters/Local Input Direction")]
	[Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("The raw desired input direction of the Character in local space")]
	public class GetDirectionCharactersLocalInput : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionCharactersLocalInput());

		public override string String => $"{m_Character} Local Input";

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
			return character.Player.LocalInputDirection;
		}
	}
}
