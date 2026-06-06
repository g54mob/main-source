using UnityEngine;

namespace Brewery.UI.Shared
{
	public static class StationAccentColors
	{
		public static readonly Color CornGrindingPrimary;

		public static readonly Color CornGrindingLight;

		public static readonly Color CornGrindingDark;

		public static readonly Color BoilingPrimary;

		public static readonly Color BoilingLight;

		public static readonly Color BoilingDark;

		public static readonly Color StompingPrimary;

		public static readonly Color StompingLight;

		public static readonly Color StompingDark;

		public static readonly Color WinemakingPrimary;

		public static readonly Color WinemakingLight;

		public static readonly Color WinemakingDark;

		public static readonly Color SpiritsPrimary;

		public static readonly Color SpiritsLight;

		public static readonly Color SpiritsDark;

		public static Color GetPrimaryColor(StationType stationType)
		{
			return default(Color);
		}

		public static Color GetLightColor(StationType stationType)
		{
			return default(Color);
		}

		public static Color GetDarkColor(StationType stationType)
		{
			return default(Color);
		}

		public static string ToHex(Color color)
		{
			return null;
		}

		public static string ToRgba(Color color, float alpha = 1f)
		{
			return null;
		}
	}
}
