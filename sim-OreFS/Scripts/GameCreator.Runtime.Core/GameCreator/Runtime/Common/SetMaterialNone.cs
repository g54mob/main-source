using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Description("Don't save on anything")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	public class SetMaterialNone : PropertyTypeSetMaterial
	{
		public static PropertySetMaterial Create => new PropertySetMaterial(new SetMaterialNone());

		public override string String => "(none)";

		public override void Set(Material value, Args args)
		{
		}

		public override void Set(Material value, GameObject gameObject)
		{
		}
	}
}
