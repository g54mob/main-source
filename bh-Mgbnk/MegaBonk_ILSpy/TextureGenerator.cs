using System;
using Cpp2ILInjected;
using UnityEngine;

public static class TextureGenerator
{
	public static Texture2D textureFromColorMap(Color[] colorMap, int width, int height)
	{
		bool mipChain = default(bool);
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, mipChain);
		if ((object)texture2D != null)
		{
			texture2D.filterMode = FilterMode.Point;
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.SetPixels(colorMap);
			texture2D.Apply();
			return texture2D;
		}
		return (Texture2D)(object)new NullReferenceException();
	}

	public static Texture2D TextureFromHeightMap(float[,] heightMap)
	{
		//IL_003b: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0088: Expected I, but got O
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Expected O, but got Unknown
		//IL_0096: Expected O, but got I4
		int length = heightMap.GetLength(0);
		int length2 = heightMap.GetLength(1);
		object obj = length2 * length;
		Color[] array = new Color[obj];
		if (length2 > 0)
		{
			object obj2 = 0;
			object obj3 = array;
			nint num = (nint)typeof(Color[]);
			float num3 = default(float);
			do
			{
				if (length > 0)
				{
					object obj4 = 0;
					float num2 = num3;
					throw new IndexOutOfRangeException();
				}
				obj2++;
			}
			while ((nint)obj2 < length2);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 209 Invalid \"Jump target not found in method: 0x18052C290\"");
		throw new NullReferenceException();
	}

	public static Texture2D ColorTextureFromHeightMap(float[,] heightMap, TextureData textureData)
	{
		//IL_003b: Expected O, but got I4
		//IL_0071: Expected O, but got I4
		//IL_0080: Expected I, but got O
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		int length = heightMap.GetLength(0);
		int length2 = heightMap.GetLength(1);
		TextureData.Layer layer = (TextureData.Layer)(length2 * length);
		Color[] colorMap = new Color[(object)layer];
		if (length2 > 0)
		{
			object obj = 0;
			nint num = (nint)typeof(Color[]);
			Color color2 = default(Color);
			do
			{
				if (length > 0)
				{
					TextureData.Layer layer2 = null;
					Color color = color2;
					throw new IndexOutOfRangeException();
				}
				obj++;
			}
			while ((nint)obj < length2);
		}
		return textureFromColorMap(colorMap, length, length2);
	}

	public unsafe static Color GetColor(float height, TextureData textureData)
	{
		//IL_0036: Expected O, but got I4
		//IL_00f6: Expected F4, but got O
		//IL_00f1: Expected native int or pointer, but got O
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		TextureData.Layer[] layers = textureData.layers;
		bool flag = (nint)textureData.layers < 0;
		object obj = layers.Length - 1;
		if (flag)
		{
			goto IL_00bd;
		}
		TextureData.Layer layer;
		while ((nint)obj < layers.Length)
		{
			layer = layers[obj];
			float num = height - 0.1f;
			if (!(num > layer.startHeight))
			{
				obj--;
				if (!(num < layer.startHeight))
				{
					continue;
				}
				goto IL_00bd;
			}
			goto IL_00e4;
		}
		goto IL_0143;
		IL_00bd:
		if (layers.Length > 0)
		{
			layer = layers[0];
			if (layers[0] == null)
			{
				throw new NullReferenceException();
			}
			goto IL_00e4;
		}
		goto IL_0143;
		IL_0143:
		return (Color)new IndexOutOfRangeException();
		IL_00e4:
		Color color = default(Color);
		((Color*)(nint)color)->r = (float)layer.tint;
		return color;
	}
}
