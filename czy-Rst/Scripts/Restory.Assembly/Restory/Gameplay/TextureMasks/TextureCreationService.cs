using System;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.TextureMasks
{
	public class TextureCreationService : IInitializable, IDisposable
	{
		private RenderTexture cleanRenderTexture;

		private RenderTextureFormat cleanRenderTextureFormat;

		public void Initialize()
		{
		}

		public void Dispose()
		{
			ReleaseCleanRenderTexture();
		}

		public Texture2D CreateCleanTexture(int width, int height, TextureFormat textureFormat, bool linear, FilterMode filterMode = FilterMode.Bilinear, TextureWrapMode wrapMode = TextureWrapMode.Clamp)
		{
			Texture2D texture2D = new Texture2D(width, height, textureFormat, mipChain: false, linear)
			{
				filterMode = filterMode,
				wrapMode = wrapMode
			};
			ClearTexture(texture2D);
			return texture2D;
		}

		public void ClearTexture(Texture2D texture)
		{
			if ((bool)texture)
			{
				RenderTexture renderTexture = GetCleanRenderTexture(texture);
				ClearRenderTexture(renderTexture);
				Graphics.CopyTexture(renderTexture, texture);
			}
		}

		private RenderTexture GetCleanRenderTexture(Texture2D texture)
		{
			RenderTextureFormat renderTextureFormat = GetRenderTextureFormat(texture.format);
			if (!cleanRenderTexture || cleanRenderTexture.width != texture.width || cleanRenderTexture.height != texture.height || cleanRenderTextureFormat != renderTextureFormat)
			{
				ReleaseCleanRenderTexture();
				cleanRenderTexture = new RenderTexture(texture.width, texture.height, 0, renderTextureFormat, RenderTextureReadWrite.Linear);
				cleanRenderTexture.Create();
				cleanRenderTextureFormat = renderTextureFormat;
			}
			return cleanRenderTexture;
		}

		private void ClearRenderTexture(RenderTexture renderTexture)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			GL.Clear(clearDepth: true, clearColor: true, Color.clear);
			RenderTexture.active = active;
		}

		private void ReleaseCleanRenderTexture()
		{
			if ((bool)cleanRenderTexture)
			{
				cleanRenderTexture.Release();
				cleanRenderTexture = null;
			}
		}

		private RenderTextureFormat GetRenderTextureFormat(TextureFormat textureFormat)
		{
			return textureFormat switch
			{
				TextureFormat.R8 => RenderTextureFormat.R8, 
				TextureFormat.RGBA32 => RenderTextureFormat.ARGB32, 
				TextureFormat.ARGB32 => RenderTextureFormat.ARGB32, 
				TextureFormat.RGBA64 => RenderTextureFormat.ARGB64, 
				TextureFormat.RGBAHalf => RenderTextureFormat.ARGBHalf, 
				TextureFormat.RGBAFloat => RenderTextureFormat.ARGBFloat, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
