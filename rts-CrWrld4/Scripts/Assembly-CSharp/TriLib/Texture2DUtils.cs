using UnityEngine;

namespace TriLib
{
	public static class Texture2DUtils
	{
		public static Texture2D ProcessTexture(EmbeddedTextureData embeddedTextureData, string name, ref bool hasAlphaChannel, bool isNormalMap = false, TextureWrapMode textureWrapMode = TextureWrapMode.Repeat, FilterMode textureFilterMode = FilterMode.Bilinear, TextureCompression textureCompression = TextureCompression.None, bool checkAlphaChannel = false, bool generateMipMaps = true)
		{
			return null;
		}

		private static bool ApplyTextureData(EmbeddedTextureData embeddedTextureData, out Texture2D outputTexture2D)
		{
			outputTexture2D = null;
			return false;
		}

		private static Texture2D ProcessTextureData(Texture2D texture2D, string name, ref bool hasAlphaChannel, TextureWrapMode textureWrapMode, FilterMode textureFilterMode, TextureCompression textureCompression, bool isNormalMap, bool checkAlphaChannel = false, bool generateMipMaps = false)
		{
			return null;
		}

		private static bool IsPowerOf2(int x)
		{
			return false;
		}
	}
}
