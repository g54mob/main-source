using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Blue")]
	[Category("Colors/Blue")]
	[Image(typeof(IconColor), ColorTheme.Type.Blue)]
	[Description("Returns the color Blue #0000FF")]
	public class GetColorColorsBlue : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsBlue());

		public override string String => "Blue";

		public override Color EditorValue => Color.blue;

		public override Color Get(Args args)
		{
			return Color.blue;
		}
	}
}
