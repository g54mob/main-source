using System;
using UnityEngine;
using UnityEngine.Rendering;
using VideoKit.Clocks;
using VideoKit.Internal;

namespace VideoKit.Sources
{
	public sealed class TextureSource : IDisposable
	{
		public Texture? texture;

		public Texture? watermark;

		public RectInt watermarkRect;

		public bool watermarkAspectFit = true;

		public RectInt regionOfInterest;

		public int frameSkip;

		private Action<PixelBuffer>? handler;

		private readonly IClock? clock;

		private readonly RenderTextureDescriptor descriptor;

		private int frameIdx;

		private Texture2D? readbackBuffer;

		public TextureSource(int width, int height, Action<PixelBuffer> handler, IClock? clock = null)
		{
			this.handler = handler;
			this.clock = clock;
			descriptor = new RenderTextureDescriptor(width, height, RenderTextureFormat.ARGB32, 0)
			{
				sRGB = true
			};
			regionOfInterest = new RectInt(0, 0, width, height);
			VideoKitEvents.Instance.onFrame += OnFrame;
		}

		public void Append(Texture texture, long timestamp = 0L)
		{
			if (handler == null)
			{
				return;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(descriptor);
			Preprocess(texture, temporary);
			if (SystemInfo.supportsAsyncGPUReadback)
			{
				AsyncGPUReadback.Request(temporary, 0, TextureFormat.RGBA32, delegate(AsyncGPUReadbackRequest request)
				{
					if (handler != null)
					{
						if (!request.hasError)
						{
							using (PixelBuffer obj2 = new PixelBuffer(request.width, request.height, PixelBuffer.Format.RGBA8888, request.GetData<byte>(), 0, timestamp))
							{
								handler(obj2);
								return;
							}
						}
						Debug.LogWarning("VideoKit TextureSource failed to readback texture data");
					}
				});
			}
			else
			{
				readbackBuffer = ((readbackBuffer != null) ? readbackBuffer : new Texture2D(descriptor.width, descriptor.height, TextureFormat.RGBA32, mipChain: false));
				RenderTexture active = RenderTexture.active;
				RenderTexture.active = temporary;
				readbackBuffer.ReadPixels(new Rect(0f, 0f, descriptor.width, descriptor.height), 0, 0, recalculateMipMaps: false);
				using PixelBuffer obj = new PixelBuffer(descriptor.width, descriptor.height, PixelBuffer.Format.RGBA8888, readbackBuffer.GetRawTextureData<byte>(), 0, timestamp);
				handler(obj);
				RenderTexture.active = active;
			}
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void Dispose()
		{
			VideoKitEvents optionalInstance = VideoKitEvents.OptionalInstance;
			if (optionalInstance != null)
			{
				optionalInstance.onFrame -= OnFrame;
			}
			handler = null;
			UnityEngine.Object.Destroy(readbackBuffer);
		}

		private void OnFrame()
		{
			if (texture != null && frameIdx++ % (frameSkip + 1) == 0)
			{
				Append(texture, clock?.timestamp ?? 0);
			}
		}

		private void Preprocess(Texture source, RenderTexture destination)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(descriptor);
			ExtractRoI(source, temporary);
			RenderTexture temporary2 = RenderTexture.GetTemporary(descriptor);
			ApplyWatermark(temporary, temporary2);
			Graphics.Blit(temporary2, destination);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
		}

		private void ExtractRoI(Texture source, RenderTexture destination)
		{
			Vector2 vector = new Vector2(destination.width, destination.height);
			Vector2 vector2 = new Vector2(vector.x / (float)regionOfInterest.width, vector.y / (float)regionOfInterest.height);
			float num = Mathf.Max(vector2.x, vector2.y);
			Vector2 vector3 = num * vector;
			Vector2 vector4 = 0.5f * vector - num * regionOfInterest.center;
			Vector2 vector5 = vector4 + vector3;
			Rect screenRect = new Rect(vector4.x, (float)destination.height - vector5.y, vector3.x, vector3.y);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = destination;
			GL.Clear(clearDepth: true, clearColor: true, Color.clear);
			GL.PushMatrix();
			GL.LoadPixelMatrix(0f, destination.width, destination.height, 0f);
			Graphics.DrawTexture(screenRect, source);
			GL.PopMatrix();
			RenderTexture.active = active;
		}

		private void ApplyWatermark(Texture source, RenderTexture destination)
		{
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = destination;
			GL.Clear(clearDepth: true, clearColor: true, Color.clear);
			GL.PushMatrix();
			GL.LoadPixelMatrix(0f, destination.width, destination.height, 0f);
			Graphics.Blit(source, destination);
			if (watermark != null)
			{
				Rect screenRect = (watermarkAspectFit ? AspectFitRect(watermark, watermarkRect) : ToRect(watermarkRect));
				screenRect.y = (float)destination.height - screenRect.max.y;
				Graphics.DrawTexture(screenRect, watermark);
			}
			GL.PopMatrix();
			RenderTexture.active = active;
		}

		private static Rect AspectFitRect(Texture watermark, RectInt frame)
		{
			float num = (float)frame.width / (float)frame.height;
			float num2 = (float)watermark.width / (float)watermark.height;
			bool num3 = num2 > num;
			float num4 = (num3 ? ((float)frame.width) : ((float)frame.height * num2));
			float num5 = (num3 ? ((float)frame.width / num2) : ((float)frame.height));
			float num6 = 0.5f * ((float)frame.width - num4);
			float num7 = 0.5f * ((float)frame.height - num5);
			return new Rect((float)frame.x + num6, (float)frame.y + num7, num4, num5);
		}

		private static Rect ToRect(RectInt rect)
		{
			return new Rect(rect.x, rect.y, rect.width, rect.height);
		}
	}
}
