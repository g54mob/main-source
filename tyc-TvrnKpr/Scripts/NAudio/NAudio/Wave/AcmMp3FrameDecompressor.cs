using System;
using NAudio.Wave.Compression;

namespace NAudio.Wave
{
	public class AcmMp3FrameDecompressor : IMp3FrameDecompressor, IDisposable
	{
		private readonly AcmStream conversionStream;

		private readonly WaveFormat pcmFormat;

		private bool disposed;

		public WaveFormat OutputFormat => null;

		public AcmMp3FrameDecompressor(WaveFormat sourceFormat)
		{
		}

		public int DecompressFrame(Mp3Frame frame, byte[] dest, int destOffset)
		{
			return 0;
		}

		public void Reset()
		{
		}

		public void Dispose()
		{
		}

		~AcmMp3FrameDecompressor()
		{
		}
	}
}
