using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Opposite of Color")]
	[Category("Math/Opposite of Color")]
	[Image(typeof(IconColor), ColorTheme.Type.Green, typeof(OverlayArrowLeft))]
	[Description("Returns the opposite of the color value")]
	public class GetColorOpposite : PropertyTypeGetColor
	{
		[SerializeField]
		protected PropertyGetColor m_Color = new PropertyGetColor();

		public override string String => $"Opposite of {m_Color}";

		public override Color Get(Args args)
		{
			Color.RGBToHSV(m_Color.Get(args), out var H, out var S, out var V);
			return Color.HSVToRGB((H + 0.5f) % 1f, S, V);
		}

		public static PropertyGetColor Create(Color value)
		{
			return new PropertyGetColor(new GetColorValue(value));
		}
	}
}
