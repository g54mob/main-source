using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("None")]
	[Category("None")]
	[Image(typeof(IconNull), ColorTheme.Type.TextLight)]
	[Description("Returns a null Material reference")]
	[Keywords(new string[] { "Null", "Empty", "Shader" })]
	public class GetMaterialNone : PropertyTypeGetMaterial
	{
		public static PropertyGetMaterial Create => new PropertyGetMaterial(new GetMaterialNone());

		public override string String => "None";

		public override Material Get(Args args)
		{
			return null;
		}

		public override Material Get(GameObject gameObject)
		{
			return null;
		}
	}
}
