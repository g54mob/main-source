using System;
using System.Globalization;
using UnityEngine;

namespace Doozy.Engine.Extensions;

public static class ColorExtensions
{
	private const float LIGHT_OFFSET = 0.0625f;

	private const float DARKER_FACTOR = 0.9f;

	public unsafe static Color FromHex(Color color, string hexValue, float alpha = 1f)
	{
		//IL_0134: Expected native int or pointer, but got O
		//IL_0121: Expected native int or pointer, but got O
		Color color2 = default(Color);
		if (hexValue != null && hexValue._stringLength > 0)
		{
			if (hexValue._stringLength > 0)
			{
				bool flag = hexValue._firstChar != '#';
				string text = hexValue;
				if (!flag)
				{
					object obj = default(object);
					text = hexValue.TrimHelper((char*)(&obj), 1, string.TrimType.Head);
				}
				if (text._stringLength > 6)
				{
					int count = text._stringLength - 6;
					text = text.Remove(6, count);
				}
				int num = int.Parse(text, NumberStyles.HexNumber);
				float r = default(float);
				((Color*)(nint)color2)->r = r;
				return color2;
			}
			System.ThrowHelper.ThrowIndexOutOfRangeException();
			Color result = default(Color);
			return result;
		}
		((Color*)(nint)color2)->r = 0f;
		return color2;
	}

	public unsafe static Color ColorFrom256(Color color, float r, float g, float b, float a = 255f)
	{
		//IL_0048: Expected native int or pointer, but got O
		//IL_0055: Expected native int or pointer, but got O
		//IL_0062: Expected native int or pointer, but got O
		//IL_006f: Expected native int or pointer, but got O
		float r2 = r / 255f;
		float g2 = g / 255f;
		object obj = default(object);
		float b2 = (float)obj / 255f;
		object obj2 = default(object);
		float a2 = (float)obj2 / 255f;
		Color color2 = default(Color);
		((Color*)(nint)color2)->r = r2;
		((Color*)(nint)color2)->g = g2;
		((Color*)(nint)color2)->b = b2;
		((Color*)(nint)color2)->a = a2;
		return color2;
	}

	public unsafe static Color ColorFrom256(float r, float g, float b, float a = 255f)
	{
		//IL_0048: Expected native int or pointer, but got O
		//IL_0055: Expected native int or pointer, but got O
		//IL_0062: Expected native int or pointer, but got O
		//IL_006f: Expected native int or pointer, but got O
		float r2 = r / 255f;
		float g2 = g / 255f;
		float b2 = b / 255f;
		object obj = default(object);
		float a2 = (float)obj / 255f;
		Color color = default(Color);
		((Color*)(nint)color)->r = r2;
		((Color*)(nint)color)->g = g2;
		((Color*)(nint)color)->b = b2;
		((Color*)(nint)color)->a = a2;
		return color;
	}

	public unsafe static Color Lighter(Color color)
	{
		//IL_0037: Expected native int or pointer, but got O
		//IL_0044: Expected native int or pointer, but got O
		//IL_0066: Expected native int or pointer, but got O
		//IL_0073: Expected native int or pointer, but got O
		float r = color.r + 0.0625f;
		float b = color.b + 0.0625f;
		Color color2 = default(Color);
		((Color*)(nint)color2)->a = color.a;
		((Color*)(nint)color2)->r = r;
		float g = color.g + 0.0625f;
		((Color*)(nint)color2)->b = b;
		((Color*)(nint)color2)->g = g;
		return color2;
	}

	public unsafe static Color Darker(Color color)
	{
		//IL_0037: Expected native int or pointer, but got O
		//IL_0044: Expected native int or pointer, but got O
		//IL_0066: Expected native int or pointer, but got O
		//IL_0073: Expected native int or pointer, but got O
		float r = color.r - 0.0625f;
		float b = color.b - 0.0625f;
		Color color2 = default(Color);
		((Color*)(nint)color2)->a = color.a;
		((Color*)(nint)color2)->r = r;
		float g = color.g - 0.0625f;
		((Color*)(nint)color2)->b = b;
		((Color*)(nint)color2)->g = g;
		return color2;
	}

	public static float Brightness(Color color)
	{
		float num = color.g + color.r;
		float num2 = num + color.b;
		return num2 / 3f;
	}

	public unsafe static Color WithBrightness(Color color, float brightness)
	{
		//IL_00ea: Expected native int or pointer, but got O
		//IL_00aa: Expected native int or pointer, but got O
		//IL_00b7: Expected native int or pointer, but got O
		//IL_0126: Expected native int or pointer, but got O
		//IL_008b: Expected native int or pointer, but got O
		//IL_0098: Expected native int or pointer, but got O
		object obj = default(object);
		float num = (float)obj + color.r;
		Color color2 = default(Color);
		((Color*)(nint)color2)->a = color.a;
		float num2 = num + (float)obj;
		float b;
		if (Mathf.Epsilon < num2)
		{
			float num3 = (float)obj + color.r;
			float num4 = num3 + (float)obj;
			float num5 = num4 / 3f;
			float num6 = brightness / num5;
			float r = num6 * color.r;
			float g = num6 * color.g;
			b = num6 * color.b;
			((Color*)(nint)color2)->r = r;
			((Color*)(nint)color2)->g = g;
		}
		else
		{
			((Color*)(nint)color2)->r = brightness;
			((Color*)(nint)color2)->g = brightness;
			b = brightness;
		}
		((Color*)(nint)color2)->b = b;
		return color2;
	}

	public static bool IsApproximatelyBlack(Color color)
	{
		float num = color.g + color.r;
		float num2 = num + color.b;
		bool flag = Mathf.Epsilon < num2;
		return !flag;
	}

	public static bool IsApproximatelyWhite(Color color)
	{
		float num = color.g + color.r;
		float num2 = num + color.b;
		float num3 = 1f - Mathf.Epsilon;
		bool flag = num2 < num3;
		return !flag;
	}

	public unsafe static Color Opaque(Color color)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_003f: Expected native int or pointer, but got O
		Color color2 = default(Color);
		((Color*)(nint)color2)->r = color.r;
		((Color*)(nint)color2)->g = color.g;
		((Color*)(nint)color2)->b = color.b;
		((Color*)(nint)color2)->a = 1f;
		return color2;
	}

	public unsafe static Color Invert(Color color)
	{
		//IL_0022: Expected native int or pointer, but got O
		//IL_0059: Expected native int or pointer, but got O
		//IL_0066: Expected native int or pointer, but got O
		//IL_0073: Expected native int or pointer, but got O
		float r = 1f - color.r;
		Color color2 = default(Color);
		((Color*)(nint)color2)->a = color.a;
		float g = 1f - color.g;
		float b = 1f - color.b;
		((Color*)(nint)color2)->r = r;
		((Color*)(nint)color2)->g = g;
		((Color*)(nint)color2)->b = b;
		return color2;
	}

	public unsafe static Color WithAlpha(Color color, float alpha)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_003e: Expected native int or pointer, but got O
		Color color2 = default(Color);
		((Color*)(nint)color2)->r = color.r;
		((Color*)(nint)color2)->g = color.g;
		((Color*)(nint)color2)->b = color.b;
		((Color*)(nint)color2)->a = alpha;
		return color2;
	}
}
