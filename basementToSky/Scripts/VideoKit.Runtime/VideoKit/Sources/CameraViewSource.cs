using System;
using VideoKit.Clocks;
using VideoKit.UI;

namespace VideoKit.Sources
{
	internal sealed class CameraViewSource : IDisposable
	{
		public int frameSkip;

		private readonly Action<PixelBuffer> handler;

		private readonly IClock? clock;

		private readonly VideoKitCameraView view;

		private int frameIdx;

		public CameraViewSource(VideoKitCameraView view, Action<PixelBuffer> handler, IClock? clock = null)
		{
			if (view.texture == null)
			{
				throw new ArgumentException("Cannot create camera view source because camera manager is not running");
			}
			this.handler = handler;
			this.clock = clock;
			this.view = view;
			view.OnPixelBuffer += OnPixelBuffer;
		}

		public void Dispose()
		{
			view.OnPixelBuffer -= OnPixelBuffer;
		}

		private void OnPixelBuffer(PixelBuffer pixelBuffer)
		{
			if (frameIdx++ % (frameSkip + 1) != 0)
			{
				return;
			}
			using PixelBuffer obj = new PixelBuffer(pixelBuffer.width, pixelBuffer.height, pixelBuffer.format, pixelBuffer.data, pixelBuffer.rowStride, clock?.timestamp ?? 0, pixelBuffer.verticallyMirrored);
			handler(obj);
		}
	}
}
