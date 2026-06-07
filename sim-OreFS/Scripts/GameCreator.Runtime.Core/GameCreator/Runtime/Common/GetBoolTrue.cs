using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("True")]
	[Category("Constants/True")]
	[Image(typeof(IconToggleOn), ColorTheme.Type.Green)]
	[Description("Always return True")]
	[Keywords(new string[] { "Success", "Yes" })]
	public class GetBoolTrue : PropertyTypeGetBool
	{
		public static PropertyGetBool Create => new PropertyGetBool(new GetBoolTrue());

		public override string String => "True";

		public override bool EditorValue => true;

		public override bool Get(Args args)
		{
			return true;
		}

		public override bool Get(GameObject gameObject)
		{
			return true;
		}
	}
}
