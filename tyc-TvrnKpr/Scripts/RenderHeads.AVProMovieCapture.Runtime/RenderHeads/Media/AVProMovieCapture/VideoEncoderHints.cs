using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RenderHeads.Media.AVProMovieCapture
{
	[Serializable]
	[StructLayout((LayoutKind)0)]
	public class VideoEncoderHints
	{
		public enum ColourSpace
		{
			Unknown = -1,
			Gamma = 0,
			Linear = 1
		}

		[Tooltip("Average number of bits per second for the resulting video. Zero uses the codec defaults.")]
		public uint averageBitrate;

		[Tooltip("Maximum number of bits per second for the resulting video. Zero uses the codec defaults.")]
		public uint maximumBitrate;

		[Range(0f, 1f)]
		public float quality;

		[Tooltip("How often a keyframe is inserted.  Zero uses the codec defaults.")]
		public uint keyframeInterval;

		[Tooltip("Move the 'moov' atom in the video file from the end to the start of the file to make streaming start fast.  Also known as 'Fast Start' in some encoders")]
		public bool allowFastStartStreamingPostProcess;

		[Tooltip("Hints to the encoder to use the alpha channel for transparency if possible")]
		public bool supportTransparency;

		public bool useHardwareEncoding;

		[Tooltip("Enable Constant Quality")]
		public bool enableConstantQuality;

		[Tooltip("Enable fragmented writing support for QuickTime (mov, mp4) files")]
		public bool enableFragmentedWriting;

		public bool androidNoCaptureRotation;

		public bool iOSSaveCaptureWhenAppLosesFocus;

		public bool padding;

		[Tooltip("Inject atoms to define stereo video mode")]
		public NoneAutoCustom injectStereoPacking;

		[Tooltip("Inject atoms to define stereo video mode")]
		public StereoPacking stereoPacking;

		[Tooltip("Inject atoms to define spherical video layout")]
		public NoneAutoCustom injectSphericalVideoLayout;

		[Tooltip("Inject atoms to define spherical video layout")]
		public SphericalVideoLayout sphericalVideoLayout;

		[Tooltip("The interval at which to write movie fragments in seconds")]
		[Range(0f, 300f)]
		public double movieFragmentInterval;

		public ColourSpace colourSpace;

		public int sourceWidth;

		public int sourceHeight;

		[Tooltip("Transparency mode")]
		public Transparency transparency;

		public AndroidVulkanPreTransform androidVulkanPreTransform;

		[Tooltip("Use Limited range for maximum compatibility")]
		public ColourRange colourRange;

		[Tooltip("Options for controlling the presentation timestamp for each frame that is captured")]
		public RealtimeFramePresentationTimestampOptions realtimeFramePresentationTimestampOptions;

		public OrientationMetadata orientationMetadata;

		public void SetDefaults()
		{
		}

		internal void Validate()
		{
		}
	}
}
