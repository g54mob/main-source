using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[Serializable]
	[StructLayout((LayoutKind)0)]
	public class ImageEncoderHints
	{
		public enum ColourSpace
		{
			Unknown = -1,
			Gamma = 0,
			Linear = 1
		}

		[Range(0f, 1f)]
		public float quality;

		[Tooltip("Hints to the encoder to use the alpha channel for transparency if possible")]
		public bool supportTransparency;

		public ColourSpace colourSpace;

		public int sourceWidth;

		public int sourceHeight;

		[Tooltip("Transparency mode")]
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
