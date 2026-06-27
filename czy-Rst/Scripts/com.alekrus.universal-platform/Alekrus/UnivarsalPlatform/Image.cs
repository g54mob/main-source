using System;
using UnityEngine;

namespace Alekrus.UnivarsalPlatform
{
	public class Image
	{
		public uint Width;

		public uint Height;

		public byte[] Data;

		public Image(uint parWidth, uint parHeight, byte[] parData)
		{
			Width = parWidth;
			Height = parHeight;
			Data = parData;
		}

		public Color GetPixel(int x, int y)
		{
			if (x < 0 || x >= Width)
			{
				throw new ArgumentException("x out of bounds");
			}
			if (y < 0 || y >= Height)
			{
				throw new ArgumentException("y out of bounds");
			}
			Color result = default(Color);
			long num = (y * Width + x) * 4;
			result.r = (int)Data[num];
			result.g = (int)Data[num + 1];
			result.b = (int)Data[num + 2];
			result.a = (int)Data[num + 3];
			return result;
		}

		public override string ToString()
		{
			return $"{Width}x{Height} ({Data.Length} bytes)";
		}
	}
}
