using System.Collections.Generic;

namespace DigitalLegacy.UI.Sizing
{
	public static class uResize_Extensions
	{
		private static Dictionary<eResizeListenerType, bool> isHorizontalCache = new Dictionary<eResizeListenerType, bool>();

		private static Dictionary<eResizeListenerType, bool> isVerticalCache = new Dictionary<eResizeListenerType, bool>();

		private static Dictionary<eResizeListenerType, bool> isInverseHorizontalCache = new Dictionary<eResizeListenerType, bool>();

		private static Dictionary<eResizeListenerType, bool> isInverseVerticalCache = new Dictionary<eResizeListenerType, bool>();

		public static bool IsHorizontal(this eResizeListenerType type)
		{
			if (isHorizontalCache.ContainsKey(type))
			{
				return isHorizontalCache[type];
			}
			bool flag = type.ToString().EndsWith("Left") || type.ToString().EndsWith("Right");
			isHorizontalCache.Add(type, flag);
			return flag;
		}

		public static bool IsVertical(this eResizeListenerType type)
		{
			if (isVerticalCache.ContainsKey(type))
			{
				return isVerticalCache[type];
			}
			string text = type.ToString();
			bool flag = text.StartsWith("Top") || text.StartsWith("Bottom");
			isVerticalCache.Add(type, flag);
			return flag;
		}

		public static bool IsInverseHorizontal(this eResizeListenerType type)
		{
			if (isInverseHorizontalCache.ContainsKey(type))
			{
				return isInverseHorizontalCache[type];
			}
			bool flag = type.ToString().EndsWith("Left");
			isInverseHorizontalCache.Add(type, flag);
			return flag;
		}

		public static bool IsInverseVertical(this eResizeListenerType type)
		{
			if (isInverseVerticalCache.ContainsKey(type))
			{
				return isInverseVerticalCache[type];
			}
			bool flag = type.ToString().StartsWith("Top");
			isInverseVerticalCache.Add(type, flag);
			return flag;
		}
	}
}
