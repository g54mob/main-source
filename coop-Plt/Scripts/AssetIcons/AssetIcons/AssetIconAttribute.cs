using System;
using UnityEngine;

namespace AssetIcons
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public sealed class AssetIconAttribute : PropertyAttribute
	{
		private readonly AssetIconsStyle style;

		private readonly string filePath;

		private readonly int lineNumber;

		public AssetIconsStyle Style => style;

		public string FilePath => filePath;

		public int LineNumber => lineNumber;

		public AssetIconAttribute(string width = "100%", string height = "100%", string x = "0", string y = "0", int maxSize = 64, IconAnchor anchor = IconAnchor.Center, IconAspect aspect = IconAspect.Fit, string display = "true", string tint = "#ffffff", int layer = 0, FontStyle fontStyle = FontStyle.Normal, IconAnchor textAnchor = IconAnchor.Center, IconProjection projection = IconProjection.Perspective, int lineNumber = -1, string filePath = null)
		{
			style = new AssetIconsStyle
			{
				Width = width,
				Height = height,
				X = x,
				Y = y,
				MaxSize = maxSize,
				Anchor = anchor,
				Aspect = aspect,
				Tint = tint,
				Layer = layer,
				FontStyle = fontStyle,
				Projection = projection,
				Display = display,
				TextAnchor = textAnchor
			};
			this.lineNumber = lineNumber;
			this.filePath = filePath;
		}
	}
}
