using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetStringNone : PropertyTypeSetString
	{
		public static PropertySetString Create => new PropertySetString(new SetStringNone());

		public override string String => "(none)";

		public override void Set(string value, Args args)
		{
		}

		public override void Set(string value, GameObject gameObject)
		{
		}
	}
}
