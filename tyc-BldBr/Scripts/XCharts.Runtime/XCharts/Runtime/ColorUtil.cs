using System.Collections.Generic;
using UnityEngine;

namespace XCharts.Runtime
{
	public static class ColorUtil
	{
		private static Dictionary<string, Color32> s_ColorCached = new Dictionary<string, Color32>();

		public static readonly Color32 clearColor32 = new Color32(0, 0, 0, 0);

		public static readonly Vector2 zeroVector2 = Vector2.zero;

		public static Color32 GetColor(string hexColorStr)
		{
			if (s_ColorCached.ContainsKey(hexColorStr))
			{
				return s_ColorCached[hexColorStr];
			}
			ColorUtility.TryParseHtmlString(hexColorStr, out var color);
			s_ColorCached[hexColorStr] = color;
			return s_ColorCached[hexColorStr];
		}
	}
}
