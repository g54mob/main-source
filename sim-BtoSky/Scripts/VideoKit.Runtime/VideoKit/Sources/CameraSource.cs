using System;
using UnityEngine;
using VideoKit.Clocks;
using VideoKit.Internal;

namespace VideoKit.Sources
{
	public sealed class CameraSource : IDisposable
	{
		public readonly Camera[] cameras;

		public readonly TextureSource textureSource;

		public int frameSkip;

		private readonly IClock? clock;

		private readonly RenderTextureDescriptor descriptor;

		private int frameIdx;

		public CameraSource(int width, int height, Camera camera, Action<PixelBuffer> handler, IClock? clock = null)
			: this(width, height, new Camera[1] { camera }, handler, clock)
		{
		}

		public CameraSource(int width, int height, Camera[] cameras, Action<PixelBuffer> handler, IClock? clock = null)
		{
			Array.Sort(cameras, (Camera a, Camera b) => (int)(100f * (a.depth - b.depth)));
			this.cameras = cameras;
			this.clock = clock;
			descriptor = new RenderTextureDescriptor(width, height, RenderTextureFormat.ARGBHalf, 24)
			{
				sRGB = true,
				msaaSamples = Mathf.Max(QualitySettings.antiAliasing, 1)
			};
			textureSource = new TextureSource(width, height, handler);
			VideoKitEvents.Instance.onFrame += OnFrame;
		}

		public void Dispose()
		{
			VideoKitEvents optionalInstance = VideoKitEvents.OptionalInstance;
			if (optionalInstance != null)
			{
				optionalInstance.onFrame -= OnFrame;
			}
			textureSource.Dispose();
		}

		private void OnFrame()
		{
			if (frameIdx++ % (frameSkip + 1) != 0)
			{
				return;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(descriptor);
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = temporary;
			GL.Clear(clearDepth: true, clearColor: true, Color.clear);
			RenderTexture.active = active;
			for (int i = 0; i < cameras.Length; i++)
			{
				Camera camera = cameras[i];
				if ((bool)camera)
				{
					RenderTexture targetTexture = camera.targetTexture;
					camera.targetTexture = temporary;
					camera.Render();
					camera.targetTexture = targetTexture;
				}
			}
			textureSource.Append(temporary, clock?.timestamp ?? 0);
			RenderTexture.ReleaseTemporary(temporary);
		}

		[Obsolete("Deprecated in VideoKit 0.0.23. Use the CameraSource(width, height, cameras, handler, clock) constructor instead.", false)]
		public CameraSource(MediaRecorder recorder, params Camera[] cameras)
			: this(recorder.width, recorder.height, cameras, recorder.Append)
		{
		}

		[Obsolete("Deprecated in VideoKit 0.0.23. Use the CameraSource(width, height, cameras, handler, clock) constructor instead.", false)]
		public CameraSource(MediaRecorder recorder, IClock? clock, params Camera[] cameras)
			: this(recorder.width, recorder.height, cameras, recorder.Append, clock)
		{
		}
	}
}
