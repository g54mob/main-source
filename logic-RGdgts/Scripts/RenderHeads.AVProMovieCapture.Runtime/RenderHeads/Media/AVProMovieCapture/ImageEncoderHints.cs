using System;
using System.Runtime.InteropServices;

namespace RenderHeads.Media.AVProMovieCapture
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public class ImageEncoderHints
	{
		public enum ColourSpace
		{
			Unknown = -1,
			Gamma = 0,
			Linear = 1
		}

		public float quality;

		public bool supportTransparency;

		public ColourSpace colourSpace;

		public int sourceWidth;

		public int sourceHeight;

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
