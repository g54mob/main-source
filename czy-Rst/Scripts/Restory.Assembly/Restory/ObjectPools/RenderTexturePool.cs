using System;
using System.Collections.Generic;
using UnityEngine;

namespace Restory.ObjectPools
{
	public class RenderTexturePool : IDisposable
	{
		private readonly Dictionary<string, Queue<RenderTexture>> availableTextures = new Dictionary<string, Queue<RenderTexture>>();

		private readonly HashSet<RenderTexture> activeTextures = new HashSet<RenderTexture>();

		private readonly int maxPoolSize;

		private readonly string textureNamePrefix;

		public RenderTexturePool(int maxPoolSize = 10, string textureNamePrefix = "PooledRenderTexture")
		{
			this.maxPoolSize = maxPoolSize;
			this.textureNamePrefix = textureNamePrefix;
		}

		private static string CreateTextureKey(int width, int height, RenderTextureFormat format, RenderTextureReadWrite readWrite)
		{
			return $"{width}x{height}_{format}_{readWrite}";
		}

		public void Prewarm(int amount, int width, int height, RenderTextureFormat format = RenderTextureFormat.ARGB32, RenderTextureReadWrite readWrite = RenderTextureReadWrite.sRGB, string textureName = null)
		{
			string key = CreateTextureKey(width, height, format, readWrite);
			for (int i = 0; i < amount; i++)
			{
				if (!availableTextures.TryGetValue(key, out var value))
				{
					value = new Queue<RenderTexture>();
					availableTextures[key] = value;
				}
				RenderTexture item = CreateTexture(textureName, width, height, format, readWrite);
				value.Enqueue(item);
			}
		}

		public RenderTexture Get(RenderTextureDescriptor descriptor, string textureName = null)
		{
			string key = CreateTextureKey(descriptor.width, descriptor.height, descriptor.colorFormat, (!descriptor.sRGB) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
			RenderTexture renderTexture;
			if (availableTextures.TryGetValue(key, out var value) && value.Count > 0)
			{
				renderTexture = value.Dequeue();
				if (renderTexture != null && renderTexture.IsCreated())
				{
					ClearTexture(renderTexture);
				}
				else
				{
					renderTexture = CreateTexture(textureName, descriptor.width, descriptor.height, descriptor.colorFormat, (!descriptor.sRGB) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
				}
			}
			else
			{
				renderTexture = CreateTexture(textureName, descriptor.width, descriptor.height, descriptor.colorFormat, (!descriptor.sRGB) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
			}
			activeTextures.Add(renderTexture);
			return renderTexture;
		}

		public RenderTexture Get(int width, int height, RenderTextureFormat format = RenderTextureFormat.ARGB32, RenderTextureReadWrite readWrite = RenderTextureReadWrite.sRGB, string textureName = null)
		{
			RenderTextureDescriptor renderTextureDescriptor = new RenderTextureDescriptor(width, height, format);
			renderTextureDescriptor.enableRandomWrite = true;
			renderTextureDescriptor.sRGB = readWrite == RenderTextureReadWrite.sRGB;
			RenderTextureDescriptor descriptor = renderTextureDescriptor;
			return Get(descriptor, textureName);
		}

		public void Release(RenderTexture texture)
		{
			if (!(texture == null) && activeTextures.Contains(texture))
			{
				activeTextures.Remove(texture);
				string key = CreateTextureKey(texture.width, texture.height, texture.format, (!texture.sRGB) ? RenderTextureReadWrite.Linear : RenderTextureReadWrite.sRGB);
				if (!availableTextures.ContainsKey(key))
				{
					availableTextures[key] = new Queue<RenderTexture>();
				}
				if (availableTextures[key].Count < maxPoolSize)
				{
					ClearTexture(texture);
					availableTextures[key].Enqueue(texture);
				}
				else
				{
					texture.Release();
				}
			}
		}

		public void Clear()
		{
			foreach (Queue<RenderTexture> value in availableTextures.Values)
			{
				RenderTexture result;
				while (value.TryDequeue(out result))
				{
					if (result != null)
					{
						result.Release();
					}
				}
			}
			foreach (RenderTexture activeTexture in activeTextures)
			{
				if (activeTexture != null)
				{
					activeTexture.Release();
				}
			}
			availableTextures.Clear();
			activeTextures.Clear();
		}

		public void Dispose()
		{
			Clear();
		}

		private RenderTexture CreateTexture(string textureName, RenderTextureDescriptor descriptor)
		{
			RenderTexture renderTexture = new RenderTexture(descriptor);
			renderTexture.name = textureName ?? $"{textureNamePrefix}_{activeTextures.Count}";
			renderTexture.Create();
			return renderTexture;
		}

		private RenderTexture CreateTexture(string textureName, int width, int height, RenderTextureFormat format, RenderTextureReadWrite readWrite)
		{
			RenderTextureDescriptor desc = new RenderTextureDescriptor(width, height, format);
			desc.enableRandomWrite = true;
			desc.sRGB = readWrite == RenderTextureReadWrite.sRGB;
			RenderTexture renderTexture = new RenderTexture(desc);
			renderTexture.name = textureName ?? $"{textureNamePrefix}_{activeTextures.Count}";
			renderTexture.Create();
			return renderTexture;
		}

		private static void ClearTexture(RenderTexture targetTexture)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = targetTexture;
			GL.Clear(clearDepth: true, clearColor: true, Color.black);
			RenderTexture.active = active;
		}
	}
}
