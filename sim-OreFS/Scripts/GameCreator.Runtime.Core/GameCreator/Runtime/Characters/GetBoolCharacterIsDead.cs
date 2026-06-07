using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Is Dead")]
	[Category("Characters/Is Dead")]
	[Image(typeof(IconSkull), ColorTheme.Type.Red)]
	[Description("Returns true if the Character is dead")]
	[Keywords(new string[] { "Character", "Die" })]
	public class GetBoolCharacterIsDead : PropertyTypeGetBool
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolCharacterIsDead());

		public override string String => $"{m_Character} is Dead";

		public override bool Get(Args args)
		{
			return m_Character.Get<Character>(args)?.IsDead ?? false;
		}
	}
}
