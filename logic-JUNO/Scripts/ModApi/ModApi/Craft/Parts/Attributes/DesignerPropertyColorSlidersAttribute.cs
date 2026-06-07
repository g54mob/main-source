using System;

namespace ModApi.Craft.Parts.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class DesignerPropertyColorSlidersAttribute : DesignerPropertyAttribute
	{
		public string AlphaLabel { get; set; }

		public bool ShowAlpha { get; set; }

		public DesignerPropertyColorSlidersAttribute()
		{
			ShowAlpha = true;
			AlphaLabel = "Alpha";
		}

		public DesignerPropertyColorSlidersAttribute(bool showAlpha, string alphaLabel = "Alpha")
		{
			ShowAlpha = showAlpha;
			AlphaLabel = alphaLabel;
		}
	}
}
