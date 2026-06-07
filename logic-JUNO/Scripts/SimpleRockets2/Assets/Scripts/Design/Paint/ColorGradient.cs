using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Design.Paint
{
	public class ColorGradient
	{
		public class Shade
		{
			public Color Color { get; set; }

			public ColorGradient ColorGradient { get; set; }

			public int End { get; set; }

			public int Start { get; set; }

			public int Width => End - Start;

			public Shade(Vector3 color)
			{
				Color = new Color(color.x, color.y, color.z);
			}
		}

		public List<Vector3> Colors { get; private set; }

		public List<Shade> Shades { get; private set; }

		public int ShadesBetweenColors { get; set; }

		public ColorGradient()
		{
			Colors = new List<Vector3>();
			Shades = new List<Shade>();
		}

		public void CalculateShades()
		{
			for (int i = 0; i < Colors.Count - 1; i++)
			{
				Vector3 vector = Colors[i];
				Vector3 vector2 = (Colors[i + 1] - vector) / (ShadesBetweenColors + 1);
				for (int j = 0; j < ShadesBetweenColors + 1; j++)
				{
					Shade item = new Shade(vector);
					Shades.Add(item);
					vector += vector2;
				}
			}
			Shade item2 = new Shade(Colors[Colors.Count - 1]);
			Shades.Add(item2);
		}

		public Texture2D GenerateTexture(int width, int height)
		{
			Texture2D texture2D = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false);
			texture2D.filterMode = FilterMode.Point;
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.name = "ColorGradientTexture";
			UpdateTexture(texture2D);
			return texture2D;
		}

		public void UpdateTexture(Texture2D texture)
		{
			float num = (float)texture.width / (float)Shades.Count;
			float num2 = 0f;
			foreach (Shade shade in Shades)
			{
				int left = (shade.Start = (int)num2);
				num2 += num;
				int right = (shade.End = (int)num2);
				DrawPixels(texture, left, 0, right, texture.height, shade.Color);
			}
			texture.Apply();
		}

		private static void DrawPixels(Texture2D texture, int left, int top, int right, int bottom, Color color)
		{
			for (int i = left; i < right; i++)
			{
				for (int j = top; j < bottom; j++)
				{
					texture.SetPixel(i, j, color);
				}
			}
		}
	}
}
