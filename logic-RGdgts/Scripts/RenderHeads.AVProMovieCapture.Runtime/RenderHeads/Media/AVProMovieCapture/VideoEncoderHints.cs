using System;
using System.Runtime.InteropServices;

namespace RenderHeads.Media.AVProMovieCapture
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public class VideoEncoderHints
	{
		public enum ColourSpace
		{
			Unknown = -1,
			Gamma = 0,
			Linear = 1
		}

		public uint averageBitrate;

		public uint maximumBitrate;

		public float quality;

		public uint keyframeInterval;

		public bool allowFastStartStreamingPostProcess;

		public bool supportTransparency;

		public bool useHardwareEncoding;

		public NoneAutoCustom injectStereoPacking;

		public StereoPacking stereoPacking;

		public NoneAutoCustom injectSphericalVideoLayout;

		public SphericalVideoLayout sphericalVideoLayout;

		public bool enableFragmentedWriting;

		public double movieFragmentInterval;

		public ColourSpace colourSpace;

		public int sourceWidth;

		public int sourceHeight;

		public bool androidNoCaptureRotation;

		public Transparency transparency;

		public AndroidVulkanPreTransform androidVulkanPreTransform;

		public void SetDefaults()
		{
		}

		internal void Validate()
		{
		}
	}
}
