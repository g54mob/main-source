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
	public class SetWeaponNone : PropertyTypeSetWeapon
	{
		public static PropertySetWeapon Create => new PropertySetWeapon(new SetWeaponNone());

		public override string String => "(none)";

		public override void Set(IWeapon value, Args args)
		{
		}

		public override void Set(IWeapon value, GameObject gameObject)
		{
		}
	}
}
