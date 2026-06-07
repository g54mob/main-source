using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("False")]
	[Category("Constants/False")]
	[Image(typeof(IconToggleOff), ColorTheme.Type.Red)]
	[Description("Always return False")]
	[Keywords(new string[] { "Fail", "No" })]
	public class GetBoolFalse : PropertyTypeGetBool
	{
		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolFalse());

		public override string String => "False";

		public override bool EditorValue => false;

		public override bool Get(Args args)
		{
			return false;
		}

		public override bool Get(GameObject gameObject)
		{
			return false;
		}
	}
}
