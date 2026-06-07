using System;
using NAudio.Wave.Compression;

namespace NAudio.Wave
{
	public class WaveFormatConversionProvider : IWaveProvider, IDisposable
	{
		private readonly AcmStream conversionStream;

		private readonly IWaveProvider sourceProvider;

		private readonly int preferredSourceReadSize;

		private int leftoverDestBytes;

		private int leftoverDestOffset;

		private int leftoverSourceBytes;

		private bool isDisposed;

		public WaveFormat WaveFormat { get; }

		public WaveFormatConversionProvider(WaveFormat targetFormat, IWaveProvider sourceProvider)
		{
		}

		public void Reposition()
		{
		}

		public int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		~WaveFormatConversionProvider()
		{
		}
	}
}
