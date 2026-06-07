using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Character Target")]
	[Category("Characters/Combat/Character Target")]
	[Description("Game Object targeted by the specified Character")]
	[Image(typeof(IconBullsEye), ColorTheme.Type.Yellow)]
	public class GetGameObjectCharacterTarget : PropertyTypeGetGameObject
	{
		[SerializeField]
		private PropertyGetGameObject m_From = GetGameObjectPlayer.Create();

		public override string String => $"{m_From} Target";

		public override GameObject Get(Args args)
		{
			Character character = m_From.Get<Character>(args);
			if (!(character != null))
			{
				return null;
			}
			return character.Combat.Targets.Primary;
		}

		public override GameObject Get(GameObject gameObject)
		{
			Character character = m_From.Get<Character>(gameObject);
			if (!(character != null))
			{
				return null;
			}
			return character.Combat.Targets.Primary;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectCharacterTarget());
		}
	}
}
