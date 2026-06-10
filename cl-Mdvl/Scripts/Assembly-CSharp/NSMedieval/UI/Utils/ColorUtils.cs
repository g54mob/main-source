using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Repository;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.UI.Utils
{
	public static class ColorUtils
	{
		private static readonly Color[] SkillColors = new Color[6]
		{
			HexToColor("#FF6666"),
			HexToColor("#FFAF60"),
			HexToColor("#FFECA8"),
			HexToColor("#7DD02B"),
			HexToColor("#2BD049"),
			HexToColor("#2BD06D")
		};

		public static string GetColorHex(Color color)
		{
			return ColorUtility.ToHtmlStringRGB(color).ToLower();
		}

		public static string GetColorHex(string colorName)
		{
			KeyColorPair byID = MonoRepository<ColorRepository, KeyColorPair>.Instance.GetByID(colorName);
			if (!(byID == null))
			{
				return ColorUtility.ToHtmlStringRGB(byID.Value).ToLower();
			}
			return ColorUtility.ToHtmlStringRGB(Color.white).ToLower();
		}

		public static Color GetColor(string colorName)
		{
			KeyColorPair byID = MonoRepository<ColorRepository, KeyColorPair>.Instance.GetByID(colorName);
			if (!(byID == null))
			{
				return byID.Value;
			}
			return Color.white;
		}

		public static Color GetAlternatingColor(Color baseColor, int index)
		{
			if ((index + 10) % 2 != 0)
			{
				return new Color(baseColor.r, baseColor.g, baseColor.b, 0f);
			}
			return baseColor;
		}

		public static string ColorText(string text, string colorPreset)
		{
			return ColorText(text, GetColor(colorPreset));
		}

		public static string ColorText(string text, Color color)
		{
			return "<color=#" + ColorUtility.ToHtmlStringRGB(color).ToLower() + ">" + text + "</color>";
		}

		public static string GetSkillModifierColor(float value)
		{
			return "<color=#" + ColorUtility.ToHtmlStringRGB((value < 0f) ? GetColor("red") : GetColor("green")) + ">" + ((value < 0f) ? string.Empty : "+");
		}

		public static string GetSkillLevelColor(float value)
		{
			return $"<#{ColorTools.GetGradientHex(value, 30f, SkillColors)}>{value:N0}</color>";
		}

		private static Color HexToColor(string hex)
		{
			ColorUtility.TryParseHtmlString(hex, out var color);
			return color;
		}
	}
}
