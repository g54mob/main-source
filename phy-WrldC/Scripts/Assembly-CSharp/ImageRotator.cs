using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ImageRotator
{
	public enum Rotation
	{
		None = 0,
		Left = 1,
		Right = 2,
		HalfCircle = 3
	}

	public static Texture2D RotateImage_IEnumerable(Texture2D texture, Rotation rotation)
	{
		texture.SetPixels32(RotateColors_IEnumerable(texture, rotation));
		texture.Apply();
		return texture;
	}

	public static Color32[] RotateColors_IEnumerable(Texture2D texture, Rotation rotation)
	{
		Color32[] originalPixels = texture.GetPixels32();
		IEnumerable<Color32> source;
		if (rotation == Rotation.HalfCircle)
		{
			source = originalPixels.Reverse();
		}
		else
		{
			source = Enumerable.Repeat((from i in Enumerable.Range(0, texture.height)
				select i * texture.width).Reverse().ToArray(), texture.width).SelectMany((int[] frpi, int rowIndex) => frpi.Select((int i) => originalPixels[i + rowIndex]));
			if (rotation == Rotation.Right)
			{
				source = source.Reverse();
			}
		}
		return source.ToArray();
	}

	public static Texture2D RotateImage(Texture2D originTexture, Rotation rotation)
	{
		int height = originTexture.height;
		int width = originTexture.width;
		if (rotation == Rotation.Left || rotation == Rotation.Right)
		{
			height = originTexture.width;
			width = originTexture.height;
		}
		Texture2D texture2D = new Texture2D(width, height);
		texture2D.SetPixels32(RotateImageToColor32(originTexture, rotation));
		texture2D.Apply();
		return texture2D;
	}

	public static Color32[] RotateImageToColor32(Texture2D originTexture, Rotation rotation)
	{
		Color32[] pixels = originTexture.GetPixels32();
		Color32[] array = new Color32[pixels.Length];
		int height = originTexture.height;
		int width = originTexture.width;
		int num = 0;
		int num2 = -1;
		switch (rotation)
		{
		case Rotation.Left:
		{
			for (int k = 0; k < width; k++)
			{
				for (int l = 0; l < height; l++)
				{
					num = (height - l) * width - (width - k);
					num2++;
					array[num2] = pixels[num];
				}
			}
			break;
		}
		case Rotation.Right:
		{
			for (int m = 0; m < width; m++)
			{
				for (int n = 0; n < height; n++)
				{
					num = n * width + (width - m - 1);
					num2++;
					array[num2] = pixels[num];
				}
			}
			break;
		}
		case Rotation.HalfCircle:
		{
			int num3 = pixels.Length - 1;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					num2++;
					array[num2] = pixels[num3 - num2];
				}
			}
			break;
		}
		default:
			array = pixels;
			break;
		}
		return array;
	}
}
