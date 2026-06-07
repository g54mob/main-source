using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Green")]
	[Category("Colors/Green")]
	[Image(typeof(IconColor), ColorTheme.Type.Green)]
	[Description("Returns the color Green #00FF00")]
	public class GetColorColorsGreen : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsGreen());

		public override string String => "Green";

		public override Color EditorValue => Color.green;

		public override Color Get(Args args)
		{
			return Color.green;
		}
	}
}
