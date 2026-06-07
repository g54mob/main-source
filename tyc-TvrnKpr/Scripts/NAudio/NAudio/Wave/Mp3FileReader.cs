using System.Collections.Generic;
using System.IO;

namespace NAudio.Wave
{
	public class Mp3FileReader : WaveStream
	{
		public delegate IMp3FrameDecompressor FrameDecompressorBuilder(WaveFormat mp3Format);

		private readonly WaveFormat waveFormat;

		private Stream mp3Stream;

		private readonly long mp3DataLength;

		private readonly long dataStartPosition;

		private readonly XingHeader xingHeader;

		private readonly bool ownInputStream;

		private List<Mp3Index> tableOfContents;

		private int tocIndex;

		private long totalSamples;

		private readonly int bytesPerSample;

		private readonly int bytesPerDecodedFrame;

		private IMp3FrameDecompressor decompressor;

		private readonly byte[] decompressBuffer;

		private int decompressBufferOffset;

		private int decompressLeftovers;

		private bool repositionedFlag;

		private long position;

		private readonly object repositionLock;

		public Mp3WaveFormat Mp3WaveFormat { get; private set; }

		public Id3v2Tag Id3v2Tag { get; }

		public byte[] Id3v1Tag { get; }

		public override long Length => 0L;

		public override WaveFormat WaveFormat => null;

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

		public XingHeader XingHeader => null;

		public Mp3FileReader(string mp3FileName)
		{
		}

		public Mp3FileReader(string mp3FileName, FrameDecompressorBuilder frameDecompressorBuilder)
		{
		}

		public Mp3FileReader(Stream inputStream)
		{
		}

		public Mp3FileReader(Stream inputStream, FrameDecompressorBuilder frameDecompressorBuilder)
		{
		}

		private Mp3FileReader(Stream inputStream, FrameDecompressorBuilder frameDecompressorBuilder, bool ownInputStream)
		{
		}

		public static IMp3FrameDecompressor CreateAcmFrameDecompressor(WaveFormat mp3Format)
		{
			return null;
		}

		private void CreateTableOfContents()
		{
		}

		private void ValidateFrameFormat(Mp3Frame frame)
		{
		}

		private double TotalSeconds()
		{
			return 0.0;
		}

		public Mp3Frame ReadNextFrame()
		{
			return null;
		}

		private Mp3Frame ReadNextFrame(bool readData)
		{
			return null;
		}

		public override int Read(byte[] sampleBuffer, int offset, int numBytes)
		{
			return 0;
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
