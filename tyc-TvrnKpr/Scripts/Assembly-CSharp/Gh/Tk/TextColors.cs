using System;
using UnityEngine;

namespace Gh.Tk
{
	public static class TextColors
	{
		public const string InvisibleHex = "#00000000";

		public static string DefaultLinkColor => null;

		public static string CodexLinkColor => null;

		public static string CodexVisitedColor => null;

		public static string HandbookLinkColor => null;

		public static Color Red => default(Color);

		public static string RedAsHex => null;

		public static Color Green => default(Color);

		public static string GreenAsHex => null;

		public static Color Gold => default(Color);

		public static Color Orange => default(Color);

		public static string OrangeAsHex => null;

		private static TextStyleId ActiveStyle { get; set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
		}

		public static string GetNamedHexColor(string name, bool withAlpha = true)
		{
			return null;
		}

		public static Color GetNamedColor(string name)
		{
			return default(Color);
		}

		public static void ApplyWithStyle(Action applyAction, TextStyleId textStyleId)
		{
		}
	}
}
