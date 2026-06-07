using UnityEngine;

namespace SaintsField.Utils
{
	public static class Colors
	{
		public static Color GetColorByStringPresent(string name)
		{
			if (name == null)
			{
				return Color.white;
			}
			if (ColorUtility.TryParseHtmlString(name, out var color))
			{
				return color;
			}
			return GetColorByName(name);
		}

		public static Color GetColorByName(string name)
		{
			switch (name.ToLower())
			{
			case "red":
				return Color.red;
			case "green":
				return new Color32(0, 128, 0, byte.MaxValue);
			case "blue":
				return Color.blue;
			case "white":
				return Color.white;
			case "black":
				return Color.black;
			case "yellow":
				return Color.yellow;
			case "aqua":
			case "cyan":
				return Color.cyan;
			case "fuchsia":
			case "magenta":
				return Color.magenta;
			case "gray":
			case "grey":
				return Color.grey;
			case "charcoalgray":
				return new Color32(48, 48, 48, byte.MaxValue);
			case "clear":
				return Color.clear;
			case "pink":
				return new Color32(byte.MaxValue, 152, 203, byte.MaxValue);
			case "orange":
				return new Color32(byte.MaxValue, 165, 0, byte.MaxValue);
			case "indigo":
				return new Color32(75, 0, 130, byte.MaxValue);
			case "violet":
				return new Color32(128, 0, byte.MaxValue, byte.MaxValue);
			case "brown":
				return new Color32(165, 42, 42, byte.MaxValue);
			case "darkblue":
				return new Color32(0, 0, 160, byte.MaxValue);
			case "lightblue":
				return new Color32(173, 216, 230, byte.MaxValue);
			case "lime":
				return Color.green;
			case "maroon":
				return new Color32(128, 0, 0, byte.MaxValue);
			case "navy":
				return new Color32(0, 0, 128, byte.MaxValue);
			case "olive":
				return new Color32(128, 128, 0, byte.MaxValue);
			case "purple":
				return new Color32(128, 0, 128, byte.MaxValue);
			case "silver":
				return new Color32(192, 192, 192, 0);
			case "teal":
				return new Color32(0, 128, 128, byte.MaxValue);
			case "oceanicslate":
				return new Color32(44, 93, 135, byte.MaxValue);
			case "midnightash":
				return new Color32(35, 35, 35, byte.MaxValue);
			default:
				return Color.white;
			}
		}

		public static string ToHtmlHexString(Color color)
		{
			int num = Mathf.RoundToInt(color.r * 255f);
			int num2 = Mathf.RoundToInt(color.g * 255f);
			int num3 = Mathf.RoundToInt(color.b * 255f);
			int num4 = Mathf.RoundToInt(color.a * 255f);
			return $"#{num:X2}{num2:X2}{num3:X2}{num4:X2}";
		}
	}
}
