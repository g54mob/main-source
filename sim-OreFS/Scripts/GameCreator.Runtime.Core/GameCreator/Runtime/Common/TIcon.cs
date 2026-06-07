using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class TIcon : IIcon
	{
		private const TextureFormat FORMAT = TextureFormat.RGBA32;

		private const int WIDTH = 64;

		private const int HEIGHT = 64;

		[NonSerialized]
		private static readonly Dictionary<int, Texture2D> Cache = new Dictionary<int, Texture2D>();

		[NonSerialized]
		private readonly Color m_Tint;

		[NonSerialized]
		private readonly IIcon m_Overlay;

		protected virtual ColorTheme.Type OverlayColor => ColorTheme.Type.Blue;

		protected virtual byte[] Bytes => null;

		public Texture2D Texture
		{
			get
			{
				int hashCode = GetHashCode();
				if (Cache.TryGetValue(hashCode, out var value) && value != null)
				{
					return value;
				}
				Texture2D texture2D = m_Overlay?.Texture;
				Color b = ColorTheme.Get(OverlayColor);
				value = new Texture2D(64, 64, TextureFormat.RGBA32, mipChain: false);
				value.LoadRawTextureData(Bytes);
				for (int i = 0; i < 64; i++)
				{
					for (int j = 0; j < 64; j++)
					{
						Color pixel = value.GetPixel(i, j);
						Color color = new Color(pixel.r * m_Tint.r, pixel.g * m_Tint.g, pixel.b * m_Tint.b, pixel.a);
						if (texture2D != null)
						{
							Color pixel2 = texture2D.GetPixel(i, j);
							color = Color.Lerp(color, b, 1f - pixel2.r);
							color.a *= 1f - pixel2.g;
						}
						value.SetPixel(i, j, color);
					}
				}
				value.Apply();
				Cache[hashCode] = value;
				return value;
			}
		}

		public override int GetHashCode()
		{
			int num = GetType().GetHashCode() ^ m_Tint.GetHashCode();
			if (m_Overlay != null)
			{
				num ^= m_Overlay.GetHashCode() ^ OverlayColor.GetHashCode();
			}
			return num;
		}

		protected TIcon(Color color, IIcon overlay)
		{
			m_Tint = color;
			m_Overlay = overlay;
		}
	}
}
