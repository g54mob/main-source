using System;
using NatSuite.Recorders.Internal;

namespace NatSuite.Recorders
{
	public sealed class HEVCRecorder : NativeRecorder
	{
		public HEVCRecorder(int width, int height, float frameRate, int sampleRate = 0, int channelCount = 0, int videoBitRate = 10000000, int keyframeInterval = 2, int audioBitRate = 64000)
			: base(Create(width, height, frameRate, sampleRate, channelCount, videoBitRate, keyframeInterval, audioBitRate))
		{
		}

		private static IntPtr Create(int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitRate, int keyframeInterval, int audioBitRate)
		{
			Bridge.CreateHEVCRecorder(Utility.GetPath(".mp4"), width, height, frameRate, sampleRate, channelCount, videoBitRate, keyframeInterval, audioBitRate, out var intPtr);
			if (intPtr != IntPtr.Zero)
			{
				return intPtr;
			}
			throw new InvalidOperationException("Failed to create HEVCRecorder");
		}
	}
}
