using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Screen Width")]
	[Category("Screen/Screen Width")]
	[Image(typeof(IconSquareSolid), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("The horizontal size of the screen in pixels")]
	[Keywords(new string[] { "Resolution", "Size" })]
	public class GetDecimalScreenWidth : PropertyTypeGetDecimal
	{
		public static PropertyGetDecimal Create => new PropertyGetDecimal(new GetDecimalScreenWidth());

		public override string String => "Screen Width";

		public override double EditorValue => Screen.width;

		public override double Get(Args args)
		{
			return Screen.width;
		}

		public override double Get(GameObject gameObject)
		{
			return Screen.width;
		}
	}
}
