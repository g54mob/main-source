using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Cyan")]
	[Category("Colors/Cyan")]
	[Image(typeof(IconColor), ColorTheme.Type.Teal)]
	[Description("Returns the color Cyan #00FFFF")]
	public class GetColorColorsCyan : PropertyTypeGetColor
	{
		public static PropertyGetColor Create => new PropertyGetColor(new GetColorColorsCyan());

		public override string String => "Cyan";

		public override Color EditorValue => Color.cyan;

		public override Color Get(Args args)
		{
			return Color.cyan;
		}
	}
}
