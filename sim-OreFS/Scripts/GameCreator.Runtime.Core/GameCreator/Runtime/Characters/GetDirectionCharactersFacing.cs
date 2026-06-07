using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Facing Direction")]
	[Category("Characters/Facing Direction")]
	[Image(typeof(IconBust), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("The Character's forward facing direction in world space")]
	public class GetDirectionCharactersFacing : PropertyTypeGetDirection
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionCharactersFacing());

		public override string String => $"{m_Character} Direction";

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
			return character.transform.forward;
		}
	}
}
