using System;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class ColorsUtility
	{
		public static Color Parse(ReadOnlySpan<char> value, ColorStringFormat format, Color defaultColor = default(Color))
		{
			if (!TryParse(value, format, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color Parse(string value, ColorStringFormat format, Color defaultColor = default(Color))
		{
			if (!TryParse(value.AsSpan(), format, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color32 Parse32(ReadOnlySpan<char> value, ColorStringFormat format, Color32 defaultColor = default(Color32))
		{
			if (!TryParse32(value, format, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color32 Parse32(string value, ColorStringFormat format, Color32 defaultColor = default(Color32))
		{
			if (!TryParse32(value.AsSpan(), format, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color ParseHexRGBA(ReadOnlySpan<char> hexColor, Color defaultColor = default(Color))
		{
			if (!TryParseHexRGBA(hexColor, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color ParseHexRGBA(string hexColor, Color defaultColor = default(Color))
		{
			if (!TryParseHexRGBA(hexColor, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color32 ParseHexRGBA32(ReadOnlySpan<char> hexColor, Color32 defaultColor = default(Color32))
		{
			if (!TryParseHexRGBA32(hexColor, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static Color32 ParseHexRGBA32(string hexColor, Color32 defaultColor = default(Color32))
		{
			if (!TryParseHexRGBA32(hexColor, out var color))
			{
				return defaultColor;
			}
			return color;
		}

		public static string ToString(Color value, ColorStringFormat format)
		{
			switch (format)
			{
			case ColorStringFormat.Default:
			case ColorStringFormat.FloatRGBA:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b) + "," + DataIO.ToString(value.a);
			case ColorStringFormat.FloatRGB:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b);
			case ColorStringFormat.ByteRGBA:
			{
				Color32 color2 = value;
				return DataIO.ToString(color2.r) + "," + DataIO.ToString(color2.g) + "," + DataIO.ToString(color2.b) + "," + DataIO.ToString(color2.a);
			}
			case ColorStringFormat.ByteRGB:
			{
				Color32 color = value;
				return DataIO.ToString(color.r) + "," + DataIO.ToString(color.g) + "," + DataIO.ToString(color.b);
			}
			case ColorStringFormat.HexRGBA:
				return ColorUtility.ToHtmlStringRGBA(value);
			case ColorStringFormat.HexRGB:
				return ColorUtility.ToHtmlStringRGB(value);
			default:
				throw new NotSupportedException($"Color format '{format}' not supported.");
			}
		}

		public static string ToString(Color32 value, ColorStringFormat format)
		{
			switch (format)
			{
			case ColorStringFormat.Default:
			case ColorStringFormat.FloatRGBA:
			{
				Color color2 = value;
				return DataIO.ToString(color2.r) + "," + DataIO.ToString(color2.g) + "," + DataIO.ToString(color2.b) + "," + DataIO.ToString(color2.a);
			}
			case ColorStringFormat.FloatRGB:
			{
				Color color = value;
				return DataIO.ToString(color.r) + "," + DataIO.ToString(color.g) + "," + DataIO.ToString(color.b);
			}
			case ColorStringFormat.ByteRGBA:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b) + "," + DataIO.ToString(value.a);
			case ColorStringFormat.ByteRGB:
				return DataIO.ToString(value.r) + "," + DataIO.ToString(value.g) + "," + DataIO.ToString(value.b);
			case ColorStringFormat.HexRGBA:
				return DataIO.ToString(value.r, "X2") + DataIO.ToString(value.g, "X2") + DataIO.ToString(value.b, "X2") + DataIO.ToString(value.a, "X2");
			case ColorStringFormat.HexRGB:
				return DataIO.ToString(value.r, "X2") + DataIO.ToString(value.g, "X2") + DataIO.ToString(value.b, "X2");
			default:
				throw new NotSupportedException($"Color format '{format}' not supported.");
			}
		}

		public static bool TryParse(string value, ColorStringFormat format, out Color color)
		{
			return TryParse(value.AsSpan(), format, out color);
		}

		public static bool TryParse(ReadOnlySpan<char> value, ColorStringFormat format, out Color color)
		{
			color = default(Color);
			if (value == null)
			{
				return false;
			}
			switch (format)
			{
			case ColorStringFormat.Default:
			case ColorStringFormat.FloatRGBA:
			case ColorStringFormat.FloatRGB:
			{
				StringUtility.StringSplitEnumerator stringSplitEnumerator2 = StringUtility.SpanSplit(value, ',');
				if (!stringSplitEnumerator2.MoveNext() || !DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out var value3))
				{
					return false;
				}
				color.r = value3;
				if (!stringSplitEnumerator2.MoveNext() || !DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out value3))
				{
					return false;
				}
				color.g = value3;
				if (!stringSplitEnumerator2.MoveNext() || !DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out value3))
				{
					return false;
				}
				color.b = value3;
				if (format == ColorStringFormat.FloatRGB || !stringSplitEnumerator2.MoveNext())
				{
					color.a = 1f;
					return true;
				}
				if (!DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out value3))
				{
					return false;
				}
				color.a = value3;
				return true;
			}
			case ColorStringFormat.ByteRGBA:
			case ColorStringFormat.ByteRGB:
			{
				StringUtility.StringSplitEnumerator stringSplitEnumerator = StringUtility.SpanSplit(value, ',');
				if (!stringSplitEnumerator.MoveNext() || !DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out var value2))
				{
					return false;
				}
				color.r = (float)(int)value2 / 255f;
				if (!stringSplitEnumerator.MoveNext() || !DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out value2))
				{
					return false;
				}
				color.g = (float)(int)value2 / 255f;
				if (!stringSplitEnumerator.MoveNext() || !DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out value2))
				{
					return false;
				}
				color.b = (float)(int)value2 / 255f;
				if (format == ColorStringFormat.ByteRGB || !stringSplitEnumerator.MoveNext())
				{
					color.a = 1f;
					return true;
				}
				if (!DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out value2))
				{
					return false;
				}
				color.a = (float)(int)value2 / 255f;
				return true;
			}
			case ColorStringFormat.HexRGBA:
				return TryParseHexRGBA(value, out color);
			case ColorStringFormat.HexRGB:
				if (TryParseHexRGBA(value, out color))
				{
					color.a = 1f;
					return true;
				}
				return false;
			default:
				throw new NotSupportedException($"Color format '{format}' not supported.");
			}
		}

		public static bool TryParse32(string value, ColorStringFormat format, out Color32 color)
		{
			return TryParse32(value.AsSpan(), format, out color);
		}

		public static bool TryParse32(ReadOnlySpan<char> value, ColorStringFormat format, out Color32 color)
		{
			color = default(Color32);
			if (value == null)
			{
				return false;
			}
			switch (format)
			{
			case ColorStringFormat.Default:
			case ColorStringFormat.FloatRGBA:
			case ColorStringFormat.FloatRGB:
			{
				StringUtility.StringSplitEnumerator stringSplitEnumerator2 = StringUtility.SpanSplit(value, ',');
				if (!stringSplitEnumerator2.MoveNext() || !DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out var value3))
				{
					return false;
				}
				color.r = (byte)Mathf.Round(Mathf.Clamp01(value3) * 255f);
				if (!stringSplitEnumerator2.MoveNext() || !DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out value3))
				{
					return false;
				}
				color.g = (byte)Mathf.Round(Mathf.Clamp01(value3) * 255f);
				if (!stringSplitEnumerator2.MoveNext() || !DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out value3))
				{
					return false;
				}
				color.b = (byte)Mathf.Round(Mathf.Clamp01(value3) * 255f);
				if (format == ColorStringFormat.FloatRGB || !stringSplitEnumerator2.MoveNext())
				{
					color.a = byte.MaxValue;
					return true;
				}
				if (!DataIO.TryParseFloat(stringSplitEnumerator2.Current.Span, out value3))
				{
					return false;
				}
				color.a = (byte)Mathf.Round(Mathf.Clamp01(value3) * 255f);
				return true;
			}
			case ColorStringFormat.ByteRGBA:
			case ColorStringFormat.ByteRGB:
			{
				StringUtility.StringSplitEnumerator stringSplitEnumerator = StringUtility.SpanSplit(value, ',');
				if (!stringSplitEnumerator.MoveNext() || !DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out var value2))
				{
					return false;
				}
				color.r = value2;
				if (!stringSplitEnumerator.MoveNext() || !DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out value2))
				{
					return false;
				}
				color.g = value2;
				if (!stringSplitEnumerator.MoveNext() || !DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out value2))
				{
					return false;
				}
				color.b = value2;
				if (format == ColorStringFormat.ByteRGB || !stringSplitEnumerator.MoveNext())
				{
					color.a = byte.MaxValue;
					return true;
				}
				if (!DataIO.TryParseByte(stringSplitEnumerator.Current.Span, out value2))
				{
					return false;
				}
				color.a = value2;
				return true;
			}
			case ColorStringFormat.HexRGBA:
				return TryParseHexRGBA32(value, out color);
			case ColorStringFormat.HexRGB:
				if (TryParseHexRGBA32(value, out color))
				{
					color.a = byte.MaxValue;
					return true;
				}
				return false;
			default:
				throw new NotSupportedException($"Color format '{format}' not supported.");
			}
		}

		public unsafe static bool TryParseHexRGBA(ReadOnlySpan<char> hexColor, out Color color)
		{
			int length = hexColor.Length;
			if (length == 0)
			{
				color = default(Color);
				return false;
			}
			fixed (char* ptr = hexColor)
			{
				int num = ((*ptr == '#') ? 1 : 0);
				switch (length - num)
				{
				case 6:
				{
					int* ptr3 = stackalloc int[6];
					if (StringUtility.TryParseBase16ToInt(ptr + num, ptr3, 6))
					{
						int num6 = *ptr3 * 16 + ptr3[1];
						int num7 = ptr3[2] * 16 + ptr3[3];
						int num8 = ptr3[4] * 16 + ptr3[5];
						color = new Color((float)num6 / 255f, (float)num7 / 255f, (float)num8 / 255f, 1f);
						return true;
					}
					break;
				}
				case 8:
				{
					int* ptr2 = stackalloc int[8];
					if (StringUtility.TryParseBase16ToInt(ptr + num, ptr2, 8))
					{
						int num2 = *ptr2 * 16 + ptr2[1];
						int num3 = ptr2[2] * 16 + ptr2[3];
						int num4 = ptr2[4] * 16 + ptr2[5];
						int num5 = ptr2[6] * 16 + ptr2[7];
						color = new Color((float)num2 / 255f, (float)num3 / 255f, (float)num4 / 255f, (float)num5 / 255f);
						return true;
					}
					break;
				}
				}
			}
			color = default(Color);
			return false;
		}

		public static bool TryParseHexRGBA(string hexColor, out Color color)
		{
			if (hexColor == null)
			{
				color = default(Color);
				return false;
			}
			return TryParseHexRGBA(hexColor.AsSpan(), out color);
		}

		public unsafe static bool TryParseHexRGBA32(ReadOnlySpan<char> hexColor, out Color32 color)
		{
			int length = hexColor.Length;
			if (length == 0)
			{
				color = default(Color32);
				return false;
			}
			fixed (char* ptr = hexColor)
			{
				int num = ((*ptr == '#') ? 1 : 0);
				switch (length - num)
				{
				case 6:
				{
					int* ptr3 = stackalloc int[6];
					if (StringUtility.TryParseBase16ToInt(ptr + num, ptr3, 6))
					{
						int num6 = *ptr3 * 16 + ptr3[1];
						int num7 = ptr3[2] * 16 + ptr3[3];
						int num8 = ptr3[4] * 16 + ptr3[5];
						color = new Color32((byte)num6, (byte)num7, (byte)num8, byte.MaxValue);
						return true;
					}
					break;
				}
				case 8:
				{
					int* ptr2 = stackalloc int[8];
					if (StringUtility.TryParseBase16ToInt(ptr + num, ptr2, 8))
					{
						int num2 = *ptr2 * 16 + ptr2[1];
						int num3 = ptr2[2] * 16 + ptr2[3];
						int num4 = ptr2[4] * 16 + ptr2[5];
						int num5 = ptr2[6] * 16 + ptr2[7];
						color = new Color32((byte)num2, (byte)num3, (byte)num4, (byte)num5);
						return true;
					}
					break;
				}
				}
			}
			color = default(Color32);
			return false;
		}

		public static bool TryParseHexRGBA32(string hexColor, out Color32 color)
		{
			if (hexColor == null)
			{
				color = default(Color32);
				return false;
			}
			return TryParseHexRGBA32(hexColor.AsSpan(), out color);
		}
	}
}
