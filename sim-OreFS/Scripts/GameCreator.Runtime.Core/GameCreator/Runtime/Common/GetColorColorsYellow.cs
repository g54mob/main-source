using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Yellow")]
	[Category("Colors/Yellow")]
	[Image(typeof(IconColor), ColorTheme.Type.Yellow)]
	[Description("Returns the color Yellow (not #FFFF00 but nicer to look at!)")]
	public class GetColorColorsYellow : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsYellow());

		public override string String => "Yellow";

		public override Color EditorValue => Color.yellow;

		public override Color Get(Args args)
		{
			return Color.yellow;
		}
	}
}
