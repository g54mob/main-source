using System;
using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickSprite
	{
		public readonly Vector2Int size;

		public readonly byte[] pixels;

		public BrickSprite(int[] pixels, Vector2Int size)
		{
			if (pixels.Length != size.x * size.y)
			{
				Debug.LogError(string.Format("{0}: Invalid pixel array size! Expected {1}, got {2}.", "BrickSprite", size.x * size.y, pixels.Length));
			}
			this.pixels = new byte[pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
			{
				this.pixels[i] = (byte)((pixels[i] > 0) ? byte.MaxValue : 0);
			}
			this.size = size;
		}

		public BrickSprite(Texture2D texture)
		{
			if (texture == null)
			{
				throw new NullReferenceException("Invalid texture reference! BrickSprite got bricked!");
			}
			if (!texture.isReadable)
			{
				throw new InvalidOperationException("Texture is not readable! BrickSprite got bricked!");
			}
			if (texture.format != TextureFormat.Alpha8)
			{
				throw new InvalidOperationException(string.Format("Invalid texture format! Expected {0}, got {1}. {2} got bricked!", TextureFormat.Alpha8, texture.format, "BrickSprite"));
			}
			size = new Vector2Int(texture.width, texture.height);
			pixels = new byte[size.x * size.y];
			byte[] rawTextureData = texture.GetRawTextureData();
			for (int i = 0; i < size.y; i++)
			{
				Array.Copy(rawTextureData, (size.y - i - 1) * size.x, pixels, i * size.x, size.x);
			}
		}
	}
}
