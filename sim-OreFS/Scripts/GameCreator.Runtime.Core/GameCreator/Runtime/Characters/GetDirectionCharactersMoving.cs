using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Moving Direction")]
	[Category("Characters/Moving Direction")]
	[Image(typeof(IconCharacterWalk), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("The Character's moving direction in world space")]
	public class GetDirectionCharactersMoving : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionCharactersMoving());

		public override string String => $"{m_Character} Move";

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
			return character.Driver.WorldMoveDirection;
		}
	}
}
