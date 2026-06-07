using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Is Alive")]
	[Category("Characters/Is Alive")]
	[Image(typeof(IconSkull), ColorTheme.Type.Green)]
	[Description("Returns true if the Character is alive")]
	[Keywords(new string[] { "Character", "Living", "Life" })]
	public class GetBoolCharacterIsAlive : PropertyTypeGetBool
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolCharacterIsAlive());

		public override string String => $"{m_Character} is Alive";

		public override bool Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if ((object)character == null)
			{
				return false;
			}
			return !character.IsDead;
		}
	}
}
