using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using NAudio.Wave;

namespace NAudio.MediaFoundation
{
	public static class MediaFoundationInterop
	{
		public const int MF_SOURCE_READER_ALL_STREAMS = -2;

		public const int MF_SOURCE_READER_FIRST_AUDIO_STREAM = -3;

		public const int MF_SOURCE_READER_FIRST_VIDEO_STREAM = -4;

		public const int MF_SOURCE_READER_MEDIASOURCE = -1;

		public const int MF_SDK_VERSION = 2;

		public const int MF_API_VERSION = 112;

		public const int MF_VERSION = 131184;

		public static extern void MFStartup(int version, int dwFlags = 0);

		public static extern void MFShutdown();

		internal static extern void MFCreateMediaType(out IMFMediaType ppMFType);

		internal static extern void MFInitMediaTypeFromWaveFormatEx([In] IMFMediaType pMFType, [In] WaveFormat pWaveFormat, [In] int cbBufSize);

		internal static extern void MFCreateWaveFormatExFromMFMediaType(IMFMediaType pMFType, ref IntPtr ppWF, ref int pcbSize, int flags = 0);

		public static extern void MFCreateSourceReaderFromURL([In] string pwszURL, [In] IMFAttributes pAttributes, out IMFSourceReader ppSourceReader);

		public static extern void MFCreateSourceReaderFromByteStream([In] IMFByteStream pByteStream, [In] IMFAttributes pAttributes, out IMFSourceReader ppSourceReader);

		public static extern void MFCreateSinkWriterFromURL([In] string pwszOutputURL, [In] IMFByteStream pByteStream, [In] IMFAttributes pAttributes, out IMFSinkWriter ppSinkWriter);

		public static extern void MFCreateMFByteStreamOnStream([In] IStream punkStream, out IMFByteStream ppByteStream);

		public static extern void MFTEnumEx([In] Guid guidCategory, [In] _MFT_ENUM_FLAG flags, [In] MFT_REGISTER_TYPE_INFO pInputType, [In] MFT_REGISTER_TYPE_INFO pOutputType, out IntPtr pppMFTActivate, out int pcMFTActivate);

		internal static extern void MFCreateSample(out IMFSample ppIMFSample);

		internal static extern void MFCreateMemoryBuffer(int cbMaxLength, out IMFMediaBuffer ppBuffer);

		internal static extern void MFCreateAttributes(out IMFAttributes ppMFAttributes, [In] int cInitialSize);

		public static extern void MFTranscodeGetAudioOutputAvailableTypes([In] Guid guidSubType, [In] _MFT_ENUM_FLAG dwMFTFlags, [In] IMFAttributes pCodecConfig, out IMFCollection ppAvailableTypes);
	}
}
