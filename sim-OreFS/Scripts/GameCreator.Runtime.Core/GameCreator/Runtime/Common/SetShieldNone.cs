using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetShieldNone : PropertyTypeSetShield
	{
		public static PropertySetShield Create => new PropertySetShield(new SetShieldNone());

		public override string String => "(none)";

		public override void Set(IShield value, Args args)
		{
		}

		public override void Set(IShield value, GameObject gameObject)
		{
		}
	}
}
