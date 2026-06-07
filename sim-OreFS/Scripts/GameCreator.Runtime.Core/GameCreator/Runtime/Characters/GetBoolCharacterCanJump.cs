using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Can Jump")]
	[Category("Characters/Can Jump")]
	[Image(typeof(IconCharacterJump), ColorTheme.Type.Yellow)]
	[Description("Returns true if the Character can perform a jump")]
	[Keywords(new string[] { "Character", "Hop" })]
	public class GetBoolCharacterCanJump : PropertyTypeGetBool
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolCharacterCanJump());

		public override string String => $"{m_Character} Can Jump";

		public override bool Get(Args args)
		{
			return m_Character.Get<Character>(args)?.Jump.CanJump() ?? false;
		}
	}
}
