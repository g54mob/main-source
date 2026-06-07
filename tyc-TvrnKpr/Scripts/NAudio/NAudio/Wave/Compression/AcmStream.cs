using System;

namespace NAudio.Wave.Compression
{
	public class AcmStream : IDisposable
	{
		private IntPtr streamHandle;

		private IntPtr driverHandle;

		private AcmStreamHeader streamHeader;

		private readonly WaveFormat sourceFormat;

		public byte[] SourceBuffer => null;

		public byte[] DestBuffer => null;

		public AcmStream(WaveFormat sourceFormat, WaveFormat destFormat)
		{
		}

		public AcmStream(IntPtr driverId, WaveFormat sourceFormat, WaveFilter waveFilter)
		{
		}

		public int SourceToDest(int source)
		{
			return 0;
		}

		public int DestToSource(int dest)
		{
			return 0;
		}

		public static WaveFormat SuggestPcmFormat(WaveFormat compressedFormat)
		{
			return null;
		}

		public void Reposition()
		{
		}

		public int Convert(int bytesToConvert, out int sourceBytesConverted)
		{
			sourceBytesConverted = default(int);
			return 0;
		}

		[Obsolete("Call the version returning sourceBytesConverted instead")]
		public int Convert(int bytesToConvert)
		{
			return 0;
		}

		public void Dispose()
		{
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		~AcmStream()
		{
		}
	}
}
