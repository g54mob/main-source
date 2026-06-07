using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Red")]
	[Category("Colors/Red")]
	[Image(typeof(IconColor), ColorTheme.Type.Red)]
	[Description("Returns the color Red #FF0000")]
	public class GetColorColorsRed : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsRed());

		public override string String => "Red";

		public override Color EditorValue => Color.red;

		public override Color Get(Args args)
		{
			return Color.red;
		}
	}
}
