using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Screen Height")]
	[Category("Screen/Screen Height")]
	[Image(typeof(IconSquareSolid), ColorTheme.Type.Yellow, typeof(OverlayArrowUp))]
	[Description("The vertical size of the screen in pixels")]
	[Keywords(new string[] { "Resolution", "Size" })]
	public class GetDecimalScreenHeight : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalScreenHeight());

		public override string String => "Screen Height";

		public override double EditorValue => Screen.height;

		public override double Get(Args args)
		{
			return Screen.height;
		}

		public override double Get(GameObject gameObject)
		{
			return Screen.height;
		}
	}
}
