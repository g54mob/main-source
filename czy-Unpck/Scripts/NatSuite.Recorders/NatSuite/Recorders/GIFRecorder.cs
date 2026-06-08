using System;
using NatSuite.Recorders.Internal;

namespace NatSuite.Recorders
{
	public sealed class GIFRecorder : NativeRecorder
	{
		public GIFRecorder(int width, int height, float frameDuration)
			: base(Create(width, height, frameDuration))
		{
		}

		public override void CommitFrame<T>(T[] pixelBuffer, long timestamp = 0L)
		{
			base.CommitFrame(pixelBuffer, timestamp);
		}

		public unsafe override void CommitFrame(void* nativeBuffer, long timestamp = 0L)
		{
			base.CommitFrame(nativeBuffer, timestamp);
		}

		public override void CommitSamples(float[] sampleBuffer, long timestamp)
		{
			base.CommitSamples(sampleBuffer, timestamp);
		}

		public unsafe override void CommitSamples(float* nativeBuffer, int sampleCount, long timestamp)
		{
			base.CommitSamples(nativeBuffer, sampleCount, timestamp);
		}

		private static IntPtr Create(int width, int height, float frameDuration)
		{
			Bridge.CreateGIFRecorder(Utility.GetPath(".gif"), width, height, frameDuration, out var intPtr);
			if (intPtr != IntPtr.Zero)
			{
				return intPtr;
			}
			throw new InvalidOperationException("Failed to create GIFRecorder");
		}
	}
}
