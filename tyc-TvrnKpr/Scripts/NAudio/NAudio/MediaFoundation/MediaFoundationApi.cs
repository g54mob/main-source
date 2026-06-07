using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace NAudio.MediaFoundation
{
	public static class MediaFoundationApi
	{
		private static bool initialized;

		public static void Startup()
		{
		}

		public static IEnumerable<IMFActivate> EnumerateTransforms(Guid category)
		{
			return null;
		}

		public static void Shutdown()
		{
		}

		public static IMFMediaType CreateMediaType()
		{
			return null;
		}

		public static IMFMediaType CreateMediaTypeFromWaveFormat(WaveFormat waveFormat)
		{
			return null;
		}

		public static IMFMediaBuffer CreateMemoryBuffer(int bufferSize)
		{
			return null;
		}

		public static IMFSample CreateSample()
		{
			return null;
		}

		public static IMFAttributes CreateAttributes(int initialSize)
		{
			return null;
		}

		public static IMFByteStream CreateByteStream(object stream)
		{
			return null;
		}

		public static IMFSourceReader CreateSourceReaderFromByteStream(IMFByteStream byteStream)
		{
			return null;
		}
	}
}
