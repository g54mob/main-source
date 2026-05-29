using UnityEngine;

namespace AssetIcons
{
	public sealed class AssetIconsStyle
	{
		public string Width { get; set; }

		public string Height { get; set; }

		public string X { get; set; }

		public string Y { get; set; }

		public int MaxSize { get; set; }

		public IconAnchor Anchor { get; set; }

		public IconAspect Aspect { get; set; }

		public string Display { get; set; }

		public string Tint { get; set; }

		public int Layer { get; set; }

		public FontStyle FontStyle { get; set; }

		public IconAnchor TextAnchor { get; set; }

		public IconProjection Projection { get; set; }

		public AssetIconsStyle()
		{
			Width = "100%";
			Height = "100%";
			X = "0";
			Y = "0";
			MaxSize = int.MaxValue;
			Anchor = IconAnchor.Center;
			Aspect = IconAspect.Fit;
			Display = "true";
			Tint = "#ffffff";
			Layer = 0;
			FontStyle = FontStyle.Normal;
			TextAnchor = IconAnchor.Center;
			Projection = IconProjection.Perspective;
		}
	}
}
