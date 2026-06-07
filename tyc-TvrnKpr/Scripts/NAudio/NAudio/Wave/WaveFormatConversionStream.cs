using System;

namespace NAudio.Wave
{
	public class WaveFormatConversionStream : WaveStream
	{
		private readonly WaveFormatConversionProvider conversionProvider;

		private readonly WaveFormat targetFormat;

		private readonly long length;

		private long position;

		private readonly WaveStream sourceStream;

		private bool isDisposed;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public override long Length => 0L;

		public override WaveFormat WaveFormat => null;

		public WaveFormatConversionStream(WaveFormat targetFormat, WaveStream sourceStream)
		{
		}

		public static WaveStream CreatePcmStream(WaveStream sourceStream)
		{
			return null;
		}

		[Obsolete("can be unreliable, use of this method not encouraged")]
		public int SourceToDest(int source)
		{
			return 0;
		}

		private long EstimateSourceToDest(long source)
		{
			return 0L;
		}

		private long EstimateDestToSource(long dest)
		{
			return 0L;
		}

		[Obsolete("can be unreliable, use of this method not encouraged")]
		public int DestToSource(int dest)
		{
			return 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
