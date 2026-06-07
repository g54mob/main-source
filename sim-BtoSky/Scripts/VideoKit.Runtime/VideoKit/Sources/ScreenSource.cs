using System;
using UnityEngine;
using VideoKit.Clocks;
using VideoKit.Internal;

namespace VideoKit.Sources
{
	public sealed class ScreenSource : IDisposable
	{
		public readonly TextureSource textureSource;

		public int frameSkip;

		private readonly IClock? clock;

		private readonly RenderTextureDescriptor descriptor;

		private int frameIdx;

		public ScreenSource(int width, int height, Action<PixelBuffer> handler, IClock? clock = null, bool useLateUpdate = false)
		{
			this.clock = clock;
			descriptor = new RenderTextureDescriptor(width, height, RenderTextureFormat.ARGBHalf, 0);
			textureSource = new TextureSource(width, height, handler);
			if (useLateUpdate)
			{
				VideoKitEvents.Instance.onLateUpdate += OnFrame;
			}
			else
			{
				VideoKitEvents.Instance.onFrame += OnFrame;
			}
		}

		public void Dispose()
		{
			VideoKitEvents optionalInstance = VideoKitEvents.OptionalInstance;
			if (optionalInstance != null)
			{
				optionalInstance.onLateUpdate -= OnFrame;
				optionalInstance.onFrame -= OnFrame;
			}
			textureSource.Dispose();
		}

		private void OnFrame()
		{
			if (frameIdx++ % (frameSkip + 1) == 0)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(Screen.width, Screen.height, 0, RenderTextureFormat.ARGBHalf);
				RenderTexture temporary2 = RenderTexture.GetTemporary(descriptor);
				ScreenCapture.CaptureScreenshotIntoRenderTexture(temporary);
				Graphics.Blit(temporary, temporary2, SystemInfo.graphicsUVStartsAtTop ? new Vector2(1f, -1f) : Vector2.one, SystemInfo.graphicsUVStartsAtTop ? Vector2.up : Vector2.zero);
				textureSource.Append(temporary2, clock?.timestamp ?? 0);
				RenderTexture.ReleaseTemporary(temporary2);
				RenderTexture.ReleaseTemporary(temporary);
			}
		}

		[Obsolete("Deprecated in VideoKit 0.0.23. Use the ScreenSource(width, height, handler, clock) constructor instead.", false)]
		public ScreenSource(MediaRecorder recorder, IClock? clock = null, bool useLateUpdate = false)
			: this(recorder.width, recorder.height, recorder.Append, clock, useLateUpdate)
		{
		}
	}
}
