using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetNumberNone : PropertyTypeSetNumber
	{
		public static PropertySetNumber Create => new PropertySetNumber(new SetNumberNone());

		public override string String => "(none)";

		public override void Set(double value, Args args)
		{
		}

		public override void Set(double value, GameObject gameObject)
		{
		}
	}
}
