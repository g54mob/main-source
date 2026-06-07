using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Is Player")]
	[Category("Characters/Is Player")]
	[Image(typeof(IconPlayer), ColorTheme.Type.Green)]
	[Description("Returns true if the Character is identified as the Player")]
	[Keywords(new string[] { "Character", "Controllable" })]
	public class GetBoolCharacterIsPlayer : PropertyTypeGetBool
	{
		[SerializeField]
		protected PropertyGetGameObject m_Character = GetGameObjectSelf.Create();

		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolCharacterIsPlayer());

		public override string String => $"{m_Character} is Player";

		public override bool Get(Args args)
		{
			return m_Character.Get<Character>(args)?.IsPlayer ?? false;
		}
	}
}
