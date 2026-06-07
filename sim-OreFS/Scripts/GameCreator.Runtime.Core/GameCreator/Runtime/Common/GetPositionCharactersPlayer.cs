using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Player Position")]
	[Category("Characters/Player Position")]
	[Image(typeof(IconPlayer), ColorTheme.Type.Green)]
	[Description("Returns the position of the Player character")]
	public class GetPositionCharactersPlayer : PropertyTypeGetPosition
	{
		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionCharactersPlayer());

		public override string String => "Player";

		public override Vector3 Get(Args args)
		{
			Transform transform = ShortcutPlayer.Transform;
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			Transform transform = ShortcutPlayer.Transform;
			if (!(transform != null))
			{
				return default(Vector3);
			}
			return transform.position;
		}
	}
}
