using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("White")]
	[Category("Colors/White")]
	[Image(typeof(IconColor), ColorTheme.Type.White)]
	[Description("Returns the color White #FFFFFF")]
	public class GetColorColorsWhite : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsWhite());

		public override string String => "White";

		public override Color EditorValue => Color.white;

		public override Color Get(Args args)
		{
			return Color.white;
		}
	}
}
