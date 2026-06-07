using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Last Footstep")]
	[Category("Characters/Character Last Footstep")]
	[Description("Game Object bone that represents the Character's last foot step")]
	[Image(typeof(IconFootprint), ColorTheme.Type.Yellow)]
	public class GetGameObjectCharactersLastFootstep : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_Character = GetGameObjectPlayer.Create();

		public override string String => $"{m_Character} Footstep";

		public override GameObject Get(Args args)
		{
			Character character = m_Character.Get<Character>(args);
			if (!(character != null))
			{
				return null;
			}
			return character.Footsteps.LastFootstep;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectCharactersLastFootstep());
		}
	}
}
