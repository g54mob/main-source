using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Black & White of Color")]
	[Category("Math/Black & White of Color")]
	[Image(typeof(IconColor), ColorTheme.Type.TextNormal)]
	[Description("Returns the black and white value of the color")]
	public class GetColorBlackAndWhite : PropertyTypeGetColor
	{
		[SerializeField]
		protected PropertyGetColor m_Color = new PropertyGetColor();

		public override string String => $"Black & White of {m_Color}";

		public override Color Get(Args args)
		{
			Color.RGBToHSV(m_Color.Get(args), out var H, out var _, out var V);
			return Color.HSVToRGB(H, 0f, V);
		}

		public static PropertyGetColor Create(Color value)
		{
			return new PropertyGetColor(new GetColorValue(value));
		}
	}
}
