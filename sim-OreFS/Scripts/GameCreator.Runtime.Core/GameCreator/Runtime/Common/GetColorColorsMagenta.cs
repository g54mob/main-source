using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Magenta")]
	[Category("Colors/Magenta")]
	[Image(typeof(IconColor), ColorTheme.Type.Pink)]
	[Description("Returns the color Magenta #FF00FF")]
	public class GetColorColorsMagenta : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsMagenta());

		public override string String => "Magenta";

		public override Color EditorValue => Color.magenta;

		public override Color Get(Args args)
		{
			return Color.magenta;
		}
	}
}
