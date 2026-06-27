using System;
using UnityEngine;

namespace Mandragora.PWS
{
	public static class TextureScaler
	{
		public static Texture2D Scaled(Texture2D sourceTexture, int width, int height, FilterMode mode = FilterMode.Bilinear)
		{
			if (sourceTexture == null)
			{
				return null;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);
			temporary.filterMode = mode;
			Graphics.Blit(sourceTexture, temporary);
			Texture2D obj = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false)
			{
				filterMode = mode
			};
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			obj.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
			obj.Apply();
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			return obj;
		}

		public static void Scale(Texture2D sourceTexture, int width, int height, FilterMode mode = FilterMode.Bilinear)
		{
			if (!(sourceTexture == null) && (sourceTexture.width != width || sourceTexture.height != height))
			{
				Texture2D texture2D = Scaled(sourceTexture, width, height, mode);
				try
				{
					sourceTexture.Reinitialize(width, height, sourceTexture.format, sourceTexture.mipmapCount > 1);
					Graphics.CopyTexture(texture2D, sourceTexture);
				}
				catch (Exception)
				{
					RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32);
					Graphics.Blit(texture2D, temporary);
					RenderTexture active = RenderTexture.active;
					RenderTexture.active = temporary;
					sourceTexture.Reinitialize(width, height);
					sourceTexture.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
					sourceTexture.Apply();
					RenderTexture.active = active;
					RenderTexture.ReleaseTemporary(temporary);
				}
				UnityEngine.Object.Destroy(texture2D);
			}
		}

		private static RenderTexture GpuScale(Texture2D sourceTexture, int width, int height, FilterMode fmode)
		{
			sourceTexture.filterMode = fmode;
			sourceTexture.Apply(updateMipmaps: true);
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0, RenderTextureFormat.ARGB32);
			temporary.filterMode = fmode;
			_ = RenderTexture.active;
			RenderTexture.active = temporary;
			GL.Clear(clearDepth: true, clearColor: true, new Color(0f, 0f, 0f, 0f));
			Graphics.Blit(sourceTexture, temporary);
			return temporary;
		}
	}
}
