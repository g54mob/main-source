using System;
using UnityEngine;

namespace TriLib
{
	public static class Texture2DUtils
	{
		public static Texture2D ProcessTexture(EmbeddedTextureData embeddedTextureData, string name, ref bool hasAlphaChannel, bool isNormalMap = false, TextureWrapMode textureWrapMode = TextureWrapMode.Repeat, FilterMode textureFilterMode = FilterMode.Bilinear, TextureCompression textureCompression = TextureCompression.None, bool checkAlphaChannel = false, bool generateMipMaps = true)
		{
			Texture2D result = null;
			if (!(embeddedTextureData.DataPointer == IntPtr.Zero) && embeddedTextureData.DataLength > 0 && ApplyTextureData(embeddedTextureData, out var outputTexture2D))
			{
				result = ProcessTextureData(outputTexture2D, name, ref hasAlphaChannel, textureWrapMode, textureFilterMode, textureCompression, isNormalMap, checkAlphaChannel, generateMipMaps);
			}
			embeddedTextureData.Dispose();
			return result;
		}

		private static bool ApplyTextureData(EmbeddedTextureData embeddedTextureData, out Texture2D outputTexture2D)
		{
			if (embeddedTextureData.Data == null && embeddedTextureData.DataPointer == IntPtr.Zero)
			{
				outputTexture2D = null;
				return false;
			}
			try
			{
				outputTexture2D = new Texture2D(embeddedTextureData.Width, embeddedTextureData.Height, TextureFormat.RGBA32, mipChain: false);
				if (embeddedTextureData.DataPointer != IntPtr.Zero)
				{
					outputTexture2D.LoadRawTextureData(embeddedTextureData.DataPointer, embeddedTextureData.DataLength);
				}
				else
				{
					outputTexture2D.LoadRawTextureData(embeddedTextureData.Data);
				}
				outputTexture2D.Apply();
				return true;
			}
			catch
			{
				outputTexture2D = null;
				return false;
			}
		}

		private static Texture2D ProcessTextureData(Texture2D texture2D, string name, ref bool hasAlphaChannel, TextureWrapMode textureWrapMode, FilterMode textureFilterMode, TextureCompression textureCompression, bool isNormalMap, bool checkAlphaChannel = false, bool generateMipMaps = false)
		{
			if (texture2D == null)
			{
				return null;
			}
			if (string.IsNullOrEmpty(name))
			{
				texture2D.name = StringUtils.GenerateUniqueName(texture2D);
			}
			texture2D.name = name;
			texture2D.wrapMode = textureWrapMode;
			texture2D.filterMode = textureFilterMode;
			Color32[] pixels = texture2D.GetPixels32();
			if (isNormalMap)
			{
				Texture2D texture2D2 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.RGBA32, generateMipMaps);
				texture2D2.name = texture2D.name;
				texture2D2.wrapMode = texture2D.wrapMode;
				texture2D2.filterMode = texture2D.filterMode;
				for (int i = 0; i < pixels.Length; i++)
				{
					Color32 color = pixels[i];
					byte r = color.r;
					color.r = color.a;
					color.a = r;
					pixels[i] = color;
				}
				texture2D2.SetPixels32(pixels);
				texture2D2.Apply(generateMipMaps);
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(texture2D);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(texture2D);
				}
				texture2D = texture2D2;
			}
			if (!isNormalMap && generateMipMaps)
			{
				Texture2D texture2D3 = new Texture2D(texture2D.width, texture2D.height, TextureFormat.RGBA32, mipChain: true);
				texture2D3.name = texture2D.name;
				texture2D3.wrapMode = texture2D.wrapMode;
				texture2D3.filterMode = texture2D.filterMode;
				texture2D3.SetPixels32(pixels);
				texture2D3.Apply(updateMipmaps: true);
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(texture2D);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(texture2D);
				}
				texture2D = texture2D3;
			}
			if (textureCompression != TextureCompression.None && IsPowerOf2(texture2D.width) && IsPowerOf2(texture2D.height))
			{
				texture2D.Compress(textureCompression == TextureCompression.HighQuality);
			}
			if (checkAlphaChannel)
			{
				hasAlphaChannel = false;
				Color32[] array = pixels;
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].a != byte.MaxValue)
					{
						hasAlphaChannel = true;
						break;
					}
				}
			}
			return texture2D;
		}

		private static bool IsPowerOf2(int x)
		{
			return (x & (x - 1)) == 0;
		}
	}
}
