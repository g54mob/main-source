using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
	public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
	{
		TValue value = dic[fromKey];
		dic.Remove(fromKey);
		dic[toKey] = value;
	}

	public static Texture2D CropToColoredPixels(this Texture2D input)
	{
		Color[] pixels = input.GetPixels();
		int num = input.width;
		int num2 = 0;
		int num3 = input.height;
		int num4 = 0;
		for (int i = 0; i < input.height; i++)
		{
			for (int j = 0; j < input.width; j++)
			{
				if (pixels[i * input.width + j].a > 0f)
				{
					if (j < num)
					{
						num = j;
					}
					if (j > num2)
					{
						num2 = j;
					}
					if (i < num3)
					{
						num3 = i;
					}
					if (i > num4)
					{
						num4 = i;
					}
				}
			}
		}
		int num5 = num2 - num + 1;
		int num6 = num4 - num3 + 1;
		Color[] array = new Color[num5 * num6];
		for (int k = num3; k <= num4; k++)
		{
			for (int l = num; l <= num2; l++)
			{
				array[(k - num3) * num5 + (l - num)] = pixels[k * input.width + l];
			}
		}
		Texture2D texture2D = new Texture2D(num5, num6);
		texture2D.SetPixels(array);
		texture2D.Apply();
		return texture2D;
	}

	public static Vector2Int ToCardinal(this Vector2 input)
	{
		if (input == Vector2.zero)
		{
			return Vector2Int.zero;
		}
		if (!(Mathf.Abs(input.x) > Mathf.Abs(input.y)))
		{
			return new Vector2Int(0, (int)Mathf.Sign(input.y));
		}
		return new Vector2Int((int)Mathf.Sign(input.x), 0);
	}
}
