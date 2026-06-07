using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetSpriteNone : PropertyTypeSetSprite
	{
		public static PropertySetSprite Create => new PropertySetSprite(new SetSpriteNone());

		public override string String => "(none)";

		public override void Set(Sprite value, Args args)
		{
		}

		public override void Set(Sprite value, GameObject gameObject)
		{
		}
	}
}
