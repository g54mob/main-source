using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UTJ.FrameCapturer
{
	public static class fcAPI
	{
		public enum fcPixelFormat
		{
			Unknown = 0,
			ChannelMask = 15,
			TypeMask = 240,
			Type_f16 = 16,
			Type_f32 = 32,
			Type_u8 = 48,
			Type_i16 = 64,
			Type_i32 = 80,
			Rf16 = 17,
			RGf16 = 18,
			RGBf16 = 19,
			RGBAf16 = 20,
			Rf32 = 33,
			RGf32 = 34,
			RGBf32 = 35,
			RGBAf32 = 36,
			Ru8 = 49,
			RGu8 = 50,
			RGBu8 = 51,
			RGBAu8 = 52,
			Ri16 = 65,
			RGi16 = 66,
			RGBi16 = 67,
			RGBAi16 = 68,
			Ri32 = 81,
			RGi32 = 82,
			RGBi32 = 83,
			RGBAi32 = 84
		}

		public enum fcBitrateMode
		{
			CBR = 0,
			VBR = 1
		}

		public enum fcAudioBitsPerSample
		{
			_8Bits = 8,
			_16Bits = 16,
			_24Bits = 24
		}

		public struct fcDeferredCall
		{
			public int handle;

			public void Release()
			{
			}

			public static implicit operator int(fcDeferredCall v)
			{
				return 0;
			}
		}

		public struct fcStream
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcStream v)
			{
				return false;
			}
		}

		public enum fcPngPixelFormat
		{
			Auto = 0,
			UInt8 = 1,
			UInt16 = 2
		}

		[Serializable]
		public struct fcPngConfig
		{
			public fcPngPixelFormat pixelFormat;

			public int maxTasks;

			[HideInInspector]
			public int width;

			[HideInInspector]
			public int height;

			[HideInInspector]
			public int channels;

			public static fcPngConfig default_value => default(fcPngConfig);
		}

		public struct fcPngContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcPngContext v)
			{
				return false;
			}
		}

		public enum fcExrPixelFormat
		{
			Auto = 0,
			Half = 1,
			Float = 2,
			Int = 3
		}

		public enum fcExrCompression
		{
			None = 0,
			RLE = 1,
			ZipS = 2,
			Zip = 3,
			PIZ = 4
		}

		[Serializable]
		public struct fcExrConfig
		{
			public fcExrPixelFormat pixelFormat;

			public fcExrCompression compression;

			public int maxTasks;

			[HideInInspector]
			public int width;

			[HideInInspector]
			public int height;

			[HideInInspector]
			public int channels;

			public static fcExrConfig default_value => default(fcExrConfig);
		}

		public struct fcExrContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcExrContext v)
			{
				return false;
			}
		}

		[Serializable]
		public struct fcGifConfig
		{
			[HideInInspector]
			public int width;

			[HideInInspector]
			public int height;

			public int numColors;

			public int keyframeInterval;

			public int maxTasks;

			public static fcGifConfig default_value => default(fcGifConfig);
		}

		public struct fcGifContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcGifContext v)
			{
				return false;
			}
		}

		public enum fcMP4VideoFlags
		{
			H264NVIDIA = 2,
			H264AMD = 4,
			H264IntelHW = 8,
			H264IntelSW = 16,
			H264OpenH264 = 32,
			H264Mask = 62
		}

		public enum fcMP4AudioFlags
		{
			AACIntel = 2,
			AACFAAC = 4,
			AACMask = 6
		}

		[Serializable]
		public struct fcMP4Config
		{
			[HideInInspector]
			public Bool video;

			[HideInInspector]
			public int videoWidth;

			[HideInInspector]
			public int videoHeight;

			[HideInInspector]
			public int videoTargetFramerate;

			public fcBitrateMode videoBitrateMode;

			public int videoTargetBitrate;

			[HideInInspector]
			public int videoFlags;

			public int videoMaxTasks;

			[HideInInspector]
			public Bool audio;

			[HideInInspector]
			public int audioSampleRate;

			[HideInInspector]
			public int audioNumChannels;

			public fcBitrateMode audioBitrateMode;

			public int audioTargetBitrate;

			[HideInInspector]
			public int audioFlags;

			public int audioMaxTasks;

			public static fcMP4Config default_value => default(fcMP4Config);
		}

		public struct fcMP4Context
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcMP4Context v)
			{
				return false;
			}
		}

		public struct fcWebMContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcWebMContext v)
			{
				return false;
			}
		}

		public enum fcWebMVideoEncoder
		{
			VP8 = 0,
			VP9 = 1,
			VP9LossLess = 2
		}

		public enum fcWebMAudioEncoder
		{
			Vorbis = 0,
			Opus = 1
		}

		[Serializable]
		public struct fcWebMConfig
		{
			[HideInInspector]
			public Bool video;

			public fcWebMVideoEncoder videoEncoder;

			[HideInInspector]
			public int videoWidth;

			[HideInInspector]
			public int videoHeight;

			[HideInInspector]
			public int videoTargetFramerate;

			public fcBitrateMode videoBitrateMode;

			public int videoTargetBitrate;

			public int videoMaxTasks;

			[HideInInspector]
			public Bool audio;

			public fcWebMAudioEncoder audioEncoder;

			[HideInInspector]
			public int audioSampleRate;

			[HideInInspector]
			public int audioNumChannels;

			public fcBitrateMode audioBitrateMode;

			public int audioTargetBitrate;

			public int audioMaxTasks;

			public static fcWebMConfig default_value => default(fcWebMConfig);
		}

		public struct fcWaveContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcWaveContext v)
			{
				return false;
			}
		}

		[Serializable]
		public struct fcWaveConfig
		{
			[HideInInspector]
			public int sampleRate;

			[HideInInspector]
			public int numChannels;

			public fcAudioBitsPerSample bitsPerSample;

			public int maxTasks;

			public static fcWaveConfig default_value => default(fcWaveConfig);
		}

		public struct fcOggContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcOggContext v)
			{
				return false;
			}
		}

		[Serializable]
		public struct fcOggConfig
		{
			[HideInInspector]
			public int sampleRate;

			[HideInInspector]
			public int numChannels;

			public fcBitrateMode bitrateMode;

			public int targetBitrate;

			public int maxTasks;

			public static fcOggConfig default_value => default(fcOggConfig);
		}

		public struct fcFlacContext
		{
			public IntPtr ptr;

			public void Release()
			{
			}

			public static implicit operator bool(fcFlacContext v)
			{
				return false;
			}
		}

		[Serializable]
		public struct fcFlacConfig
		{
			[HideInInspector]
			public int sampleRate;

			[HideInInspector]
			public int numChannels;

			public fcAudioBitsPerSample bitsPerSample;

			public int compressionLevel;

			public int blockSize;

			[HideInInspector]
			public Bool verify;

			public int maxTasks;

			public static fcFlacConfig default_value => default(fcFlacConfig);
		}

		[PreserveSig]
		public static extern void fcSetModulePath(string path);

		[PreserveSig]
		public static extern double fcGetTime();

		[PreserveSig]
		public static extern fcStream fcCreateFileStream(string path);

		[PreserveSig]
		public static extern fcStream fcCreateMemoryStream();

		[PreserveSig]
		private static extern void fcReleaseStream(fcStream s);

		[PreserveSig]
		public static extern ulong fcStreamGetWrittenSize(fcStream s);

		[PreserveSig]
		public static extern void fcGuardBegin();

		[PreserveSig]
		public static extern void fcGuardEnd();

		[PreserveSig]
		public static extern fcDeferredCall fcAllocateDeferredCall();

		[PreserveSig]
		private static extern void fcReleaseDeferredCall(fcDeferredCall dc);

		[PreserveSig]
		public static extern IntPtr fcGetRenderEventFunc();

		public static void fcGuard(Action body)
		{
		}

		public static fcPixelFormat fcGetPixelFormat(RenderTextureFormat v)
		{
			return default(fcPixelFormat);
		}

		public static fcPixelFormat fcGetPixelFormat(TextureFormat v)
		{
			return default(fcPixelFormat);
		}

		public static int fcGetNumAudioChannels()
		{
			return 0;
		}

		[PreserveSig]
		public static extern void fcEnableAsyncReleaseContext(Bool v);

		[PreserveSig]
		public static extern void fcWaitAsyncDelete();

		[PreserveSig]
		public static extern void fcReleaseContext(IntPtr ctx);

		[PreserveSig]
		public static extern Bool fcPngIsSupported();

		[PreserveSig]
		public static extern fcPngContext fcPngCreateContext(ref fcPngConfig conf);

		[PreserveSig]
		public static extern Bool fcPngExportPixels(fcPngContext ctx, string path, byte[] pixels, int width, int height, fcPixelFormat fmt, int num_channels);

		[PreserveSig]
		public static extern Bool fcExrIsSupported();

		[PreserveSig]
		public static extern fcExrContext fcExrCreateContext(ref fcExrConfig conf);

		[PreserveSig]
		public static extern Bool fcExrBeginImage(fcExrContext ctx, string path, int width, int height);

		[PreserveSig]
		public static extern Bool fcExrAddLayerPixels(fcExrContext ctx, byte[] pixels, fcPixelFormat fmt, int ch, string name);

		[PreserveSig]
		public static extern Bool fcExrEndImage(fcExrContext ctx);

		[PreserveSig]
		public static extern Bool fcGifIsSupported();

		[PreserveSig]
		public static extern fcGifContext fcGifCreateContext(ref fcGifConfig conf);

		[PreserveSig]
		public static extern void fcGifAddOutputStream(fcGifContext ctx, fcStream stream);

		[PreserveSig]
		public static extern Bool fcGifAddFramePixels(fcGifContext ctx, byte[] pixels, fcPixelFormat fmt, double timestamp = -1.0);

		[PreserveSig]
		public static extern Bool fcMP4IsSupported();

		[PreserveSig]
		public static extern Bool fcMP4OSIsSupported();

		[PreserveSig]
		public static extern fcMP4Context fcMP4CreateContext(ref fcMP4Config conf);

		[PreserveSig]
		public static extern fcMP4Context fcMP4OSCreateContext(ref fcMP4Config conf, string path);

		[PreserveSig]
		public static extern void fcMP4AddOutputStream(fcMP4Context ctx, fcStream s);

		[PreserveSig]
		private static extern IntPtr fcMP4GetAudioEncoderInfo(fcMP4Context ctx);

		[PreserveSig]
		private static extern IntPtr fcMP4GetVideoEncoderInfo(fcMP4Context ctx);

		[PreserveSig]
		public static extern Bool fcMP4AddVideoFramePixels(fcMP4Context ctx, byte[] pixels, fcPixelFormat fmt, double timestamp = -1.0);

		[PreserveSig]
		public static extern Bool fcMP4AddAudioSamples(fcMP4Context ctx, float[] samples, int num_samples);

		public static string fcMP4GetAudioEncoderInfoS(fcMP4Context ctx)
		{
			return null;
		}

		public static string fcMP4GetVideoEncoderInfoS(fcMP4Context ctx)
		{
			return null;
		}

		[PreserveSig]
		public static extern Bool fcWebMIsSupported();

		[PreserveSig]
		public static extern fcWebMContext fcWebMCreateContext(ref fcWebMConfig conf);

		[PreserveSig]
		public static extern void fcWebMAddOutputStream(fcWebMContext ctx, fcStream stream);

		[PreserveSig]
		public static extern Bool fcWebMAddVideoFramePixels(fcWebMContext ctx, byte[] pixels, fcPixelFormat fmt, double timestamp = -1.0);

		[PreserveSig]
		public static extern Bool fcWebMAddAudioSamples(fcWebMContext ctx, float[] samples, int num_samples);

		[PreserveSig]
		public static extern Bool fcWaveIsSupported();

		[PreserveSig]
		public static extern fcWaveContext fcWaveCreateContext(ref fcWaveConfig conf);

		[PreserveSig]
		public static extern void fcWaveAddOutputStream(fcWaveContext ctx, fcStream stream);

		[PreserveSig]
		public static extern Bool fcWaveAddAudioSamples(fcWaveContext ctx, float[] samples, int num_samples);

		[PreserveSig]
		public static extern Bool fcOggIsSupported();

		[PreserveSig]
		public static extern fcOggContext fcOggCreateContext(ref fcOggConfig conf);

		[PreserveSig]
		public static extern void fcOggAddOutputStream(fcOggContext ctx, fcStream stream);

		[PreserveSig]
		public static extern Bool fcOggAddAudioSamples(fcOggContext ctx, float[] samples, int num_samples);

		[PreserveSig]
		public static extern Bool fcFlacIsSupported();

		[PreserveSig]
		public static extern fcFlacContext fcFlacCreateContext(ref fcFlacConfig conf);

		[PreserveSig]
		public static extern void fcFlacAddOutputStream(fcFlacContext ctx, fcStream stream);

		[PreserveSig]
		public static extern Bool fcFlacAddAudioSamples(fcFlacContext ctx, float[] samples, int num_samples);

		public static void fcLock(RenderTexture src, TextureFormat dstfmt, Action<byte[], fcPixelFormat> body)
		{
		}

		public static void fcLock(RenderTexture src, Action<byte[], fcPixelFormat> body)
		{
		}

		public static Mesh CreateFullscreenQuad()
		{
			return null;
		}
	}
}
