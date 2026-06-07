using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Player")]
	[Category("Characters/Player")]
	[Description("Game Object that represents the Player")]
	[Image(typeof(IconPlayer), ColorTheme.Type.Green)]
	public class GetGameObjectPlayer : PropertyTypeGetGameObject
	{
		public override string String => "Player";

		public override GameObject EditorValue
		{
			get
			{
				Character[] array = UnityEngine.Object.FindObjectsByType<Character>(FindObjectsSortMode.None);
				foreach (Character character in array)
				{
					if (character.IsPlayer)
					{
						return character.gameObject;
					}
				}
				return null;
			}
		}

		public override GameObject Get(Args args)
		{
			if (!(ShortcutPlayer.Instance != null))
			{
				return null;
			}
			return ShortcutPlayer.Instance.gameObject;
		}

		public override GameObject Get(GameObject gameObject)
		{
			if (!(ShortcutPlayer.Instance != null))
			{
				return null;
			}
			return ShortcutPlayer.Instance.gameObject;
		}

		public static PropertyGetGameObject Create()
		{
			return new PropertyGetGameObject(new GetGameObjectPlayer());
		}
	}
}
