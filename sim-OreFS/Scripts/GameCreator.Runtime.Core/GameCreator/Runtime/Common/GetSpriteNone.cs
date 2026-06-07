using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("Game Objects/None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null Sprite reference")]
	[Keywords(new string[] { "Null", "Empty" })]
	public class GetSpriteNone : PropertyTypeGetSprite
	{
		public static PropertyGetSprite Create => new PropertyGetSprite(new GetSpriteNone());

		public override string String => "None";

		public override Sprite Get(Args args)
		{
			return null;
		}

		public override Sprite Get(GameObject gameObject)
		{
			return null;
		}
	}
}
