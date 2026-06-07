using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Black")]
	[Category("Colors/Black")]
	[Image(typeof(IconColor), ColorTheme.Type.Black)]
	[Description("Returns the color Black #000000")]
	public class GetColorColorsBlack : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsBlack());

		public override string String => "Black";

		public override Color EditorValue => Color.black;

		public override Color Get(Args args)
		{
			return Color.black;
		}
	}
}
