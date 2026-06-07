using System;
using System.Collections.Generic;
using UnityEngine;

public static class TextureUtil
{
	public static Texture2D RotateTexture(Texture2D tex, float angle)
	{
		Texture2D texture2D = new Texture2D(tex.width, tex.height);
		int width = tex.width;
		int height = tex.height;
		float num = rot_y(angle, (float)(-width) / 2f, (float)(-height) / 2f) + (float)width / 2f;
		float num2 = rot_x(angle, (float)(-width) / 2f, (float)(-height) / 2f) + (float)height / 2f;
		float num3 = rot_y(angle, 1f, 0f);
		float num4 = rot_x(angle, 1f, 0f);
		float num5 = rot_y(angle, 0f, 1f);
		float num6 = rot_x(angle, 0f, 1f);
		float num7 = num;
		float num8 = num2;
		for (int i = 0; i < tex.width; i++)
		{
			float num9 = num7;
			float num10 = num8;
			for (int j = 0; j < tex.height; j++)
			{
				num9 += num3;
				num10 += num4;
				texture2D.SetPixel((int)Mathf.Round(i), (int)Mathf.Round(j), GetPixel(tex, num9, num10));
			}
			num7 += num5;
			num8 += num6;
		}
		texture2D.Apply();
		return texture2D;
	}

	private static Color GetPixel(Texture2D tex, float x, float y)
	{
		int num = (int)Mathf.Round(x);
		int num2 = (int)Mathf.Round(y);
		if (num > tex.width || num < 0 || num2 > tex.height || num2 < 0)
		{
			return Color.clear;
		}
		return tex.GetPixelBilinear(x / (float)tex.width, y / (float)tex.height);
	}

	private static float rot_x(float angle, float x, float y)
	{
		float num = Mathf.Cos(angle / 180f * (float)Math.PI);
		float num2 = Mathf.Sin(angle / 180f * (float)Math.PI);
		return x * num + y * (0f - num2);
	}

	private static float rot_y(float angle, float x, float y)
	{
		float num = Mathf.Cos(angle / 180f * (float)Math.PI);
		float num2 = Mathf.Sin(angle / 180f * (float)Math.PI);
		return x * num2 + y * num;
	}

	public static List<Texture2D> Split(Texture2D input, int splitsPerAxis)
	{
		if (splitsPerAxis < 2 || !Mathf.IsPowerOfTwo(splitsPerAxis))
		{
			throw new Exception("SplitTexture splitsPerAxis must be a power-of-two number >= 2, got " + splitsPerAxis);
		}
		if (!Mathf.IsPowerOfTwo(input.width) || !Mathf.IsPowerOfTwo(input.height) || input.width < 2)
		{
			throw new Exception("SplitTexture input texture must have power-of-two width & height, got " + input.width + "x" + input.height);
		}
		if (input.width != input.height)
		{
			throw new Exception("SplitTexture input texture must have equal width & height, got " + input.width + "x" + input.height);
		}
		int width = input.width;
		List<Texture2D> list = new List<Texture2D>();
		for (int i = 0; i < splitsPerAxis; i++)
		{
			for (int j = 0; j < splitsPerAxis; j++)
			{
				Texture2D texture2D = new Texture2D(width, width, input.format, mipChain: true);
				Color[] pixels = input.GetPixels(j * width, i * width, width, width);
				texture2D.SetPixels(pixels);
				texture2D.Apply();
				list.Add(texture2D);
			}
		}
		return list;
	}
}
